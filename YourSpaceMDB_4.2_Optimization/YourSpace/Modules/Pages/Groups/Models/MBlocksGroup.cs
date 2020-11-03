using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.Pages.Blocks.Models;
using YourSpace.Modules.Pages.Groups.Models;
using YourSpace.Modules.Pages.Groups.ViewMode;

namespace YourSpace.Modules.Pages.Page
{
    [Serializable]
    public class MBlocksGroup
    {
        public BlockGroupViewMode ViewMode { get; set; }
        public List<MPageBlock> Blocks { get; set; } = new List<MPageBlock>();

        [XmlIgnore]
        public CGroupViewMode Component { get; set; } = new CGroupViewMode();

        public void AddBlock(MPageBlock block)
        {
            block.UniqueId = Guid.NewGuid().ToString();
            block.ParentGroup = this;
            Blocks.Add(block);
        }

        public void LoopBlocks(Action<MPageBlock> loopAction)
        {
            foreach(var block in Blocks)
            {
                loopAction.Invoke(block);
                if (block.GetType() == typeof(MGroupBlock))
                {
                    MGroupBlock childGroup = (MGroupBlock)block;
                    childGroup.ContainGroup.LoopBlocks(loopAction);
                }
                
            }
        }
    }

    public enum BlockGroupViewMode
    {
        Forward1,
        Table1,
        Table3
    }

   

    
}
