#pragma checksum "C:\Users\fela\Documents\Visual Studio 2017\Projects\Web Development\Core 2 Application\LibraryManagement\LibraryManagement\Views\Catelog\Hold.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "872317c70583b85a3b2f9de476352d500cb51d63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Catelog_Hold), @"mvc.1.0.view", @"/Views/Catelog/Hold.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Catelog/Hold.cshtml", typeof(AspNetCore.Views_Catelog_Hold))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\fela\Documents\Visual Studio 2017\Projects\Web Development\Core 2 Application\LibraryManagement\LibraryManagement\Views\_ViewImports.cshtml"
using LibraryManagement;

#line default
#line hidden
#line 2 "C:\Users\fela\Documents\Visual Studio 2017\Projects\Web Development\Core 2 Application\LibraryManagement\LibraryManagement\Views\_ViewImports.cshtml"
using LibraryManagement.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"872317c70583b85a3b2f9de476352d500cb51d63", @"/Views/Catelog/Hold.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a03b079343b697176e720de9fa2d2a7e6e87ff5", @"/Views/_ViewImports.cshtml")]
    public class Views_Catelog_Hold : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LibraryManagement.Models.Checkout.CheckoutModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("detailImage"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(56, 309, true);
            WriteLiteral(@"

<div class=""container"">
    <div class=""header clearfix detailHeading"">
        <h2 class=""text-muted"">Place Hold on Library Item</h2>
    </div>

    <div class=""jumbotron"">
        <div class=""row"">
            <div class=""col-md-3"">
                <div>
                    <p id=""itemTitle"">");
            EndContext();
            BeginContext(366, 11, false);
#line 13 "C:\Users\fela\Documents\Visual Studio 2017\Projects\Web Development\Core 2 Application\LibraryManagement\LibraryManagement\Views\Catelog\Hold.cshtml"
                                 Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(377, 26, true);
            WriteLiteral("</p>\r\n                    ");
            EndContext();
            BeginContext(403, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9570932731984996a449923d53a0c7f8", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 445, "~/images/", 445, 9, true);
#line 14 "C:\Users\fela\Documents\Visual Studio 2017\Projects\Web Development\Core 2 Application\LibraryManagement\LibraryManagement\Views\Catelog\Hold.cshtml"
AddHtmlAttributeValue("", 454, Model.ImageUrl, 454, 15, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(473, 125, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        \r\n\r\n        <div class=\"col-md-9\">\r\n            <p>There are currently ");
            EndContext();
            BeginContext(599, 15, false);
#line 20 "C:\Users\fela\Documents\Visual Studio 2017\Projects\Web Development\Core 2 Application\LibraryManagement\LibraryManagement\Views\Catelog\Hold.cshtml"
                              Write(Model.HoldCount);

#line default
#line hidden
            EndContext();
            BeginContext(614, 39, true);
            WriteLiteral(" holds in the queue for this item</p>\r\n");
            EndContext();
#line 21 "C:\Users\fela\Documents\Visual Studio 2017\Projects\Web Development\Core 2 Application\LibraryManagement\LibraryManagement\Views\Catelog\Hold.cshtml"
             using (Html.BeginForm("PlaceHold", "Catelog", FormMethod.Post))
            {
                

#line default
#line hidden
            BeginContext(763, 30, false);
#line 23 "C:\Users\fela\Documents\Visual Studio 2017\Projects\Web Development\Core 2 Application\LibraryManagement\LibraryManagement\Views\Catelog\Hold.cshtml"
           Write(Html.HiddenFor(a => a.AssetId));

#line default
#line hidden
            EndContext();
            BeginContext(795, 96, true);
            WriteLiteral("                <div>\r\n                    Please Insert a Library Card ID\r\n                    ");
            EndContext();
            BeginContext(892, 37, false);
#line 26 "C:\Users\fela\Documents\Visual Studio 2017\Projects\Web Development\Core 2 Application\LibraryManagement\LibraryManagement\Views\Catelog\Hold.cshtml"
               Write(Html.TextBoxFor(a => a.LibraryCardId));

#line default
#line hidden
            EndContext();
            BeginContext(929, 164, true);
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    <button type=\"submit\" class=\"btn btn-info btn-lg\">Place Hold</button>\r\n                </div>\r\n");
            EndContext();
#line 31 "C:\Users\fela\Documents\Visual Studio 2017\Projects\Web Development\Core 2 Application\LibraryManagement\LibraryManagement\Views\Catelog\Hold.cshtml"

            }

#line default
#line hidden
            BeginContext(1110, 50, true);
            WriteLiteral("        </div>\r\n    </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LibraryManagement.Models.Checkout.CheckoutModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
