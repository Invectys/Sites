using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YourSpace.Areas.Identity;
using YourSpace.Modules.ThingCounter;

namespace YourSpace.Services
{       
    public interface ISThingCounter
    {
        public  Task Add(ClaimsPrincipal userClaims, string id, MCounterType type, string page = "");
        public  Task Add(MIdentityUser user, string id, MCounterType type, string page = "");
        public  Task Remove(ClaimsPrincipal userClaims, string id, MCounterType type);
        public  Task Remove(MIdentityUser user, string id, MCounterType type);
        public void RemoveAllWherePage(string pageId, MCounterType type);
        public  Task<List<MCounterNote>> GetUserThingNotes(ClaimsPrincipal userClaims, MCounterType type);
        public Task<List<MCounterNote>> GetUserThingNotes(MIdentityUser user, MCounterType type);
        public Task<List<MCounterNote>> GetCounterAmountNotes(string id, MCounterType type);
        public Task<List<MCounterNote>> GetCounterAmountNotesByPage(string page, MCounterType type);
        public  Task<bool> IsAdded(ClaimsPrincipal userClaims, string id, MCounterType type);
        public bool IsAdded(MIdentityUser user, string id, MCounterType type);
        public Task<MCounterNote> GetNote(ClaimsPrincipal userClaims, string id, MCounterType type);
        public MCounterNote GetNote(MIdentityUser user, string id, MCounterType type);
        
    }
}
