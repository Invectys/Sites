#pragma checksum "C:\Users\Main\source\repos\Lotery4\Views\PersonalPages\PageCreated.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17f354d568151094cb64a07f93c83ca8e2dcbcf9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PersonalPages_PageCreated), @"mvc.1.0.view", @"/Views/PersonalPages/PageCreated.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PersonalPages/PageCreated.cshtml", typeof(AspNetCore.Views_PersonalPages_PageCreated))]
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
#line 1 "C:\Users\Main\source\repos\Lotery4\Views\_ViewImports.cshtml"
using Lotery4;

#line default
#line hidden
#line 2 "C:\Users\Main\source\repos\Lotery4\Views\_ViewImports.cshtml"
using Lotery4.Models;

#line default
#line hidden
#line 1 "C:\Users\Main\source\repos\Lotery4\Views\PersonalPages\PageCreated.cshtml"
using Lotery4.Models.Enums;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17f354d568151094cb64a07f93c83ca8e2dcbcf9", @"/Views/PersonalPages/PageCreated.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0eba1f812e22e84cbdb29b4033b2ebd22266c83c", @"/Views/_ViewImports.cshtml")]
    public class Views_PersonalPages_PageCreated : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Lotery4.Models.ViewModels.PageCreatedViewModel>
    {
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
            BeginContext(93, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\Main\source\repos\Lotery4\Views\PersonalPages\PageCreated.cshtml"
 switch (Model.result)
{
    case CreatePageResult.OK:
        

#line default
#line hidden
            BeginContext(167, 12, true);
            WriteLiteral("Page created");
            EndContext();
            BeginContext(186, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(196, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17f354d568151094cb64a07f93c83ca8e2dcbcf93827", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 205, "~/", 205, 2, true);
#line 11 "C:\Users\Main\source\repos\Lotery4\Views\PersonalPages\PageCreated.cshtml"
AddHtmlAttributeValue("", 207, User.Identity.Name, 207, 19, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 226, "/", 226, 1, true);
#line 11 "C:\Users\Main\source\repos\Lotery4\Views\PersonalPages\PageCreated.cshtml"
AddHtmlAttributeValue("", 227, Model.PageName, 227, 15, false);

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
            BeginContext(248, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 12 "C:\Users\Main\source\repos\Lotery4\Views\PersonalPages\PageCreated.cshtml"
        break;
    case CreatePageResult.PageExist:
        

#line default
#line hidden
            BeginContext(318, 19, true);
            WriteLiteral("Page already exist!");
            EndContext();
            BeginContext(344, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(354, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17f354d568151094cb64a07f93c83ca8e2dcbcf96060", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 363, "~/", 363, 2, true);
#line 15 "C:\Users\Main\source\repos\Lotery4\Views\PersonalPages\PageCreated.cshtml"
AddHtmlAttributeValue("", 365, User.Identity.Name, 365, 19, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 384, "/", 384, 1, true);
#line 15 "C:\Users\Main\source\repos\Lotery4\Views\PersonalPages\PageCreated.cshtml"
AddHtmlAttributeValue("", 385, Model.PageName, 385, 15, false);

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
            BeginContext(406, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 16 "C:\Users\Main\source\repos\Lotery4\Views\PersonalPages\PageCreated.cshtml"
        break;



    default:
        
        break;
}

#line default
#line hidden
            BeginContext(473, 14, true);
            WriteLiteral("            \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Lotery4.Models.ViewModels.PageCreatedViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
