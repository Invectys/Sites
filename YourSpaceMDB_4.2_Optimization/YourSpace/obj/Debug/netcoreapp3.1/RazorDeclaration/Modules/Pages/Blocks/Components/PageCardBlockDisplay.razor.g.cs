#pragma checksum "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\Modules\Pages\Blocks\Components\PageCardBlockDisplay.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70c367cc7dba01dc3bb909416f1e2e12389a1ade"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace YourSpace.Modules.Pages.Blocks.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.ModalWindow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Page;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Page.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Page.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Page.ModifyComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Blocks.ModifyComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Blocks.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Blocks.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Blocks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Groups.ModifyComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Groups.ViewMode;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Groups.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.ThingCounter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.ThingCounter.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.DataWorker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Cloner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Gallery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Gallery.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.FileUpload;

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Moderation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Moderation.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.ComponentsView;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Lister;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Image;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.UserProfile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.UserProfile.Compoents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using YourSpace.Modules.Music;

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\_Imports.razor"
using BlazorInputFile;

#line default
#line hidden
#nullable disable
    public partial class PageCardBlockDisplay : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\Modules\Pages\Blocks\Components\PageCardBlockDisplay.razor"
 
    [Parameter] public EventCallback OnClick { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
