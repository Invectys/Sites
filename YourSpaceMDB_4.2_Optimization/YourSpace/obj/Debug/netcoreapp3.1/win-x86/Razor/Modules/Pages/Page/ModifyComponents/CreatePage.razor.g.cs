#pragma checksum "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "076192d8b9057fe933035952fb300ed7409f9929"
// <auto-generated/>
#pragma warning disable 1591
namespace YourSpace.Modules.Pages.Page.ModifyComponents
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.ModalWindow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Page.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Page.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Page.ModifyComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Blocks.ModifyComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Blocks.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Blocks.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Blocks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Groups.ModifyComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Groups.ViewMode;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Groups.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.ThingCounter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.ThingCounter.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.DataWorker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Cloner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Gallery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Gallery.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.FileUpload;

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Moderation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Moderation.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.ComponentsView;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Lister;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Image;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.UserProfile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.UserProfile.Compoents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Music;

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using BlazorInputFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
using YourSpace.Modules.Pages.Page;

#line default
#line hidden
#nullable disable
    public partial class CreatePage : CModalTemplete
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 7 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                 createPage

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 7 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                                            HandleSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(4, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(5);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(7);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(8, "\r\n    ");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "d-flex flex-column");
                __builder2.AddMarkupContent(11, "\r\n        ");
                __builder2.OpenComponent<YourSpace.Modules.ComponentsView.ErrorText>(12);
                __builder2.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(14, 
#nullable restore
#line 13 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                    L[InfoMessage]

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(15, "\r\n        ");
                __builder2.OpenComponent<YourSpace.Modules.ComponentsView.InfoText>(16);
                __builder2.AddAttribute(17, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(18, 
#nullable restore
#line 14 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                   L["Your url = bluejour.net/"]

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(19, 
#nullable restore
#line 14 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                                                 createPage.Url

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(20, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(21, "\r\n    ");
                __builder2.OpenComponent<YourSpace.Modules.Inputs.MyInputText>(22);
                __builder2.AddAttribute(23, "id", "name");
                __builder2.AddAttribute(24, "Label", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 16 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                                                                L["Page id"]

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(25, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 16 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                                        createPage.Url

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(26, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => createPage.Url = __value, createPage.Url))));
                __builder2.AddAttribute(27, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => createPage.Url));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(28, "\r\n    ");
                __builder2.OpenComponent<YourSpace.Modules.Pages.Blocks.ModifyComponents.SetupPageBlock>(29);
                __builder2.AddAttribute(30, "Block", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<YourSpace.Modules.Pages.Blocks.MPageBlock>(
#nullable restore
#line 17 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                           createPage.DisplayBlock

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(31, "\r\n\r\n    ");
                __builder2.OpenComponent<YourSpace.Modules.ComponentsView.Button1>(32);
                __builder2.AddAttribute(33, "Submit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 19 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                     true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(34, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(35, 
#nullable restore
#line 19 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                            L["Continue"]

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(36, "\r\n    ");
                __builder2.OpenComponent<YourSpace.Modules.ComponentsView.ErrorText>(37);
                __builder2.AddAttribute(38, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(39, 
#nullable restore
#line 20 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
                L[InfoMessage]

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(40, "\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 26 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Pages\Page\ModifyComponents\CreatePage.razor"
       

    public string InfoMessage { get; set; } = "";

    private MCreatePage createPage = new MCreatePage();

    [Inject] protected ISPagesUrl SPagesUrl { get; set; }

    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }


    public static new int GetDefaultModalId() => 1;

    private async void HandleSubmit()
    {
        var user = (await authenticationStateTask).User;

        CreatePageResult result = await SPagesModifier.CreateNewPage(createPage, user);
        if(result.Succeeded)
        {
            Close(ModalResult.OK(result.Page));
        }
        else
        {
            InfoMessage = result.Errors[0];
            StateHasChanged();
        }

    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private YourSpace.Services.ISPagesModifier SPagesModifier { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<CreatePage> L { get; set; }
    }
}
#pragma warning restore 1591
