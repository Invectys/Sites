using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.Pages.Blocks.Models;

namespace YourSpace.Modules.Pages.Page
{
    public class MPage
    {
        public string Id { get; set; }
        public MPageCardBlock DisplayCard { get; set; }
        public List<MBlocksGroup> MainBlockGroups { get; set; }

        public void LoopBlocks(Action<MPageBlock> loopAction)
        {
            foreach(var g in MainBlockGroups)
            {
                //loopAction.Invoke(new MGroupBlock());
                g.LoopBlocks(loopAction);
            }
        }

        public MPage()
        {
            MainBlockGroups = new List<MBlocksGroup>();
        }
        
    }


    
}
