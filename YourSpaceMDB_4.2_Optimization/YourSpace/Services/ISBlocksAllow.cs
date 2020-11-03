//Предназначен для проверки текущей возможности использования блока на странице 
//Содержит проверки использования блоков на странцее
//Проверяет количество всех блоков и запрещает их добавление при максимальном колличестве
//Проверяет глубины групп
//Задает кастомные ограничения для конкретного типа блока

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Services
{
    public interface ISBlocksAllow
    {
        public List<MPageBlock> GetAllowBlocks(MPage page, MBlocksGroup group);
    }
}
