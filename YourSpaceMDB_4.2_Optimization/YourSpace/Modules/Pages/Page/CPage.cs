using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Services;
using YourSpace.Modules.Pages.Groups.ModifyComponents;
using YourSpace.Modules.Pages.Groups.ViewMode;
using YourSpace.Modules.Pages.Blocks.ModifyComponents;
using YourSpace.Modules.Pages.Groups.Models;
using YourSpace.Modules.Pages.Blocks.Components;
using System.Text.RegularExpressions;
using YourSpace.Modules.Pages.Page.Services;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using YourSpace.Modules.Pages.Blocks.Models;

namespace YourSpace.Modules.Pages.Page
{
    public class CPage : ComponentBase
    {


        [Parameter] public string PageUrl { get; set; }
        [Parameter] public bool AddEditInputs { get; set; } = false;

        public int MaxMainGroups
        {
            get
            {
                return CurrentPageInfo.MaxMainGroups;
            }
        }

        public bool CanAddMainGroup { get { return MaxMainGroups > CurrentPage.MainBlockGroups.Count;  }  }
        public bool PageValid { get; set; }
        public MPage CurrentPage { get; set; }
        public MPageInfo CurrentPageInfo { get; set; }
        public string PageId { get; set; }

        [Inject] protected ISPagesUrl SPagesUrl { get; set; }
        [Inject] protected ISPagesModifier SPageModifier { get; set; }
        [Inject] protected ISPagesCasher SPagesCasher { get; set; }
        [Inject] protected ISModal SModal { get; set; }
        [Inject] protected ISGroupsView SGroups { get; set; }
        [Inject] protected IJSRuntime JSRuntime { get; set; }
        [Inject] protected NavigationManager NavigationManager  { get; set; }
        protected string BtnPannelClass { get { return IsVisibleBtnPannel ? "visible" : "invisible"; } }
        protected bool IsVisibleBtnPannel { get; set; } = true;

        


        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }
        protected ClaimsPrincipal User;
        protected bool PageOwner { get; set; } = false;

        public void SavePage()
        {
            SPagesCasher.SavePage(CurrentPage);
        }

        public void AddMainGroup(MBlocksGroup newGroup)
        {
            if(CanAddMainGroup)
            {
                CurrentPage.MainBlockGroups.Add(newGroup);
                SavePage();
                StateHasChanged();
            }
        }
        public void DeleteMainGroup(MBlocksGroup group)
        {
            CurrentPage.MainBlockGroups.Remove(group);
            SavePage();
            StateHasChanged();
        }
        
        
        

        public void HideBtnPannel()
        {
            IsVisibleBtnPannel = false;
            StateHasChanged();
        }

        public void ShowBtnPannel(bool update = true)
        {
            IsVisibleBtnPannel = true;
            if(update)
            {
                StateHasChanged();
            }
        }

        public RenderFragment RenderGroup(MBlocksGroup group,MGroupBlock root = null) => builder =>
        {
            BlockGroupViewMode groupViewMode = group.ViewMode;
            MGroupInfo GroupInfo = SGroups.GetInfo(groupViewMode);
            Type groupVMComponent = GroupInfo.ViewModeComponent;
            builder.OpenComponent(0, groupVMComponent);
            builder.AddAttribute(1, "Group", group);
            builder.AddAttribute(2, "AddEditInputs", AddEditInputs);
            builder.AddAttribute(3, "ComponentPage", this);
            builder.AddAttribute(4, "Root", root);
            builder.CloseComponent();

            if (AddEditInputs)
            {
                builder.OpenComponent<ModifyGroupOnPageDisplay>(4);
                builder.AddAttribute(5, "ComponentPage", this);
                builder.AddAttribute(6, "Group", group);
                builder.CloseComponent();
            }
        };


        protected RenderFragment RenderPage() => builder =>
        {
            for (int i = 0; i < CurrentPage.MainBlockGroups.Count;i++)
            {
                var group = CurrentPage.MainBlockGroups[i];
                builder.AddContent(0, RenderGroup(group));
            }

            if (AddEditInputs && CanAddMainGroup)
            {
                builder.OpenComponent<CreateNewGroupOnPageDisplay>(1);
                builder.AddAttribute(2, "ComponentPage", this);
                builder.CloseComponent();
            }
        };

        protected override async Task OnInitializedAsync()
        {
            User = (await authenticationStateTask).User;

            PageValid = SPagesUrl.GetPageId(PageUrl, out MUrlCompare to);
            if (PageValid)
            {
                PageId = to.PageId;
                MPage page = await SPagesCasher.TryGetPage(PageId);
                CurrentPage = page;
                CurrentPageInfo = SPageModifier.GetPageInfo(PageId);
                PageOwner = User.Identity.IsAuthenticated ? await SPageModifier.UserOwnPage(User, PageId) : false;
            }
            else
            {
                NavigationManager.NavigateTo("notfound");
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            //JSRuntime.InvokeVoidAsync("InitAudioPlayers");
        }

    }
}
