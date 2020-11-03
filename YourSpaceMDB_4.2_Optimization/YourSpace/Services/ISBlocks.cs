//Сервис предназначен для кастомизации блоков используемых пользователем
//определяет все доступные блоки для пользователя 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks;

namespace YourSpace.Services
{
    public interface ISBlocks
    {
        public Dictionary<BlockTypes, MPageBlock> AvaliableBlocks { get; }
    }
}
