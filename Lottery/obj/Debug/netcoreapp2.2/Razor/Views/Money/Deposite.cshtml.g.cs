#pragma checksum "D:\Lotery4\Views\Money\Deposite.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "578c28538da95175600eb428771ddd7a7efee02e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Money_Deposite), @"mvc.1.0.view", @"/Views/Money/Deposite.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Money/Deposite.cshtml", typeof(AspNetCore.Views_Money_Deposite))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"578c28538da95175600eb428771ddd7a7efee02e", @"/Views/Money/Deposite.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0eba1f812e22e84cbdb29b4033b2ebd22266c83c", @"/Views/_ViewImports.cshtml")]
    public class Views_Money_Deposite : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("https://money.yandex.ru/quickpay/confirm.xml"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Lotery4\Views\Money\Deposite.cshtml"
  
    ViewData["Title"] = "Deposite";

#line default
#line hidden
            BeginContext(46, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
#line 8 "D:\Lotery4\Views\Money\Deposite.cshtml"
  
    ViewBag.Title = "Buy page";

#line default
#line hidden
            BeginContext(92, 104, true);
            WriteLiteral("\r\n<div class=\"row  justify-content-md-center mt-md-5\" >\r\n\r\n    <div class=\"col-md-5\">\r\n       \r\n        ");
            EndContext();
            BeginContext(196, 2134, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "578c28538da95175600eb428771ddd7a7efee02e4459", async() => {
                BeginContext(270, 33, true);
                WriteLiteral("\r\n            <input name=\"label\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 303, "\"", 338, 1);
#line 17 "D:\Lotery4\Views\Money\Deposite.cshtml"
WriteAttributeValue("", 311, Context.User.Identity.Name, 311, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(339, 354, true);
                WriteLiteral(@" type=""hidden"">
            <input name=""receiver"" value=""410013386253302"" type=""hidden"">
            <input name=""quickpay-form"" value=""shop"" type=""hidden"">
            <input type=""hidden"" name=""targets"" value=""Покупка офигенных денег котов !!!!!"">
            
            <div class=""row no-gutters"">
                <div class=""col-md-auto"">
");
                EndContext();
                BeginContext(750, 340, true);
                WriteLiteral(@"                    <input type=""number"" id=""Summ"" onchange=""OnPayAmountChange(this)"" name=""sum"" value=""100""  maxlength=""10"" data-type=""number"" class=""form-control "" type=""text"">
                </div>
                <div class=""col-md-auto ml-1"">Rub in Cat Money <tt id=""ShowCourse""> </tt> </div>

            </div>
            

");
                EndContext();
                BeginContext(1147, 1176, true);
                WriteLiteral(@"
            <div class=""btn-group btn-group-toggle mt-4"" data-toggle=""buttons"">

                <label class=""btn  PayMethode "" style=""height:5rem ;width:9rem;
                   background-image:url(https://shop.vampirus.ru/static/images/stories/virtuemart/product/yandex8.jpg);
                   background-size:cover;"">

                    <input type=""radio"" name=""paymentType"" value=""PC"" />

                </label>

                <label class=""btn   PayMethode ml-1"" style=""height:5rem ;width:9rem;
                   background-image:url(https://moba-tel.ru/wp-content/uploads/2019/04/cards.jpg);
                   background-size:cover;"">

                    <input type=""radio"" name=""paymentType"" value=""AC"">

                </label>

            </div>
            <br/>
            
                
           

            <input class=""btn btn-success btn-lg mt-4"" type=""submit"" name=""submit-button"" value=""Оплатить"">
            <input name=""successURL"" value=""http://black");
                WriteLiteral("catlottery.xyz/Money/DepositeOk\" type=\"hidden\">\r\n            <input name=\"quickpay-back-url\" value=\"http://blackcatlottery.xyz\" type=\"hidden\">\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2330, 109, true);
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n<script>\r\n    var minValue = 50;\r\n    var maxValue = 50000;\r\n    var RubleCourse = ");
            EndContext();
            BeginContext(2440, 20, false);
#line 69 "D:\Lotery4\Views\Money\Deposite.cshtml"
                 Write(ViewBag.RoubleCourse);

#line default
#line hidden
            EndContext();
            BeginContext(2460, 435, true);
            WriteLiteral(@";

    $('.PayMethode').on(""click"", function () {
       
        $('.PayMethode').removeClass('active1');
        $(this).addClass('active1');
    });
    function OnPayAmountChange(block) {
        //console.log(amount);
        if (minValue > block.value) block.value = minValue;
        if (maxValue < block.value) block.value = maxValue;
        $('#ShowCourse').text(block.value * RubleCourse);
    }
</script>


");
            EndContext();
            BeginContext(2982, 4, true);
            WriteLiteral("\r\n\r\n");
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
