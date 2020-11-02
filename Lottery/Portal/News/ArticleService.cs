using Lottery.Models;
using Lottery.Other;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lottery.Portal.News
{
    public class ArticleService
    {
        private readonly ILogger<ArticleService> _logger;
        IHostingEnvironment _environment;
        FileControl _filesControl;
        UserManager<ApplicationUser> _userManager;
        DateTime Start = new DateTime(2019, 6, 10, 0, 0, 0, 0);

        public int CountArticleOnPage = 2;
        public int CountArticleOnPersonalPage = 2;

        string MinArticlesPath = "wwwroot/Articles/MinArticle/";
        string OfferedArticlesPath = "wwwroot/Articles/OfferedArticle/";
        string DeleteArticlesPath = "wwwroot/Articles/DeletedArticles/";

        public ArticleService(ILogger<ArticleService> Logger,IHostingEnvironment environment,
            UserManager<ApplicationUser> userManager, FileControl FilesControl)
        {
            _userManager = userManager;
            _logger = Logger;
            _environment = environment;
            _filesControl = FilesControl;
        }

        public void CreateArticle(CreateArticleModel model)
        {
            
            ArticleInfoModel AI = new ArticleInfoModel();
            

           


            int NowWeek = GetNowWeek();
            ImageInfoModel ImageInfo = JsonConvert.DeserializeObject<ImageInfoModel>(model.JSONImageData);
            ArticleInfoModel ArticleInfo = JsonConvert.DeserializeObject<ArticleInfoModel>(model.JSONArticleData);

            string img;
            if(model.Personal)
            {
                img = _filesControl.SaveAsync(model.Img, _filesControl.MakePath(PicturePaths.Default), model.User).Result;
            }
            else
            {
                img = _filesControl.SaveAsync(model.Img, _filesControl.MakePath(PicturePaths.ServerResource)).Result;
            }

                AI.ImageInfo = ImageInfo;
                AI.Information = model.Information;
                AI.OfferedDate = DateTime.Now.ToShortDateString();
                AI.PicturePath = img;
                AI.PostWeek = NowWeek + Convert.ToInt32(ArticleInfo.PostWeekDelay);
                AI.PostWeekDelay = ArticleInfo.PostWeekDelay;
                AI.Title = model.Title;
                AI.User = model.User;


            string Path = OfferedArticlesPath;
            if (model.Personal) Path = _filesControl.getPersonalArticlesPathWithRoot() + model.User + "/";
            _filesControl.CreateArticle(AI, Path);

        }
         

         public int GetNowWeek()
         {
            DateTime Now = DateTime.Now;
            DateTime Now1 = new DateTime(2019, 6, 17, 0, 0, 0, 0);
            TimeSpan span = Now.Subtract(Start);
            int NowDays = (int)(span.TotalDays / 7) + 1;
            return NowDays;
         }


        

        public List<ArticleInfoModel> GetArticles(ArticlePath path,int week = 0)
        {
            int n = GetNowWeek();
            string Path = "";
            switch (path)
            {
                case ArticlePath.Deleted: Path = DeleteArticlesPath; break;
                case ArticlePath.Posted: Path = MinArticlesPath; break;
                case ArticlePath.Offered: Path = OfferedArticlesPath; break;
            }

            List<ArticleInfoModel> list = new List<ArticleInfoModel>();

            string[] dirs = null;
            int lastArticleInd = -1;


            switch (path)
            {
                case ArticlePath.Deleted:
                case ArticlePath.Offered:
                    try
                    {
                        dirs = Directory.GetFiles(Path);
                        lastArticleInd = Convert.ToInt32(dirs.Last().Split('/').Last().Split('.')[0]);
                        int ArticleCount = CountArticleOnPage;
                        for (int i = 0; i <= lastArticleInd;i++)
                        {
                            int position = i + (week * CountArticleOnPage);
                            int ind = 0;
                            try
                            {
                                ind = Convert.ToInt32(dirs[position].Split('/').Last().Split('.')[0]);
                            }
                            catch(Exception e)
                            {
                                break;
                            }
                           

                            ArticleInfoModel model = (ArticleInfoModel)Article(ind, path);
                            if (model != null)
                            {
                                ArticleCount--;
                                list.Add(model);
                            }
                            if (ArticleCount <= 0) break;
                        }
                    }
                    catch (Exception e) { };

                    break;

                case ArticlePath.Posted:

                    try
                    {


                        Path = Path + week + "/";
                        if (!Directory.Exists(Path)) return list;
                        dirs = Directory.GetFiles(Path);
                        lastArticleInd = Convert.ToInt32(dirs.Last().Split('/').Last().Split('.')[0]);

                        for (int i = 0; i <= lastArticleInd; i++)
                        {
                            ArticleInfoModel model = (ArticleInfoModel)Article(i, Path);
                            if (model != null)
                            {
                               
                               list.Add(model);
                            }


                        }
                    }
                    catch (Exception e)
                    {

                    }


                    break;
            }

            

           
           
            
            
            

            return list;
        }
        public List<ArticleInfoModel> GetPersonalArticles(string User,int page = 1)
        {
            page--;
            string Path = _filesControl.getPersonalArticlesPathWithRoot() + User + "/";
            

            List<ArticleInfoModel> list = new List<ArticleInfoModel>();

            string[] dirs = null;
            int lastArticleInd = -1;

            try
            {

                if (!Directory.Exists(Path))
                {
                    
                    return list;
                }

                dirs = Directory.GetFiles(Path);

                int startInd = Convert.ToInt32(dirs[page * CountArticleOnPersonalPage].Split('/').Last().Split('.')[0]);

                lastArticleInd = Convert.ToInt32(dirs.Last().Split('/').Last().Split('.')[0]);

                for (int i = startInd; i <= lastArticleInd; i++)
                {
                    ArticleInfoModel model = (ArticleInfoModel)Article(i, Path);
                    if (model != null)
                    {
                        list.Add(model);
                        if (list.Count == CountArticleOnPersonalPage) break;

                    }
                }
            }
            catch (Exception e)
            {
                
            }

            return list;
        }
        public ArticleModel Article(int index,ArticlePath path)
        {
            string Path = "";
            switch(path)
            {
                case ArticlePath.Deleted:Path = DeleteArticlesPath; break;
                case ArticlePath.Posted:Path = MinArticlesPath;break;
                case ArticlePath.Offered:Path = OfferedArticlesPath;break;
            }

            return GetArticle(index, Path);
        }
        public ArticleModel Article(int index, string Path)
        {

            return GetArticle(index, Path);
        }
        private  ArticleInfoModel GetArticle(int ind, string path_articles = "")
        {
            ArticleInfoModel model = new ArticleInfoModel();
            string path = path_articles + ind + ".xml";
            try
            {
                XDocument xml = XDocument.Load(path);
                model.Title = xml.Element("Article").Element("title").Value;
                model.PicturePath = xml.Element("Article").Element("picture").Element("path").Value;
                model.Information = xml.Element("Article").Element("text").Value;
                model.ImageInfo.left = xml.Element("Article").Element("picture").Element("left").Value;
                model.ImageInfo.top = xml.Element("Article").Element("picture").Element("top").Value;
                model.User = xml.Element("Article").Element("creator").Value;
                model.index = ind;
               
                model.PostWeekDelay = Convert.ToInt32(xml.Element("Article").Element("postdelay").Value);
                model.OfferedDate = xml.Element("Article").Element("offered").Value;
                model.PostWeek = Convert.ToInt32(xml.Element("Article").Element("postweek").Value);

               
               
                
               
               
               
                return model;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Не удалось загрузить или обработать файл статьи");
            }
            
           

            return null;
        }

       

       

        

        public bool ShareArticle(int ind)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(OfferedArticlesPath + ind + ".xml");
                if (fileInfo.Exists)
                {
                    ArticleInfoModel model = (ArticleInfoModel)Article(ind, ArticlePath.Offered);
                    int postWeek = model.PostWeek;
                    string ResultPath = MinArticlesPath + postWeek + "/";

                    if(!Directory.Exists(ResultPath))
                    {
                        Directory.CreateDirectory(ResultPath);
                    }

                    string[] dirs = Directory.GetFiles(ResultPath);
                    //fileInfo.MoveTo(ResultPath + freeFileIndex(dirs) + ".xml");
                    return true;
                }

            }
            catch(Exception e)
            {
                
            }
            return false;
        }

        public bool DeleteArticle(int ind,int where = 0)
        {
            string path = "";
            switch(where)
            {
                case 0:
                    path = OfferedArticlesPath;
                    break;
                case 1:
                    path = MinArticlesPath;
                    break;
            }
           
            try
            {
                
                FileInfo fileInfo = new FileInfo(path + ind + ".xml");
                if (fileInfo.Exists)
                {
                    string[] dirs = Directory.GetFiles(DeleteArticlesPath);
                    fileInfo.MoveTo(DeleteArticlesPath + dirs.Length + ".xml");
                    return true;
                }

            }
            catch (Exception e)
            {

            }
            return false;
        }


    }

    
}
