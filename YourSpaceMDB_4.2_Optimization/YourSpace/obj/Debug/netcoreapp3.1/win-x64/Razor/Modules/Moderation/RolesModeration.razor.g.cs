#pragma checksum "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bba1300aea809b4a737001e4acdc0fc2c7caa16e"
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
#line 1 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
using YourSpace.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
           [Authorize(Roles = "Admin")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/moderation/roles")]
    public partial class RolesModeration : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "md-form mt-0");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "input");
            __builder.AddAttribute(4, "class", "form-control");
            __builder.AddAttribute(5, "type", "text");
            __builder.AddAttribute(6, "placeholder", "Search");
            __builder.AddAttribute(7, "aria-label", "Search");
            __builder.AddAttribute(8, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 10 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                         _filterName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _filterName = __value, _filterName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n");
            __builder.OpenElement(12, "button");
            __builder.AddAttribute(13, "class", "btn btn-primary");
            __builder.AddAttribute(14, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                                          SearchBtn

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(15, 
#nullable restore
#line 12 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                                                      L["Search/Reload"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n\r\n");
            __builder.OpenElement(17, "table");
            __builder.AddAttribute(18, "id", "dtBasicExample");
            __builder.AddAttribute(19, "class", "table table-striped table-bordered table-sm");
            __builder.AddAttribute(20, "cellspacing", "0");
            __builder.AddAttribute(21, "width", "100%");
            __builder.AddMarkupContent(22, "\r\n    ");
            __builder.OpenElement(23, "thead");
            __builder.AddMarkupContent(24, "\r\n        ");
            __builder.OpenElement(25, "tr");
            __builder.AddMarkupContent(26, "\r\n            ");
            __builder.OpenElement(27, "th");
            __builder.AddAttribute(28, "class", "th-sm");
            __builder.AddMarkupContent(29, "\r\n                ");
            __builder.AddContent(30, 
#nullable restore
#line 18 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                 L["Role name"]

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(31, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n            ");
            __builder.OpenElement(33, "th");
            __builder.AddAttribute(34, "class", "th-sm");
            __builder.AddMarkupContent(35, "\r\n                ");
            __builder.AddContent(36, 
#nullable restore
#line 21 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                 L["Max pages"]

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(37, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n            ");
            __builder.OpenElement(39, "th");
            __builder.AddAttribute(40, "class", "th-sm");
            __builder.AddMarkupContent(41, "\r\n                ");
            __builder.AddContent(42, 
#nullable restore
#line 24 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                 L["Edit"]

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(43, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n            ");
            __builder.OpenElement(45, "th");
            __builder.AddAttribute(46, "class", "th-sm");
            __builder.AddMarkupContent(47, "\r\n                ");
            __builder.AddContent(48, 
#nullable restore
#line 27 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                 L["Delete"]

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(49, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n    ");
            __builder.OpenElement(53, "tbody");
            __builder.AddMarkupContent(54, "\r\n");
#nullable restore
#line 32 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
         foreach (var role in _rolesBook.GetCurrentPage())
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(55, "            ");
            __builder.OpenElement(56, "tr");
            __builder.AddMarkupContent(57, "\r\n                ");
            __builder.OpenElement(58, "td");
            __builder.AddContent(59, 
#nullable restore
#line 35 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                     role.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n                ");
            __builder.OpenElement(61, "td");
            __builder.AddContent(62, 
#nullable restore
#line 36 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                     role.MaxPagesAmount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n                ");
            __builder.OpenElement(64, "td");
            __builder.AddMarkupContent(65, "\r\n                    ");
            __builder.OpenElement(66, "button");
            __builder.AddAttribute(67, "class", "btn btn-primary");
            __builder.AddAttribute(68, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 38 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                                                              ()=> { EditRole(role); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(69, 
#nullable restore
#line 38 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                                                                                         L["Edit"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(71, "\r\n                ");
            __builder.OpenElement(72, "td");
            __builder.AddMarkupContent(73, "\r\n");
#nullable restore
#line 41 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                     if(SRoles.CanDeleteRole(role.Name))
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(74, "                        ");
            __builder.OpenElement(75, "button");
            __builder.AddAttribute(76, "class", "btn btn-danger");
            __builder.AddAttribute(77, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 43 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                                                                 ()=> { DeleteRole(role); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(78, 
#nullable restore
#line 43 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                                                                                              L["Delete"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\r\n");
#nullable restore
#line 44 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(80, "                        ");
            __builder.OpenElement(81, "span");
            __builder.AddContent(82, 
#nullable restore
#line 47 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                               L["You cant delete basic role"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(83, "\r\n");
#nullable restore
#line 48 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(84, "                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n");
#nullable restore
#line 51 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(87, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "\r\n");
            __builder.OpenElement(90, "button");
            __builder.AddAttribute(91, "class", "btn btn-primary");
            __builder.AddAttribute(92, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 54 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                                          CreateNewRole

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(93, 
#nullable restore
#line 54 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                                                          L["Create new role"]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\r\n\r\n");
            __builder.OpenComponent<YourSpace.Modules.ComponentsView.Pagination>(95);
            __builder.AddAttribute(96, "Next", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 56 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                  _rolesBook.NextPage

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(97, "Previous", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 56 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
                                                 _rolesBook.PreviousPage

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 61 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Modules\Moderation\RolesModeration.razor"
 

    [Inject] protected ISModal SModal { get; set; }
    [Inject] protected ISRoles SRoles { get; set; }
    [Inject] protected Microsoft.AspNetCore.Identity.RoleManager<MIdentityRole> RoleManager { get; set; }

    private string _filterName = "";
    private BookViewer<MIdentityRole> _rolesBook;
    private List<MIdentityRole> _rolesList = new List<MIdentityRole>();

    protected override void OnInitialized()
    {
        LoadRoles();
    }

    void LoadRoles()
    {
        _rolesList = RoleManager.Roles.Where(r=>r.Name.Contains(_filterName)).ToList();
        _rolesBook = new BookViewer<MIdentityRole>(_rolesList, 5);
        StateHasChanged();
    }
    void EditRole(MIdentityRole role)
    {
        var mp = new ModalParameters();
        mp.Add("Role", role);

        SModal.Show<EditRole>(L["Edit role"], mp, ViewStorageApp.EditRoleModalOptions, RoleEdited);
    }

    void RoleEdited(ModalResult result)
    {
        if (!result.Cancelled)
        {
            LoadRoles();
        }
    }

    void CreateNewRole()
    {
        SModal.Show<CreateNewRole>(L["New Role"], new ModalParameters(), RoleCreated);
    }

    void RoleCreated(ModalResult result)
    {
        if (!result.Cancelled)
        {
            LoadRoles();
        }
    }

    void DeleteRole(MIdentityRole role)
    {
        var mp = new ModalParameters();
        mp.Add("Role", role.Name);
        SModal.Show<DeleteRole>(L["Delete role"], mp, ViewStorageApp.EditRoleModalOptions, RoleDeleted);
    }

    void RoleDeleted(ModalResult result)
    {
        if (!result.Cancelled)
        {
            LoadRoles();
        }
    }

    void SearchBtn()
    {
        LoadRoles();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<RolesModeration> L { get; set; }
    }
}
#pragma warning restore 1591
