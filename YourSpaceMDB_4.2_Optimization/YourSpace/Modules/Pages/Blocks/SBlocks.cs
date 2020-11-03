using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks.Models;
using YourSpace.Services;

namespace YourSpace.Modules.Pages.Blocks
{
    public class SBlocks : ISBlocks
    {
        private Dictionary<BlockTypes, MPageBlock> _avaliableBlocks = new Dictionary<BlockTypes, MPageBlock>();

        public Dictionary<BlockTypes, MPageBlock> AvaliableBlocks
        {
            get
            {
                return _avaliableBlocks;
            }
        }

        public SBlocks()
        {
            _avaliableBlocks.Add(BlockTypes.Image, new MImageBlock());
            _avaliableBlocks.Add(BlockTypes.Text, new MTextBlock());
            _avaliableBlocks.Add(BlockTypes.Subscribe, new MSubscribeBlock());
            _avaliableBlocks.Add(BlockTypes.Like, new MLikeBlock());
            //_avaliableBlocks.Add(BlockTypes.Music, new MMusicBlock());
            _avaliableBlocks.Add(BlockTypes.Group, new MGroupBlock());
        }
    }

    public enum BlockTypes
    {
        Image,
        Text,
        PageCard,
        Email1,
        Subscribe,
        Like,
        Music,
        Group
    }

    public enum BlockCategories
    {
        Social,
        Marks,
        Other
    }
}
