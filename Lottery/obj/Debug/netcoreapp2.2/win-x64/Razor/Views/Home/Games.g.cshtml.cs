#pragma checksum "C:\Users\Main\source\repos\Lotery4\Views\Home\Games.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "250be2d21010dac26587ecbf8bd809f1694f21c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Games), @"mvc.1.0.view", @"/Views/Home/Games.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Games.cshtml", typeof(AspNetCore.Views_Home_Games))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"250be2d21010dac26587ecbf8bd809f1694f21c9", @"/Views/Home/Games.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0eba1f812e22e84cbdb29b4033b2ebd22266c83c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Games : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/resources/Cat_monet64.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:50px;width:50px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Main\source\repos\Lotery4\Views\Home\Games.cshtml"
  
    ViewData["Title"] = "Home Page";
    List<GameInfoMinModel> Games = ViewBag.Games;


#line default
#line hidden
            BeginContext(100, 420, true);
            WriteLiteral(@"
    <table id=""GamesInfoTable"" class=""table"">
        <thead class=""thead-dark "">
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">Rate</th>
                <th scope=""col"">Cash</th>
                <th scope=""col"">Time</th>
                <th scope=""col"">Max Players</th>
                <th scope=""col""></th>

            </tr>
        </thead>
        <tbody>

");
            EndContext();
#line 22 "C:\Users\Main\source\repos\Lotery4\Views\Home\Games.cshtml"
             for (int i = 0; i < Games.Count; i++)
            {


#line default
#line hidden
            BeginContext(589, 50, true);
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
            EndContext();
            BeginContext(641, 5, false);
#line 26 "C:\Users\Main\source\repos\Lotery4\Views\Home\Games.cshtml"
                            Write(i + 1);

#line default
#line hidden
            EndContext();
            BeginContext(647, 27, true);
            WriteLiteral("</th>\r\n                <td>");
            EndContext();
            BeginContext(674, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "250be2d21010dac26587ecbf8bd809f1694f21c95260", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(747, 13, false);
#line 27 "C:\Users\Main\source\repos\Lotery4\Views\Home\Games.cshtml"
                                                                                       Write(Games[i].Rate);

#line default
#line hidden
            EndContext();
            BeginContext(760, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(787, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "250be2d21010dac26587ecbf8bd809f1694f21c96819", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(860, 13, false);
#line 28 "C:\Users\Main\source\repos\Lotery4\Views\Home\Games.cshtml"
                                                                                       Write(Games[i].Cash);

#line default
#line hidden
            EndContext();
            BeginContext(873, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(901, 13, false);
#line 29 "C:\Users\Main\source\repos\Lotery4\Views\Home\Games.cshtml"
               Write(Games[i].Time);

#line default
#line hidden
            EndContext();
            BeginContext(914, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(942, 19, false);
#line 30 "C:\Users\Main\source\repos\Lotery4\Views\Home\Games.cshtml"
               Write(Games[i].MaxPlayers);

#line default
#line hidden
            EndContext();
            BeginContext(961, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(989, 107, false);
#line 31 "C:\Users\Main\source\repos\Lotery4\Views\Home\Games.cshtml"
               Write(Html.ActionLink("Open", "Game", "Home", new { GameID = i }, new { id = "---", @class = "btn btn-success" }));

#line default
#line hidden
            EndContext();
            BeginContext(1096, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 33 "C:\Users\Main\source\repos\Lotery4\Views\Home\Games.cshtml"
            }

#line default
#line hidden
            BeginContext(1137, 145, true);
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n\r\n\r\n<script>\r\n    function OpenGame(id) {\r\n        console.log(\"open game = \" + id);\r\n       \r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591