#pragma checksum "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5960d2022d5a67937d8df894c44060d209ae9251"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_ConfirmEmail), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/ConfirmEmail.cshtml")]
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
#nullable restore
#line 1 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\_ViewImports.cshtml"
using YourSpace.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\_ViewImports.cshtml"
using YourSpace.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using YourSpace.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5960d2022d5a67937d8df894c44060d209ae9251", @"/Areas/Identity/Pages/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fed07ed2767aad1a2fc2dd1db3639ea67eb5910", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8c05371aa67708ed420ba2069b7ecfef458c1d6", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
  
    ViewData["Title"] = "Confirm email";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
 if (Model.Succeeded)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>");
#nullable restore
#line 10 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
   Write(L["AccountConfirmed"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <a href=\"/identity/account/Login\">");
#nullable restore
#line 11 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
                                 Write(L["Sign In"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 12 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>");
#nullable restore
#line 15 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
   Write(L["AccountNotConfirmed"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 16 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Areas\Identity\Pages\Account\ConfirmEmail.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.Extensions.Localization.IStringLocalizer<ConfirmEmailPage> L { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ConfirmEmailModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ConfirmEmailModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ConfirmEmailModel>)PageContext?.ViewData;
        public ConfirmEmailModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
