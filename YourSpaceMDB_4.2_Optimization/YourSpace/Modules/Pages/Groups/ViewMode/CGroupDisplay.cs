using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Groups.Models;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Modules.Pages.Groups.ViewMode
{
    public class CGroupDisplay : ComponentBase
    {
        [Parameter] public BlockGroupViewMode ViewMode { get; set; }
        [Parameter] public EventCallback<MSelectGroupClick> OnSelect { get; set; }

        public bool Selected { get; set; } = false;

        public void SetSelectState(bool state)
        {
            Selected = state;
        }
        public void Select()
        {
            OnSelect.InvokeAsync(new MSelectGroupClick() { Component = this, GroupView = ViewMode});
        }


    }
}
