#pragma checksum "C:\Users\qzwse\source\repos\YourSpace\YourSpace\Modules\Pages\Blocks\SetupPageBlock - Copy.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7187c6afe0f0ebc6913f3a42037eef42399747a6"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace YourSpace.Modules.Pages.Blocks
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Page;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Groups;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Groups.ViewMode;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace.Modules.Pages.Blocks.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace.Modules.DataWorker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace.Modules.Cloner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace.Modules.Galary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace.Modules.FileUpload;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using YourSpace.Modules.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\_Imports.razor"
using BlazorInputFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\Modules\Pages\Blocks\SetupPageBlock - Copy.razor"
using YourSpace.Modules.ModalWindow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\Modules\Pages\Blocks\SetupPageBlock - Copy.razor"
using YourSpace.Attributes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\Modules\Pages\Blocks\SetupPageBlock - Copy.razor"
using System.Reflection;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\Modules\Pages\Blocks\SetupPageBlock - Copy.razor"
using YourSpace.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\Modules\Pages\Blocks\SetupPageBlock - Copy.razor"
using YourSpace.Modules.Pages.Blocks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\Modules\Pages\Blocks\SetupPageBlock - Copy.razor"
using Microsoft.AspNetCore.Components.CompilerServices;

#line default
#line hidden
#nullable disable
    public partial class SetupPageBlock___Copy : CSetupPageBlock
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "C:\Users\qzwse\source\repos\YourSpace\YourSpace\Modules\Pages\Blocks\SetupPageBlock - Copy.razor"
 
    [Parameter] public EventCallback eventValueChanged { get; set; }

    public RenderFragment Render<T>(PropertyInfo property) where T : ComponentBase  => builder =>
    {
        builder.OpenComponent(0,typeof(T));
        var val = property.GetValue(Block);
        builder.AddAttribute(1, "Value", val);
        builder.AddAttribute(2, "ValueChanged",
            RuntimeHelpers.TypeCheck<EventCallback<string>>
            (
                EventCallback.Factory.Create<string>
                (this, EventCallback.Factory.CreateInferred
                (this, __value => { property.SetValue(Block, __value); ValueChanged();  },
                (string)property.GetValue(Block)))
            )
        );


        var constant = System.Linq.Expressions.Expression.Constant(Block, Block.GetType());
        var exp = System.Linq.Expressions.MemberExpression.Property(constant, property);
        var lamb = System.Linq.Expressions.Expression.Lambda<Func<string>>(exp);
        builder.AddAttribute(4, "ValueExpression", lamb);

        builder.CloseComponent();
    };

    private void ValueChanged()
    {
        if(eventValueChanged.HasDelegate)
        {
            eventValueChanged.InvokeAsync(this);
        }
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
