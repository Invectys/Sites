#pragma checksum "D:\Lotery4\Views\News\_Article.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6558a4971f9bd86d6828ce1d653efac817a2329a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News__Article), @"mvc.1.0.view", @"/Views/News/_Article.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/News/_Article.cshtml", typeof(AspNetCore.Views_News__Article))]
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
#line 1 "D:\Lotery4\Views\_ViewImports.cshtml"
using Lotery4;

#line default
#line hidden
#line 2 "D:\Lotery4\Views\_ViewImports.cshtml"
using Lotery4.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6558a4971f9bd86d6828ce1d653efac817a2329a", @"/Views/News/_Article.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0eba1f812e22e84cbdb29b4033b2ebd22266c83c", @"/Views/_ViewImports.cshtml")]
    public class Views_News__Article : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ArticleModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("MinArticleForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateArticle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "News", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Lotery4\Views\News\_Article.cshtml"
  
    Layout = null;
    string left = Model.ImageInfo.left;
    string top = Model.ImageInfo.top;

#line default
#line hidden
            BeginContext(128, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(438, 23, true);
            WriteLiteral("\r\n\r\n    <div>\r\n        ");
            EndContext();
            BeginContext(461, 1118, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6558a4971f9bd86d6828ce1d653efac817a2329a5144", async() => {
                BeginContext(582, 308, true);
                WriteLiteral(@"

            <div class=""article row "" style=""overflow:hidden;height:33vh"">


                <div class=""col-md-7"" style=""overflow:hidden"">

                    <div style=""max-height:300px;max-width:700px;overflow:hidden"">
                        <img id=""article-img"" class=""rounded mb-3 mb-md-0""");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 890, "\"", 914, 1);
#line 33 "D:\Lotery4\Views\News\_Article.cshtml"
WriteAttributeValue("", 896, Model.PicturePath, 896, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("style", "\r\n                             style=\"", 915, "\"", 993, 7);
                WriteAttributeValue("", 953, "margin-left:-", 953, 13, true);
#line 34 "D:\Lotery4\Views\News\_Article.cshtml"
WriteAttributeValue("", 966, left, 966, 5, false);

#line default
#line hidden
                WriteAttributeValue(" ", 971, ";", 972, 2, true);
                WriteAttributeValue(" ", 973, "margin-top:", 974, 12, true);
                WriteAttributeValue(" ", 985, "-", 986, 2, true);
#line 34 "D:\Lotery4\Views\News\_Article.cshtml"
WriteAttributeValue("", 987, top, 987, 4, false);

#line default
#line hidden
                WriteAttributeValue(" ", 991, ";", 992, 2, true);
                EndWriteAttribute();
                BeginContext(994, 182, true);
                WriteLiteral(" alt=\"\">\r\n                    </div>\r\n\r\n\r\n\r\n                </div>\r\n                <div class=\"col-md-5\">\r\n\r\n                    <h3 id=\"Title\" onclick=\"\">\r\n                        ");
                EndContext();
                BeginContext(1177, 11, false);
#line 43 "D:\Lotery4\Views\News\_Article.cshtml"
                   Write(Model.Title);

#line default
#line hidden
                EndContext();
                BeginContext(1188, 205, true);
                WriteLiteral("\r\n\r\n                    </h3>\r\n\r\n\r\n\r\n\r\n                    <div id=\"MainInformationBlock\" style=\"overflow:hidden\">\r\n                        <p id=\"Information\" onclick=\"\">\r\n\r\n\r\n                            ");
                EndContext();
                BeginContext(1394, 17, false);
#line 54 "D:\Lotery4\Views\News\_Article.cshtml"
                       Write(Model.Information);

#line default
#line hidden
                EndContext();
                BeginContext(1411, 161, true);
                WriteLiteral("\r\n\r\n                        </p>\r\n\r\n\r\n\r\n\r\n\r\n\r\n                    </div>\r\n\r\n                </div>\r\n\r\n\r\n\r\n            </div>\r\n           \r\n            \r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1579, 39, true);
            WriteLiteral("\r\n\r\n        <hr>\r\n       \r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ArticleModel> Html { get; private set; }
    }
}
#pragma warning restore 1591