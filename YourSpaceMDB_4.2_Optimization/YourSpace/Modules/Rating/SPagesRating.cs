using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Modules.Cloner;
using YourSpace.Modules.ConfigurationModels;
using YourSpace.Modules.Pages.Page;
using YourSpace.Modules.ThingCounter;
using YourSpace.Services;

namespace YourSpace.Modules.Rating
{
    public class SPagesRating : ISPagesRating
    {

        public MCounterType RatingBy = new MCounterSubscribe();

        private ISUsers _sUsers;
        private ISThingCounter _sMarks;
        private ISPages _sPages;
        private IMemoryCache _cache;
        private UserManager<MIdentityUser> _userManager;
        private TimeSpan _pagesRatingTimeExperation;
        private static string _pagesRatingKey { get { return "PagesRating"; } }

        
        public SPagesRating(ISUsers sUsers,UserManager<MIdentityUser> userManager,
            ISThingCounter sMarks,ISPages sPages,IMemoryCache cache,IOptions<MCacheSettings> CacheOptions)
        {
            _sUsers = sUsers;
            _userManager = userManager;
            _sMarks = sMarks;
            _sPages = sPages;
            _cache = cache;

            int seconds = CacheOptions.Value.PagesRatingTimeExp;
            _pagesRatingTimeExperation = TimeSpan.FromSeconds(seconds);
        }

        public async Task<List<MPageInfo>> GetRating()
        {
            bool valid = _cache.TryGetValue(_pagesRatingKey, out List<MPageInfo> list);
            if(valid)
            {
                return list;
            }

            return await UpdateRating();
        }


        private async Task<Dictionary<string,int>> GetPagesMarks(List<MPageInfo> pages)
        {
            Dictionary<string, int> marks = new Dictionary<string, int>();
            foreach (var info in pages)
            {
                int amount = (await _sMarks.GetCounterAmountNotes(info.Id, RatingBy)).Count;
                marks.Add(info.Id, amount);
            }

            return marks;
        }

        private async Task<List<MPageInfo>> UpdateRating()
        {
            var pages = _sPages.GetAllPages();
            var dict = await GetPagesMarks(pages);

            pages.Sort(delegate( MPageInfo f, MPageInfo s)
            {
                int marksF = dict[f.Id];
                int marksS = dict[s.Id];
                return marksF.CompareTo(marksS);
            });

            _cache.Set(_pagesRatingKey, pages, new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = _pagesRatingTimeExperation
            });

            return pages;
        }

        
    }
}
