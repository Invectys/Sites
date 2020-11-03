using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Services
{
    public interface ISPagesCasher
    {
        public void SavePage(MPage page);
        public Task<MPage> TryGetPage(string pageName);
        public void SetPage(MPage page);
        public void ClearPageCache(string pageId);
    }
}
