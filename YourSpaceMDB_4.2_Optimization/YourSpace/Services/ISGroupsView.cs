//Сервис для регистрации Видов(групп) страницы то есть (1 столбец 2 или 3 и тд)
//Предназначен для локальной кастомизации вида группы

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Groups.Models;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Services
{
    public interface ISGroupsView
    {
        public Dictionary<BlockGroupViewMode, MGroupInfo> GetGroups();
        public MGroupInfo GetInfo(BlockGroupViewMode group);
    }
}
