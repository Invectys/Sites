using Microsoft.AspNetCore.Components.Authorization;
using YourSpace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using YourSpace.Areas.Identity;
using System.Security.Claims;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using YourSpace.Modules.ConfigurationModels;

namespace YourSpace.Modules.Pages.Page
{
    public class SPagesCasher : ISPagesCasher
    {
        private readonly ISPageStream _sPageStream;
        private readonly IMemoryCache _memoryCache;
        private IOptions<MCacheSettings> _cacheOptions;

        public SPagesCasher(ISPageStream sPageStream, IMemoryCache memoryCache,IOptions<MCacheSettings> cacheOptions)
        {
            _sPageStream = sPageStream;
            _memoryCache = memoryCache;
            _cacheOptions = cacheOptions;
        }

        public void ClearPageCache(string pageId)
        {
            _memoryCache.Remove(pageId);
        }

        public async Task<MPage> TryGetPage(string pageName)
        {
            MPage page = default;
            bool have = LoadPageFromCashe(out page, pageName);
            if(!have)
            {
                page = await _sPageStream.ReadPage(pageName);
                if(page != null)
                {
                    CashePage(page);
                }
            }

            page.DisplayCard.PageId = page.Id;

            return page;
        }
       

        public void SetPage(MPage page)
        {
            CashePage(page);
            _sPageStream.WritePage(page);
        }

        public void SavePage(MPage page)
        {
            CashePage(page);
            _sPageStream.WritePage(page);
        }

        private void CashePage(MPage page)
        {
            _memoryCache.Set(page.Id, page, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheOptions.Value.PagesRatingTimeExp)
            });
        }

        private bool LoadPageFromCashe(out MPage page,string pageName)
        {
            page = null;
            bool have = _memoryCache.TryGetValue(pageName, out page);
            return have;
        }
    }
}
