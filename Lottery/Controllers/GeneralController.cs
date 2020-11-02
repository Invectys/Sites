using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lottery.Data;
using Lottery.Models;
using Lottery.Models.Social;
using Lottery.Other;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;


namespace Lottery.Controllers
{
    public class GeneralController : Controller
    {
        SocialDbContext _socialDb;
        FileControl _fileControl;
        IHttpClientFactory _httpClientFactory;

  
        public GeneralController(FileControl fileControl,IHttpClientFactory httpClientFactory,SocialDbContext SocialDb)
        {
            _fileControl = fileControl;
            _httpClientFactory = httpClientFactory;
            _socialDb = SocialDb;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetImageGalary()
        {
            string person = User.Identity.Name;
            List<string> list = _fileControl.GetFileNames(_fileControl.getPersonalResourcesPathWithRoot() + "Pictures/" + person + "/");
            return Content(JsonConvert.SerializeObject(list));
        }

        [HttpPost]
        public IActionResult GetFileGalary()
        {
            string person = User.Identity.Name;
            List<string> list = _fileControl.GetFileNames(_fileControl.getPersonalResourcesPathWithRoot() + "Files/" + person + "/");
            return Content(JsonConvert.SerializeObject(list));
        }

        [HttpPost]
        public IActionResult GetCommunityFileGalary()
        {
            string person = User.Identity.Name;
            List<string> list = _fileControl.GetFileNames(_fileControl.getCommunityPathWithRoot()+"Resources/Files/");
            return Content(JsonConvert.SerializeObject(list));
        }
        [HttpPost]
        public IActionResult GetCommunityImageGalary()
        {
            string person = User.Identity.Name;
            List<string> list = _fileControl.GetFileNames(_fileControl.getCommunityPathWithRoot() + "Resources/Images/");
            return Content(JsonConvert.SerializeObject(list));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LikeAsync(string To)
        {
            string From = HttpContext.User.Identity.Name;

            LikeAction NewLike = new LikeAction(From, To);
            IQueryable<LikeAction> UserLikes = _socialDb.Likes.Where(i => i.From == From);
            bool Contains = UserLikes.FirstOrDefault(i => i.To == To) != null;
            if (!Contains)
            {
                _socialDb.Likes.Add(NewLike);
                
                LikeList count = _socialDb.ObjectLikes.FirstOrDefault(p => p.Object == To);
                if (count == null)
                {
                    count = _socialDb.ObjectLikes.Add(new LikeList(To,1)).Entity;
                }
                else
                {
                    count.Likes++;
                    _socialDb.ObjectLikes.Update(count);
                }
                
                
                

                await _socialDb.SaveChangesAsync();
                return StatusCode(200);
            }
            else return StatusCode(423);
           
            
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveLikeAsync(string To)
        {

            string From = HttpContext.User.Identity.Name;

            try
            {
                IQueryable<LikeAction> actions = _socialDb.Likes.Where(p => p.From == From);
                LikeAction action = _socialDb.Likes.FirstOrDefault(p => p.To == To);
                _socialDb.Likes.Remove(action);

                LikeList list = _socialDb.ObjectLikes.FirstOrDefault(p => p.Object == To);
                list.Likes--;
                _socialDb.ObjectLikes.Update(list);

                await _socialDb.SaveChangesAsync();
                return StatusCode(200);
            }
            catch(Exception e)
            {

            }
            return StatusCode(423);
        }
    }
}