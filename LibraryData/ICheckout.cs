using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryData
{
    public interface ICheckout
    {
        void Add(Checkouts newCheckout);

        IEnumerable<Checkouts> GetAll();
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);

        Checkouts GetById(int checkoutId);
        Checkouts GetLatestCheckout(int assetId);       
        string GetCurrentCheckoutPatron(int assestId);
        string GetCurrentHoldPatronName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        bool IsCheckedOut(int id);

        void PlaceHold(int assetId, int libraryCardId);
        void ChecKOutItem(int assetId, int libraryCardId);
        void ChecKInItem(int assetId);
        void MarkLost(int assetId);
        void MarkFound(int assetId);
        
        
        
        

    }
}
