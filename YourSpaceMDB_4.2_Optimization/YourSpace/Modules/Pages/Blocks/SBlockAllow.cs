using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks.Models;
using YourSpace.Modules.Pages.Page;
using YourSpace.Services;

namespace YourSpace.Modules.Pages.Blocks
{
    public class SBlockAllow : ISBlocksAllow
    {

        private Dictionary<BlockTypes, AllowInfo> _blocksAllowInfo = new Dictionary<BlockTypes, AllowInfo>();
        private ISBlocks _sBlocks;
        ISPagesModifier _sPagesModifier;

        private MPageInfo _pageInfo = new MPageInfo();

        public SBlockAllow(ISBlocks sBlocks,IConfiguration configuration,ISPagesModifier sPagesModifier)
        {
            _sBlocks = sBlocks;
            _sPagesModifier = sPagesModifier;

            InitBlocksAllowInfo();
        }

        private void InitBlocksAllowInfo()
        {
            _blocksAllowInfo.Add(BlockTypes.Subscribe, new AllowInfo() { MaxAmount = 2 });
            _blocksAllowInfo.Add(BlockTypes.Like, new AllowInfo() { MaxAmount = 10 });
            _blocksAllowInfo.Add(BlockTypes.Group, new AllowInfo() { MaxAmount = 3 });
        }

        public List<MPageBlock> GetAllowBlocks(MPage page,MBlocksGroup group)
        {
            _pageInfo = _sPagesModifier.GetPageInfo(page.Id);
            List<MPageBlock> list = new List<MPageBlock>();
            foreach(var avaliableBlock in _sBlocks.AvaliableBlocks)
            {
                bool allow = AllowBlock(avaliableBlock, page, group);
                if(allow)
                {
                    list.Add(avaliableBlock.Value);
                }
            }
            return list;
        }


        private bool AllowBlock(KeyValuePair<BlockTypes,MPageBlock> pair, MPage page, MBlocksGroup toGroup)
        {
            BlockTypes blockType = pair.Key;
            MPageBlock checkBlock = pair.Value;

            bool depthAllow = CheckGroupDepth(checkBlock, toGroup, _pageInfo.MaxDepth);
            bool amountSummaryAllow = CheckSummaryAmmount(page, _pageInfo.MaxBlocks);

            bool blockCustomAllow = true;
            bool haveValidInfo = _blocksAllowInfo.TryGetValue(blockType, out AllowInfo blockAllowInfo);
            if(haveValidInfo)
            {
                blockCustomAllow = blockCustomAllow && CheckAmount(checkBlock, page, blockAllowInfo.MaxAmount);
            }

            bool allow = blockCustomAllow && depthAllow && amountSummaryAllow;
            return allow;
        }

        
        private bool CheckAmount(MPageBlock checkBlock, MPage page,int MaxAmount)
        {
            int amount = 0;

            void loop(MPageBlock block)
            {
                if (checkBlock.GetType() == block.GetType())
                {
                    amount++;
                }
            }
            page.LoopBlocks(loop);

            bool validAmount = amount < MaxAmount;
            return validAmount;
        }
        private bool CheckGroupDepth(MPageBlock checkBlock,MBlocksGroup toGroup,int maxDepth)
        {
            int depth = 0;
            if(checkBlock.GetType() == typeof(MGroupBlock))
            {
                depth = depthIteration(depth, toGroup);
                bool allow = maxDepth > depth;
                return allow;
            }
            return true;
        }
        private bool CheckSummaryAmmount(MPage page,int MaxSummaryBlocks)
        {
            int amount = 0;

            void loop(MPageBlock block)
            {
                if (typeof(MGroupBlock) != block.GetType())
                {
                    amount++;
                }
            }
            page.LoopBlocks(loop);

            return MaxSummaryBlocks > amount;
        }
        private int depthIteration(int depth, MBlocksGroup Group)
        {
            if (Group.Component.HaveRoot)
            {
                depth++;
                depthIteration(depth, Group.Component.Root.ParentGroup);
            }
            return depth;
        }
        protected struct AllowInfo
        {
            public int MaxAmount;
        }
    }

    
}
