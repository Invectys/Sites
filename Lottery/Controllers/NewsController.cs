using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery.Models;
using Lottery.Other;
using Lottery.Portal.News;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Lottery.Controllers
{
    public class NewsController : Controller
    {



        public ArticleService _articleService;
        public NewsController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: News
        public IActionResult Index(int week = 0)
        {
            int NowWeek = _articleService.GetNowWeek();

            List<ArticleModel> list = null;

            if (week == 0) week = NowWeek;
            if (!HttpContext.User.IsInRole("admin"))
            {
                if ((week < 0) || (week > NowWeek)) return View(list);
            }
           

            ViewBag.NowWeek = NowWeek;
            ViewBag.Week = week;

            list = new List<ArticleModel>(_articleService.GetArticles(ArticlePath.Posted,week));

            return View(list);
        }

        [HttpPost]
        public IActionResult GetNews(int week = 0)
        {
            int NowWeek = _articleService.GetNowWeek();

            List<ArticleModel> list = null;

            if (week == 0) week = NowWeek;
            if (!HttpContext.User.IsInRole("admin"))
            {
                if ((week < 0) || (week > NowWeek)) return View(list);
            }


            ViewBag.NowWeek = NowWeek;
            ViewBag.Week = week;

            list = new List<ArticleModel>(_articleService.GetArticles(ArticlePath.Posted, week));
            
            return Content(JsonConvert.SerializeObject(list));
        }


        public IActionResult Person(string person,int page = 1)
        {
            List<ArticleModel> list = null;

            list = new List<ArticleModel>(_articleService.GetPersonalArticles(person,page));

            if(list == null)
            {
                return NotFound();
            }
            else
            {
                return View("Index",list);
            }
            
        }



        public ActionResult CreateArticle()
        {
            ViewBag.NowWeek = _articleService.GetNowWeek();
            return View();
        }
        public ActionResult CreateArticlePersonalPage()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(5120)]
        public ActionResult CreateArticle(CreateArticleModel model)
        {
            if (ModelState.IsValid)
            {
                //validator.CheckModel();
                model.User = User.Identity.Name;
                _articleService.CreateArticle(model);

               return View("ArticleSuccessfullyCreated");
            }
            else
            {
                
            }

            return View(model);

        }

        // GET: 
        public IActionResult OfferedArticles(int page = 1)
        {
            List<ArticleInfoModel> list = _articleService.GetArticles(ArticlePath.Offered, page-1);
            ArticlesViewModel model = new ArticlesViewModel(list,page);
           
            return View(model);
        }

        [HttpPost]
        public IActionResult Share(int ind)
        {
            int index = Convert.ToInt32(ind);
            if(_articleService.ShareArticle(index))
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(500);
            }
            
        }

        [HttpPost]
        public IActionResult Delete(int ind,int where = 0)
        {
          
            if (_articleService.DeleteArticle(ind,where))
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(500);
            }

        }
    }
}