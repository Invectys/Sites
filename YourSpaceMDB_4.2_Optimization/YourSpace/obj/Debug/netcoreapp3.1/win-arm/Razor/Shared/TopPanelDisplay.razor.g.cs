#pragma checksum "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Shared\TopPanelDisplay.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b7943b4573aacad8b743ea176aaf3fb471bc69d"
// <auto-generated/>
#pragma warning disable 1591
namespace YourSpace.Shared
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
    public partial class TopPanelDisplay : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Roles", "Admin");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(3, "\r\n    ");
                __builder2.AddMarkupContent(4, "<a class=\"p-2 text-dark\" href=\"/moderation\">Admin</a>\r\n");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(6);
            __builder.AddAttribute(7, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(8, "\r\n        ");
                __builder2.OpenComponent<YourSpace.Modules.UserProfile.Compoents.AccountLink>(9);
                __builder2.AddAttribute(10, "Class", "p-2 text-dark");
                __builder2.AddAttribute(11, "UserName", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 7 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Shared\TopPanelDisplay.razor"
                                                      context.User.Identity.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(13, 
#nullable restore
#line 7 "C:\Users\qzwse\source\repos\YourSpaceMDB_4.2\YourSpace\Shared\TopPanelDisplay.razor"
                                                                                   context.User.Identity.Name

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(14, "!");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(15, "\r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591