using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.Pages.Blocks.Components;
using YourSpace.Modules.Pages.Blocks.Models;
using YourSpace.Modules.Pages.Blocks.ModifyComponents;
using YourSpace.Modules.Pages.Page;
using YourSpace.Services;

namespace YourSpace.Modules.Pages.Groups.ViewMode
{
    public class CGroupViewMode : ComponentBase
    {
        [Parameter] public MGroupBlock Root { get; set; }
        [Parameter] public MBlocksGroup Group{ get; set; }
        [Parameter] public CPage ComponentPage { get; set; }
        [Parameter] public bool AddEditInputs { get; set; }

        public bool HaveRoot { get
            {
                return Root != null;
            }
        }

        [Inject] protected ISGroupsView SGroups { get; set; }

        public List<RenderFragment> RenderedBlocksList { get { return RenderGroupContentArray(); } }

        
        public void DeleteGroup()
        {
            if(Root != null)
            {
                Root.ParentGroup.Component.RemoveBlock(Root);
            }
            else
            {
                ComponentPage.DeleteMainGroup(Group);
            }
            ComponentPage.SavePage();
        }

        public RenderFragment JoinList() => builder =>
        {
            var list = RenderedBlocksList;
            foreach (var r in list)
            {
                builder.AddContent(0, r);
            }
        };

        public virtual Task UpdateGridAsync()
        {
            return Task.CompletedTask;
        }

        public void RemoveBlock(MPageBlock block)
        {
            Group.Blocks.Remove(block);
            StateHasChanged();
        }

        public void AddBlock(MPageBlock block)
        {
             
            Group.AddBlock(block);
            ComponentPage.SavePage();
            StateHasChanged();
        }

        public void BlockEdited()
        {
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            Group.Component = this;
        }

        private RenderFragment RenderBlock(MPageBlock block,bool isGroup) => builder =>
        {
            if (isGroup)
            {
                MGroupBlock blockGroup = (MGroupBlock)block;
                MBlocksGroup group = blockGroup.ContainGroup;
                builder.AddContent(0, ComponentPage.RenderGroup(group,blockGroup));
            }
            else
            {
                Type type = block.GetBlazorComponentType();

                builder.OpenComponent(0, type);
                builder.AddAttribute(1, "Block", block);
                builder.CloseComponent();
            }
        };

        
        protected List<RenderFragment> RenderGroupContentArray()
        {
            var list = new List<RenderFragment>();
            foreach (var block in Group.Blocks)
            {
                var fragment = RenderContainer(block);
                list.Add(fragment);
            }
            return list;
        }

        protected RenderFragment RenderContainer(MPageBlock block) => builder =>
        {
            block.PageId = ComponentPage.PageId;
            block.ParentGroup = Group;
            block.ParentGroup.Component = this;

            bool isGroup = block.GetType().IsAssignableFrom(typeof(MGroupBlock));

            builder.OpenComponent<ContainerBlock>(0);
            RenderFragment Top = AddEditInputs && !isGroup ? RenderEditBlock(block) : null;
            builder.AddAttribute(1, "ChildContent", RenderBlock(block, isGroup));
            builder.AddAttribute(2, "TopFragment", Top);

            builder.CloseComponent();
        };

        protected RenderFragment RenderEditBlock(MPageBlock block) => builder =>
        {

            builder.OpenComponent<EditBlockOnPageDisplay>(0);
            builder.AddAttribute(1, "Block", block);
            builder.AddAttribute(2, "ComponentPage", ComponentPage);
            builder.CloseComponent();

        };
    }
}
