#pragma checksum "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\Modules\Pages\Groups\ViewMode\GroupViewModeTable3.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f85549b314c6cb094559a5bc3a6a7a04fd825b73"
// <auto-generated/>
#pragma warning disable 1591
namespace YourSpace.Modules.Pages.Groups.ViewMode
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
    public partial class GroupViewModeTable3 : CGroupViewMode
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "row" + " m-auto" + " " + (
#nullable restore
#line 3 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\Modules\Pages\Groups\ViewMode\GroupViewModeTable3.razor"
                         HaveRoot ? "" : Class

#line default
#line hidden
#nullable disable
            ) + " ");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenComponent<YourSpace.Modules.Gallery.GalleryGrid>(3);
            __builder.AddAttribute(4, "Options", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<YourSpace.Modules.Gallery.Models.GalleryOptions>(
#nullable restore
#line 4 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\Modules\Pages\Groups\ViewMode\GroupViewModeTable3.razor"
                                              GaleryOptions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(6, "\r\n");
#nullable restore
#line 5 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\Modules\Pages\Groups\ViewMode\GroupViewModeTable3.razor"
         foreach(var container in RenderedBlocksList)
        { 

#line default
#line hidden
#nullable disable
                __builder2.AddContent(7, "            ");
                __builder2.OpenComponent<YourSpace.Modules.Gallery.GalleryGridElement>(8);
                __builder2.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(10, "\r\n                ");
                    __builder3.AddContent(11, 
#nullable restore
#line 8 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\Modules\Pages\Groups\ViewMode\GroupViewModeTable3.razor"
                 container

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddMarkupContent(12, "\r\n            ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(13, "\r\n");
#nullable restore
#line 10 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\Modules\Pages\Groups\ViewMode\GroupViewModeTable3.razor"
        }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(14, "    ");
            }
            ));
            __builder.AddComponentReferenceCapture(15, (__value) => {
#nullable restore
#line 4 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\Modules\Pages\Groups\ViewMode\GroupViewModeTable3.razor"
                       _galleryGrid = (YourSpace.Modules.Gallery.GalleryGrid)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(16, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 15 "C:\Users\qzwse\Desktop\YourSpaceMDB_4.2_Optimization\YourSpace\Modules\Pages\Groups\ViewMode\GroupViewModeTable3.razor"
 

    public string Class { get; set; } = "col-sm-12 col-md-12 px-0 col-lg-12 col-xl-9";

    private GalleryOptions GaleryOptions;
    private GalleryGrid _galleryGrid;

    public override async Task UpdateGridAsync()
    {
        await _galleryGrid.UpdateGrid();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        GaleryOptions = new GalleryOptions() { GalleryId = "gallery" + Guid.NewGuid().ToString(),ColumnsClass= "gallery-size-3" };
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
