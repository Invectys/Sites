#pragma checksum "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\Admin.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cf05acf861a5f7819c78c46b36c85c65aeb4635"
// <auto-generated/>
#pragma warning disable 1591
namespace YourSpace.Modules.Moderation
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
#line 13 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Page;

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
#line 2 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\Admin.razor"
           [Authorize(Roles = "Admin")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin")]
    public partial class Admin : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "classic-tabs mx-2");
            __builder.AddMarkupContent(2, "\r\n\r\n        ");
            __builder.OpenElement(3, "ul");
            __builder.AddAttribute(4, "class", "nav tabs-orange");
            __builder.AddAttribute(5, "id", "myClassicTabOrange");
            __builder.AddAttribute(6, "role", "tablist");
            __builder.AddMarkupContent(7, "\r\n            ");
            __builder.OpenElement(8, "li");
            __builder.AddAttribute(9, "class", "nav-item");
            __builder.AddMarkupContent(10, "\r\n                ");
            __builder.OpenElement(11, "a");
            __builder.AddAttribute(12, "class", "nav-link  waves-light active show");
            __builder.AddAttribute(13, "id", "profile-tab-classic-orange");
            __builder.AddAttribute(14, "data-toggle", "tab");
            __builder.AddAttribute(15, "href", "#profile-classic-orange");
            __builder.AddAttribute(16, "role", "tab");
            __builder.AddAttribute(17, "aria-controls", "profile-classic-orange");
            __builder.AddAttribute(18, "aria-selected", "true");
            __builder.AddMarkupContent(19, "\r\n                    <object type=\"image/svg+xml\" data=\"dist/img/svg/user.svg\"></object>\r\n                    <br>");
            __builder.AddContent(20, 
#nullable restore
#line 14 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\Admin.razor"
                         L["Users"]

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(21, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n            ");
            __builder.OpenElement(24, "li");
            __builder.AddAttribute(25, "class", "nav-item");
            __builder.AddMarkupContent(26, "\r\n                ");
            __builder.OpenElement(27, "a");
            __builder.AddAttribute(28, "class", "nav-link waves-light");
            __builder.AddAttribute(29, "id", "follow-tab-classic-orange");
            __builder.AddAttribute(30, "data-toggle", "tab");
            __builder.AddAttribute(31, "href", "#follow-classic-orange");
            __builder.AddAttribute(32, "role", "tab");
            __builder.AddAttribute(33, "aria-controls", "follow-classic-orange");
            __builder.AddAttribute(34, "aria-selected", "false");
            __builder.AddMarkupContent(35, "\r\n                    <i class=\"fas fa-heart fa-2x pb-2\" aria-hidden=\"true\"></i><br>");
            __builder.AddContent(36, 
#nullable restore
#line 21 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\Admin.razor"
                                                   L["Follow"]

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(37, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n            ");
            __builder.OpenElement(40, "li");
            __builder.AddAttribute(41, "class", "nav-item");
            __builder.AddMarkupContent(42, "\r\n                ");
            __builder.OpenElement(43, "a");
            __builder.AddAttribute(44, "class", "nav-link waves-light");
            __builder.AddAttribute(45, "id", "contact-tab-classic-orange");
            __builder.AddAttribute(46, "data-toggle", "tab");
            __builder.AddAttribute(47, "href", "#contact-classic-orange");
            __builder.AddAttribute(48, "role", "tab");
            __builder.AddAttribute(49, "aria-controls", "contact-classic-orange");
            __builder.AddAttribute(50, "aria-selected", "false");
            __builder.AddMarkupContent(51, "\r\n                    <i class=\"fas fa-envelope fa-2x pb-2\" aria-hidden=\"true\"></i><br>");
            __builder.AddContent(52, 
#nullable restore
#line 28 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\Admin.razor"
                                                   L["Contact"]

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(53, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n            ");
            __builder.AddMarkupContent(56, @"<li class=""nav-item"">
                <a class=""nav-link waves-light"" id=""awesome-tab-classic-orange"" data-toggle=""tab"" href=""#awesome-classic-orange"" role=""tab"" aria-controls=""awesome-classic-orange"" aria-selected=""false"">
                    <i class=""fas fa-star fa-2x pb-2"" aria-hidden=""true""></i><br>Be awesome
                </a>
            </li>
        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n\r\n        ");
            __builder.AddMarkupContent(58, @"<div class=""tab-content card"" id=""myClassicTabContentOrange"">
            <div class=""tab-pane fade active show"" id=""profile-classic-orange"" role=""tabpanel"" aria-labelledby=""profile-tab-classic-orange"">
                <p>
                  

                </p>
            </div>
            <div class=""tab-pane fade"" id=""follow-classic-orange"" role=""tabpanel"" aria-labelledby=""follow-tab-classic-orange"">
                <p>
                   
                </p>
            </div>
            <div class=""tab-pane fade"" id=""contact-classic-orange"" role=""tabpanel"" aria-labelledby=""contact-tab-classic-orange"">
                <p>
                   
                </p>
            </div>
            <div class=""tab-pane fade"" id=""awesome-classic-orange"" role=""tabpanel"" aria-labelledby=""awesome-tab-classic-orange"">
                <p>
                   
                </p>
            </div>
        </div>

    ");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 69 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\Admin.razor"
       

    public int UsersPage { get; set; } = 0;
    public List<YourSpace.Areas.Identity.MIdentityUser> Users { get; set; }

    [Inject] public ISUsersModeration SModeration { get; set; }

    protected override void OnInitialized()
    {
       // Users = SModeration.GetUsers(UsersPage);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<Admin> L { get; set; }
    }
}
#pragma warning restore 1591
