using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using YourSpace.Data;
using YourSpace.Services;

namespace YourSpace.Modules.Pages.Page.Services
{
    public class SPagesUrl : ISPagesUrl
    {
        private readonly ISPagesCasher _sPagesCacher;
        private readonly ApplicationDbContext _dbContext;

        public SPagesUrl(ISPagesCasher sPagesCacher,ApplicationDbContext dbContext)
        {
            _sPagesCacher = sPagesCacher;
            _dbContext = dbContext;
        }

        public async Task<string> GetPageUrlEdit(string Id)
        {
            return (await GetPageUrl(Id)) + "/edit";
        }

        public async Task<string> GetPageUrl(string Id)
        {
            var to = await _dbContext.PagesUrlToId.FirstOrDefaultAsync(n => n.PageId == Id);
            return "/" + to.Url;
        }
        public bool GetPageId(string url,out MUrlCompare to)
        {
            to = _dbContext.PagesUrlToId.Find(url);
            return to != null;
        }
        public List<MUrlCompare> GetAllUrls()
        {
            return _dbContext.PagesUrlToId.ToList();
        }
        public string CreatePageUrl(string url)
        {
            var to = new MUrlCompare();
            to.PageId = Guid.NewGuid().ToString();
            to.Url = url;
            _dbContext.PagesUrlToId.Add(to);
            _dbContext.SaveChanges();
            return to.PageId;
        }
        public bool TryCreatePageUrl(string url,out string id)
        {
            var note = _dbContext.PagesUrlToId.FirstOrDefault(n => n.Url == url);
            if(note == null)
            {
                id = CreatePageUrl(url);
                return true;
            }
            id = "";
            return false;
        }

        public async Task DeleteUrl(string PageId)
        {
            var to = _dbContext.PagesUrlToId.FirstOrDefault(n => n.PageId == PageId);
            _dbContext.PagesUrlToId.Remove(to);
            await _dbContext.SaveChangesAsync();
        }
       

    }

    public class MUrlCompare
    {
        [Key]
        public string Url { get; set; }

        public string PageId { get; set; }
    }
}
