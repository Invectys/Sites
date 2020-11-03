using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Data;
using YourSpace.Modules.ThingCounter.Components;
using YourSpace.Pages;
using YourSpace.Services;

namespace YourSpace.Modules.ThingCounter
{
    public class SThingCounter : ISThingCounter
    {

        private ApplicationDbContext _dbContext;
        private UserManager<MIdentityUser> _userManager;
        private IMemoryCache _memoryCache;
        private TimeSpan DefaultCasheLifeTime = TimeSpan.FromSeconds(4);

        private List<MCounterType> _counterTypes = new List<MCounterType>();

        public SThingCounter(ApplicationDbContext dbContext, UserManager<MIdentityUser> userManager, IMemoryCache memoryCache)

        {
            _dbContext = dbContext;
            _userManager = userManager;
            _memoryCache = memoryCache;
        }

        private DbSet<MCounterNote> GetDbByType(MCounterType type)
        {
            if (type.IsSubscribe)
            {
                return _dbContext.Subscribe;
            }
            else if (type.IsLike)
            {
                return _dbContext.Like;
            }

            return null;
        }


        public async Task Add(ClaimsPrincipal userClaims, string id, MCounterType type, string page = "")
        {
            var user = await _userManager.GetUserAsync(userClaims);
            await Add(user, id, type, page);
        }
        public async Task Add(MIdentityUser user, string id, MCounterType type,string page = "")
        {
            bool isSubscribed = IsAdded(user, id, type);
            if (!isSubscribed)
            {
                MCounterNote sub = new MCounterNote() {UserId = user.Id, DistId = id, Page = page };
                GetDbByType(type).Add(sub);
                await _dbContext.SaveChangesAsync();
            }
        }


        //Unsubscribe user from page
        public async Task Remove(ClaimsPrincipal userClaims, string id, MCounterType type)
        {
            var user = await _userManager.GetUserAsync(userClaims);
            await Remove(user, id, type);
        }
        public async Task Remove(MIdentityUser user, string id, MCounterType type)
        {
            var sub = GetNote(user, id, type);
            bool isSubscribed = sub != null;
            if (isSubscribed)
            {
                GetDbByType(type).Remove(sub);
                await _dbContext.SaveChangesAsync();
            }
        }
        public void RemoveAllWherePage(string pageId, MCounterType type)
        {
            var db = GetDbByType(type);
            var list = db.Where(n => n.Page == pageId);
            db.RemoveRange(list);
        }

        //User Subscribe
        public async Task<List<MCounterNote>> GetUserThingNotes(ClaimsPrincipal userClaims, MCounterType type)
        {
            var user = await _userManager.GetUserAsync(userClaims);
            return await GetUserThingNotes(user, type);
        }
        public async Task<List<MCounterNote>> GetUserThingNotes(MIdentityUser user, MCounterType type)
        {
            var list = await GetDbByType(type).Where(n => n.UserId == user.Id).ToListAsync();
            return list;
        }
        //Page Subscri-Bers
        public async Task<List<MCounterNote>> GetCounterAmountNotes(string id, MCounterType type)
        {
            var list = await GetDbByType(type).Where(n => n.DistId == id).ToListAsync();
            return list;
        }
        public async Task<List<MCounterNote>> GetCounterAmountNotesByPage(string page, MCounterType type)
        {
            var list = await GetDbByType(type).Where(n => n.Page == page).ToListAsync();
            return list;
        }

        //User subscrib-ED on page ?
        public async Task<bool> IsAdded(ClaimsPrincipal userClaims, string id, MCounterType type)
        {
            var user = await _userManager.GetUserAsync(userClaims);
            return IsAdded(user, id, type);
        }
        public bool IsAdded(MIdentityUser user, string id, MCounterType type)
        {
            var isSub = GetNote(user, id, type) != null;
            return isSub;
        }


        //Get subscribe note
        public async Task<MCounterNote> GetNote(ClaimsPrincipal userClaims, string id, MCounterType type)
        {
            var user = await _userManager.GetUserAsync(userClaims);
            return GetNote(user, id, type);
        }
        public MCounterNote GetNote(MIdentityUser user, string id, MCounterType type)
        {
            var sub = GetDbByType(type).FirstOrDefault(n => n.DistId == id && n.UserId == user.Id);
            return sub;
        }

        
    }
}
