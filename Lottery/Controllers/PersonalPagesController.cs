using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lottery.Data;
using Lottery.Models;
using Lottery.Models.Enums;
using Lottery.Models.PersonalPageModels;
using Lottery.Models.SaveModels;
using Lottery.Models.Social;
using Lottery.Models.ViewModels;
using Lottery.Other;
using Lottery.Portal.Social;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Lottery.Controllers
{
    public class PersonalPagesController : Controller
    {

        private readonly IHostingEnvironment _appEnvironment;
        FileControl _fileControl;
        PageService _pageService;
        SocialDbContext _socialDb;
        public PersonalPagesController(IHostingEnvironment appEnvironment, FileControl fileControl,PageService pageService,SocialDbContext socialDb)
        {
            _appEnvironment = appEnvironment;
            _fileControl = fileControl;
            _pageService = pageService;
            _socialDb = socialDb;
        }


        [HttpGet]
        public IActionResult person(string id,string PageName)
        {
            
            if (_fileControl.PageIsValid(id, PageName))
            {
                LikeList count = _socialDb.ObjectLikes.FirstOrDefault(p => p.Object == (id + "-PageLike"));
                int likes = 0;
                if(count != null)
                {
                    likes = count.Likes;
                }

                bool PageLiked = false;
                if(HttpContext.User.Identity.IsAuthenticated)
                {
                    IQueryable<LikeAction> like = _socialDb.Likes.Where(p => p.From == HttpContext.User.Identity.Name);
                    LikeAction action = like.FirstOrDefault(p => p.To == id + "-PageLike");
                    if(action != null)
                    {
                        PageLiked = true;
                    }
                }


                ViewBag.pageLiked = PageLiked;
                ViewBag.person = id;
                ViewBag.page = PageName;
                ViewBag.likes = likes;
                
                return View("DefaultPage");
            }
            else return NotFound();


        }
        
       
        public IActionResult Index()
        {
            
            return View();
        }


        //Action----------------------------------------------------------------------
        //Действие обрабатывающее загрузку новых фотографий на странице и их параметры
        [HttpPost]
        public IActionResult ProcessSavePageData() 
        {                                                                                  //разбор присланной веб формы
            HttpRequest   httpRequest       =   Request;
            SaveBlocksModel SaveBlocksmodel=  new SaveBlocksModel();
            PageInfoModel PageInfo = new PageInfoModel();

            //BlockSaveInfo
            if (httpRequest.Form.ContainsKey("BlocksSaveObject"))
            {
                StringValues val;
                httpRequest.Form.TryGetValue("BlocksSaveObject", out val);
                string json = val[0];
                SaveBlocksmodel = JsonConvert.DeserializeObject<SaveBlocksModel>(json);

                
            }
            //PageInfo
            if (httpRequest.Form.ContainsKey("PageInfoObject"))
            {
                StringValues val;
                httpRequest.Form.TryGetValue("PageInfoObject", out val);
                string json = val[0];
                PageInfo = JsonConvert.DeserializeObject<PageInfoModel>(json);

                httpRequest.Form.TryGetValue("PageInfoObject", out val);
            }

            string PageName = "";
            if (httpRequest.Form.ContainsKey("PageName"))
            {
                StringValues val;
                httpRequest.Form.TryGetValue("PageName", out val);
                PageName = val.ToString();
            }
            else return StatusCode(423);

            List<SaveImageModel> saveImageModelList     =   new List<SaveImageModel>();
            List<SetImageModel> setImageModelList       =   new List<SetImageModel>();
            List<SaveFileModel> saveFileModelList = new List<SaveFileModel>();
            List<SetFileModel> setFileModelList = new List<SetFileModel>();

            _pageService.LoadPageDocument(User.Identity.Name,PageName);

            foreach (var key in httpRequest.Form.Keys)                                      //Перебор всех установленных полей в форме                         
            {
                try
                {
                    string[] args = key.Split("+"); //параметры записанные в ключе поля 

                    bool skip = (args.Length <= 1) || (key.Equals("BlocksSaveObject")) || (key.Equals("PageInfoObject")) ;
                    if (skip) continue;

                    string nameFor = args[0];        //картинка для какого блока на странице        
                    string type = args[1];        //тип блока (image,..) или действие (только удаление !)



                    StringValues val;
                    bool bFromImageGalary = false;
                    string param;
                    switch (type)
                    {
                        case "delete":
                            _pageService.DeleteBlock(nameFor);
                            continue;


                        case "image":


                            httpRequest.Form.TryGetValue(key, out val);
                            param = val[0];

                            switch (param)
                            {
                                case "FromCommunity":
                                case "FromGalary":
                                    httpRequest.Form.TryGetValue(nameFor, out val);
                                    string Image = val[0];
                                    SetImageModel model = new SetImageModel(nameFor, Image, param, null);
                                    setImageModelList.Add(model);
                                    break;

                                case "New":
                                    var file = httpRequest.Form.Files.GetFile(nameFor);//файл для блока
                                    if ((file != null))
                                    {
                                        string JSON = "";
                                        ImageInfoModel Image_ = null;

                                        if (httpRequest.Form.ContainsKey(nameFor + "+settings"))  //пробуем получить информацию о редактировании фото
                                        {
                                            JSON = httpRequest.Form[nameFor + "+settings"];
                                            Image_ = JsonConvert.DeserializeObject<ImageInfoModel>(JSON);
                                        }

                                        SaveImageModel m = new SaveImageModel(nameFor, file, Image_);
                                        saveImageModelList.Add(m);
                                    }
                                    break;
                            }




                            break;
                        case "file":

                            httpRequest.Form.TryGetValue(key, out val);
                            param = val[0];

                            switch (param)
                            {
                                case "FromCommunity":
                                case "FromGalary":
                                    httpRequest.Form.TryGetValue(nameFor, out val);
                                    string File = val[0];
                                    SetFileModel model = new SetFileModel(nameFor, File, param);
                                    setFileModelList.Add(model);
                                    break;
                                case "New":
                                    var file = httpRequest.Form.Files.GetFile(nameFor);//файл для блока
                                    if ((file != null))
                                    {


                                        SaveFileModel m = new SaveFileModel(nameFor, file);
                                        saveFileModelList.Add(m);
                                    }
                                    break;
                            }

                            break;
                    }
                }catch(Exception e)
                {
                    continue;
                }
    
            }

            ProcessPageModel _model = new ProcessPageModel();
            _model.SaveBlockViewModels = SaveBlocksmodel.models;
            _model.saveFileModelList = saveFileModelList;
            _model.SaveImages = saveImageModelList;
            _model.setFileModelList = setFileModelList;
            _model.SetImages = setImageModelList;
            _model.PageInfo = PageInfo;

            try
            {
                int result = PageInfoValidator.Validate(_model);
                if (result != 0) return StatusCode(500);

                var task = Task.Run(() => _pageService.ProcessPageInformation(_model));
                task.Wait();
                return StatusCode(task.Result);
            }
            catch(Exception e)
            {
                return StatusCode(503);
            }
            
            
            
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreatePage(CreatePageModel model)
        {
            model.ForUser = User.Identity.Name;
            CreatePageResult result = _fileControl.CreatePageXml(model);
            var r = new PageCreatedViewModel();
            r.PageName = model.ForUser;
            r.result = result;
            return View("PageCreated", r);
        }

        class SaveBlocksModel
        {
            public List<SaveBlockViewModel> models { get; set; }
            
        }
    }

     
}