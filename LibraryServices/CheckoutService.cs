using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class CheckoutService : ICheckout
    {
        private LibraryContext _context;

        public CheckoutService(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Checkouts newCheckout)
        {
            _context.Add(newCheckout);
            _context.SaveChanges();
        }

        public IEnumerable<Checkouts> GetAll()
        {
            return _context.Checkouts;
        }

        public Checkouts GetById(int checkoutId)
        {
            return GetAll()
                .FirstOrDefault(checkout => checkout.Id == checkoutId);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int id)
        {
            return _context.CheckoutHistorys
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .Where(h => h.LibraryAsset.Id == id);
        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds
                .Include(h => h.LibraryAsset)
                .Where(h => h.LibraryAsset.Id == id);
        }

        public Checkouts GetLatestCheckout(int assetId)
        {
            return _context.Checkouts
                .Where(h => h.LibraryAsset.Id == assetId)
                .OrderByDescending(c => c.Since)
                .FirstOrDefault();
        }


        public void MarkFound(int assetId)
        {
            //Update Asset Stattus
            UpdateAssestStatus(assetId, "Available");

            // remove any existing checkouts on the item
            RemoveExistingCheckouts(assetId);

            // close any existing checkout history
            CloseExistingCheckoutHistory(assetId);

            _context.SaveChanges();
          
        }

        public void MarkLost(int assetId)
        {
            UpdateAssestStatus(assetId, "Lost");

            _context.SaveChanges();
        }

        public void ChecKInItem(int assetId)
        {
            var item = _context.LibraryAssets
                .FirstOrDefault(a => a.Id == assetId);            

            // remove any existing checkouts on the item
            RemoveExistingCheckouts(assetId);

            // close any existing checkout history
            CloseExistingCheckoutHistory(assetId);

            // look for existing holds on the item
            var currentHolds = _context.Holds.
                Include(c => c.LibraryAsset)
                .Include(c => c.LibraryCard)
                .Where(c => c.LibraryAsset.Id == assetId);

            //if there are holds, checkout the item to the 
            // librarycard with the earlist hold
            if(currentHolds.Any())
            {
                CheckoutToEarliestHold(assetId, currentHolds);
                return;
            }

            // otherwise, update the item status to available
            UpdateAssestStatus(assetId, "Available");

            _context.SaveChanges();
        }

        private void CheckoutToEarliestHold(int assetId, IQueryable<Hold> currentHolds)
        {
            var earliestHold = currentHolds
                .OrderBy(holds => holds.HoldPlaced)
                .FirstOrDefault();

            var card = earliestHold.LibraryCard;

            _context.Remove(earliestHold);
            _context.SaveChanges();

            ChecKOutItem(assetId, card.Id);
        }

        public void ChecKOutItem(int assetId, int libraryCardId)
        {
            if(IsCheckedOut(assetId))
            {
                return;
                //Add logic here to handle feedback to the user;
            }

            var item = _context.LibraryAssets
                .FirstOrDefault(a => a.Id == assetId);

            UpdateAssestStatus(assetId, "Checked Out");

            var libraryCard = _context.LibraryCards
                .Include(card => card.Checkouts)
                .FirstOrDefault(card => card.Id == libraryCardId);

            var now = DateTime.Now;

            var checkout = new Checkouts
            {
                LibraryAsset = item,
                LibraryCard = libraryCard,
                Since = now,
                Until = GetDefaultCheckoutTime(now)
            };

            _context.Add(checkout);

            var checkoutHistory = new CheckoutHistory
            {
                CheckOut = now,
                LibraryAsset = item,
                LibraryCard = libraryCard
            };

            _context.Add(checkoutHistory);

            _context.SaveChanges();
        }

        private DateTime GetDefaultCheckoutTime(DateTime now)
        {
            return now.AddDays(30);
        }

        public bool IsCheckedOut(int assetId)
        {
            return _context.Checkouts
                .Where(co => co.LibraryAsset.Id == assetId)
                .Any();
        }

        private void UpdateAssestStatus(int assetId, string newSatus)
        {
            var item = _context.LibraryAssets
                .FirstOrDefault(a => a.Id == assetId); 

            item.Status = _context.Statuses
                .FirstOrDefault(status => status.Name == newSatus);

            _context.Update(item);
        }

        private void CloseExistingCheckoutHistory(int assetId)
        {
            var history = _context.CheckoutHistorys
                .FirstOrDefault(c => c.LibraryAsset.Id == assetId
                    && c.CheckIn == null);

            if (history != null)
            {
                _context.Update(history);
                history.CheckIn = DateTime.Now;
            }
        }

        private void RemoveExistingCheckouts(int assetId)
        {
           var checkout = _context.Checkouts
                .FirstOrDefault(co => co.LibraryAsset.Id == assetId);

            if(checkout != null)
            {
                _context.Remove(checkout);
            }
        }



        public void PlaceHold(int assetId, int libraryCardId)
        {
            var asset = _context.LibraryAssets
                .Include(a => a.Status)
                .FirstOrDefault(a => a.Id == assetId);

            var card = _context.LibraryCards
                .FirstOrDefault(c => c.Id == libraryCardId);

            var now = DateTime.Now;

            if(asset.Status.Name == "Available")
            {
                UpdateAssestStatus(assetId, "On Hold");
            }

            var hold = new Hold
            {
                HoldPlaced = now,
                LibraryAsset = asset,
                LibraryCard = card
            };

            _context.Add(hold);
            _context.SaveChanges();
        }
       
        public string GetCurrentHoldPatronName(int holdId)
        {
            var hold = _context.Holds
                .Include(c => c.LibraryAsset)
                .Include(c => c.LibraryCard)
                .FirstOrDefault(c => c.Id == holdId);

            var cardId = hold?.LibraryCard.Id;

            var patron = _context.Patrons.Include(p => p.LibraryCard)
                .FirstOrDefault(p => p.LibraryCard.Id == cardId);

            return patron?.FirstName + " " + patron?.LastName;
        }

        public DateTime GetCurrentHoldPlaced(int holdId)
        {
            return
                _context.Holds
                .Include(c => c.LibraryAsset)
                .Include(c => c.LibraryCard)
                .FirstOrDefault(c => c.Id == holdId)
                .HoldPlaced;

        }

        public string GetCurrentCheckoutPatron(int assestId)
        {
            var checkout = GetCheckoutByAssetId(assestId);

            if(checkout == null)
            {
                return "";
            };

            var cardId = checkout.LibraryCard.Id;

            var patron = _context.Patrons
                .Include(p => p.LibraryCard)
                .FirstOrDefault(p => p.LibraryCard.Id == cardId);

            return patron.FirstName + " " + patron.LastName;
        }

        private Checkouts GetCheckoutByAssetId(int assestId)
        {
            return _context.Checkouts
                .Include(co => co.LibraryAsset)
                .Include(co => co.LibraryCard)
                .FirstOrDefault(co => co.LibraryAsset.Id == assestId);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    