#pragma checksum "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8eb726e2980343be67f326eb086984c632ed0ab2"
// <auto-generated/>
#pragma warning disable 1591
namespace YourSpace.Pages
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
#line 1 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Pages\Index.razor"
using YourSpace.Modules.Pages.Page;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(2, "\r\n        ");
                __builder2.OpenComponent<YourSpace.Pages.PagesRating>(3);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(4, "\r\n    ");
            }
            ));
            __builder.AddAttribute(5, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(6, "\r\n\r\n        ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "d-flex flex-row flex-center");
                __builder2.AddMarkupContent(9, "\r\n            ");
                __builder2.OpenElement(10, "a");
                __builder2.AddAttribute(11, "class", "btn btn-primary");
                __builder2.AddAttribute(12, "href", "Identity/Account/Register");
                __builder2.AddContent(13, " ");
                __builder2.AddContent(14, 
#nullable restore
#line 17 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Pages\Index.razor"
                                                                          L["Register"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(15, "\r\n            ");
                __builder2.OpenElement(16, "a");
                __builder2.AddAttribute(17, "class", "btn btn-primary");
                __builder2.AddAttribute(18, "href", "Identity/Account/Login");
                __builder2.AddContent(19, " ");
                __builder2.AddContent(20, 
#nullable restore
#line 18 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Pages\Index.razor"
                                                                       L["Login"]

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(21, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(22, "\r\n\r\n        ");
                __builder2.AddMarkupContent(23, "<div class=\"container my-5\">\r\n\r\n\r\n            \r\n            <section class=\"magazine-section dark-grey-text\">\r\n\r\n                \r\n                <h3 class=\"text-center font-weight-bold mb-4 pb-2\">Magazine newsfeed</h3>\r\n                \r\n                <p class=\"text-center w-responsive mx-auto mb-5\">\r\n                    Duis aute irure dolor in reprehenderit in voluptate velit\r\n                    esse cillum dolore eu fugiat nulla sint occaecat cupidatat non proident, sunt culpa\r\n                    qui officia deserunt est laborum.\r\n                </p>\r\n\r\n                \r\n                <div class=\"row\">\r\n\r\n                    \r\n                    <div class=\"col-lg-4 col-md-12 mb-4\">\r\n\r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"view overlay rounded z-depth-2 mb-4\">\r\n                                <img class=\"img-fluid\" src alt=\"Sample image\">\r\n                                <a>\r\n                                    <div class=\"mask rgba-white-slight\"></div>\r\n                                </a>\r\n                            </div>\r\n\r\n                            \r\n                            <div class=\"row mb-3\">\r\n\r\n                                \r\n                                <div class=\"col-12\">\r\n\r\n                                    \r\n                                    <a href=\"#!\"><span class=\"badge pink\"><i class=\"fas fa-camera pr-2\" aria-hidden=\"true\"></i>Adventure</span></a>\r\n\r\n                                </div>\r\n                                \r\n\r\n                            </div>\r\n                            \r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a class=\"font-weight-bold\">This is title of the news</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a>24 Food Swaps That Slash Calories.</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a>How to Make a Beet Cocktail?</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a>8 Sneaky Reasons You\'re Always Hungry.</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0\">\r\n                                    <a>5 Pressure Cooker Recipes You Need to Try.</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n\r\n                    </div>\r\n                    \r\n                    \r\n                    <div class=\"col-lg-4 col-md-6 mb-4\">\r\n\r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"view overlay rounded z-depth-2 mb-4\">\r\n                                <img class=\"img-fluid\" src alt=\"Sample image\">\r\n                                <a>\r\n                                    <div class=\"mask rgba-white-slight\"></div>\r\n                                </a>\r\n                            </div>\r\n\r\n                            \r\n                            <div class=\"row mb-3\">\r\n\r\n                                \r\n                                <div class=\"col-12\">\r\n\r\n                                    \r\n                                    <a href=\"#!\"><span class=\"badge deep-orange\"><i class=\"fas fa-plane pr-2\" aria-hidden=\"true\"></i>Travel</span></a>\r\n\r\n                                </div>\r\n                                \r\n\r\n                            </div>\r\n                            \r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a class=\"font-weight-bold\">This is title of the news</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a>Trends in the blogosphere for 2018.</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a>Where can you eat the best lunch in Warsaw?</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a>What camera is worth taking for holidays?</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0\">\r\n                                    <a>Why should you visit Lisbon?</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n\r\n                    </div>\r\n                    \r\n                    \r\n                    <div class=\"col-lg-4 col-md-6 mb-4\">\r\n\r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"view overlay rounded z-depth-2 mb-4\">\r\n                                <img class=\"img-fluid\" src alt=\"Sample image\">\r\n                                <a>\r\n                                    <div class=\"mask rgba-white-slight\"></div>\r\n                                </a>\r\n                            </div>\r\n\r\n                            \r\n                            <div class=\"row mb-3\">\r\n\r\n                                \r\n                                <div class=\"col-12\">\r\n\r\n                                    \r\n                                    <a href=\"#!\"><span class=\"badge success-color\"><i class=\"fas fa-leaf pr-2\" aria-hidden=\"true\"></i>Nature</span></a>\r\n\r\n                                </div>\r\n                                \r\n\r\n                            </div>\r\n                            \r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a class=\"font-weight-bold\">This is title of the news</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a>How to recognize the footsteps of wild animals?</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a>National Parks in Poland.</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news mb-3\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0 mb-3\">\r\n                                    <a>Traveling without littering the planet.</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n                        \r\n                        <div class=\"single-news\">\r\n\r\n                            \r\n                            <div class=\"d-flex justify-content-between\">\r\n                                <div class=\"col-11 text-truncate pl-0\">\r\n                                    <a>How to protect rainforests?</a>\r\n                                </div>\r\n                                <a><i class=\"fas fa-angle-double-right\"></i></a>\r\n                            </div>\r\n\r\n                        </div>\r\n                        \r\n\r\n                    </div>\r\n                    \r\n\r\n                </div>\r\n                \r\n\r\n            </section>\r\n            \r\n\r\n\r\n        </div>\r\n\r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 332 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Pages\Index.razor"
 
    [Inject] protected Microsoft.AspNetCore.Identity.UI.Services.IEmailSender Sender { get; set; }
    protected override void OnInitialized()
    {
    }

    async void Send()
    {
        await Sender.SendEmailAsync("dubkova80@bk.ru", "Друг мой", "dddd");
    }

    void Test()
    {
        Navigation.NavigateTo("Errors/Error404?returnPage=Index");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private YourSpace.Modules.EmailSender.SEmailHtmlMessagesReader R { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<Index> L { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager Navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private YourSpace.Services.ISModal SModal { get; set; }
    }
}
#pragma warning restore 1591
