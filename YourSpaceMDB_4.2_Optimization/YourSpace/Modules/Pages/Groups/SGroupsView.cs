using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Groups.Models;
using YourSpace.Modules.Pages.Groups.ViewMode;
using YourSpace.Modules.Pages.Page;
using YourSpace.Services;

namespace YourSpace.Modules.Pages.Groups
{
    public class SGroupsView : ISGroupsView
    {

        private Dictionary<BlockGroupViewMode,MGroupInfo> _avaliableGroups = new Dictionary<BlockGroupViewMode, MGroupInfo>();

        public SGroupsView()
        {
            FillAvaliableGroups();
        }

        public Dictionary<BlockGroupViewMode,MGroupInfo> GetGroups()
        {
            return _avaliableGroups;
        }

        public MGroupInfo GetInfo(BlockGroupViewMode group)
        {
            return _avaliableGroups[group];
        }

        private void FillAvaliableGroups()
        {
            MGroupInfo forward1= new MGroupInfo();
            MBlockCssDesigner designer1 = new MBlockCssDesigner();
            designer1.CssClassStr = "forward1";
            forward1.GroupDesigner = designer1;
            forward1.ViewModeComponent = typeof(GroupViewModeForward1);
            forward1.ViewModeComponentDisplay = typeof(GroupVMForward1Display);
            _avaliableGroups.Add(BlockGroupViewMode.Forward1, forward1);


            MGroupInfo table1 = new MGroupInfo();
            MBlockCssDesigner designer2 = new MBlockCssDesigner();
            designer2.CssClassStr = "col-6 px-0";
            table1.GroupDesigner = designer2;
            table1.ViewModeComponent = typeof(GroupViewModeTable1);
            table1.ViewModeComponentDisplay = typeof(GroupVMTable1Display);
            _avaliableGroups.Add(BlockGroupViewMode.Table1, table1);


            MGroupInfo table3 = new MGroupInfo();
            MBlockCssDesigner designer3 = new MBlockCssDesigner();
            designer3.CssClassStr = "col-4 px-0 overflow-hidden mh-table3block";
            table3.GroupDesigner = designer3;
            table3.ViewModeComponent = typeof(GroupViewModeTable3);
            table3.ViewModeComponentDisplay = typeof(GroupViewModeTable3Display);
            _avaliableGroups.Add(BlockGroupViewMode.Table3, table3);

        }
    }
}
