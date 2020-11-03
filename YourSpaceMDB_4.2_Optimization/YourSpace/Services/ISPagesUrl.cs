using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Page.Services;

namespace YourSpace.Services
{
    public interface ISPagesUrl
    {
        public Task<string> GetPageUrlEdit(string Id);
        public Task<string> GetPageUrl(string Id);
        public List<MUrlCompare> GetAllUrls();
        public bool GetPageId(string url, out MUrlCompare to);
        public string CreatePageUrl(string url);
        public bool TryCreatePageUrl(string url, out string id);
        public Task DeleteUrl(string PageId);
    }
}
