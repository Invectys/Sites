
//using ImageProcessLibrary;
using Lottery.Models;
using Lottery.Models.Enums;
using Lottery.Models.PersonalPageModels;
using Lottery.Models.SaveModels;
using MetadataExtractor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Directory = System.IO.Directory;

namespace Lottery.Other
{
    public class FileControl
    {
        string PageName = "";
        string login = "";
        XDocument doc = null;
 
        private string MinArticlesPath = "/Articles/MinArticle/";
        private string OfferedArticlesPath = "/Articles/OfferedArticle/";
        private string DeleteArticlesPath = "/Articles/DeletedArticles/";
        private string PersonalResourcesPath = "/PersonalResources/";
        private string PagesPath = "/PersonalPages/";

       

        private string PersonalArticles = "/Articles/PersonalArticles/";
        private string ServerPictures = "/resources/Pictures";

        

        public string CommunityPath = "/Community/";

        private IHostingEnvironment _environment;

       
       
        public List<string> AcceptedImgFormats = new List<string>() { ".png", ".jpeg" };

        public FileControl(IHostingEnvironment environment)
        {
            _environment = environment;
        }



        public async Task<string> SaveAsync(IFormFile file, string path, string saver = "000___Server")
        {
            string path_img = path;
           
            saver += "/";
            string WebRoot = _environment.ContentRootPath;
            path_img += saver;
            

            if (!Directory.Exists(WebRoot + "/wwwroot" + path_img))
            {
                    Directory.CreateDirectory(WebRoot + "/wwwroot" + path_img);
            }

            path_img = path_img + file.FileName;
            
            using (var stream = new FileStream(WebRoot + "/wwwroot" + path_img, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            return path_img;
        }
        
        public List<string> GetFileNames(string Folder)
        {
            List<string> names = new List<string>();
            try
            {
                string[] files = Directory.GetFiles(Folder);
                foreach (string str in files)
                {
                    names.Add(str.Split("/").Last());
                }
                
            }catch(Exception e)
            {
               
            }
            return names;
        }
        public List<string> GetPagesName(string login)
        {
            List<string> names = new List<string>();
            
            if(Directory.Exists(getPagesConfigPath(login)))
            {
                string[] files = Directory.GetFiles(getPagesConfigPath(login));
                foreach (string str in files)
                {
                    var filename = str.Split("/").Last().Split('.')[0];
                    names.Add(filename);
                }
            }
            

            return names;
        }


        public bool CheckImage(IFormFile file)
        {


            throw new NotImplementedException();
        }

        public void CreateArticle(ArticleInfoModel model, string Path)
        {
            try
            {


                XDocument xml = new XDocument();
                XElement MinArticle = new XElement("Article");
                XElement Title = new XElement("title", model.Title);
                XElement Picture = new XElement("picture");
                XElement PicturePath = new XElement("path", model.PicturePath);
                XElement left = new XElement("left", model.ImageInfo.left);
                XElement top = new XElement("top", model.ImageInfo.top);
                XElement PostDelay = new XElement("postdelay", model.PostWeekDelay);
                XElement OfferedDate = new XElement("offered", DateTime.Now.ToShortDateString());
                XElement ResultPostWeek = new XElement("postweek", model.PostWeek);
                XElement user = new XElement("creator", model.User);

                Picture.Add(PicturePath);
                Picture.Add(left);
                Picture.Add(top);

                XElement Text = new XElement("text", model.Information);

                MinArticle.Add(Title);
                MinArticle.Add(Picture);
                MinArticle.Add(Text);
                MinArticle.Add(PostDelay);
                MinArticle.Add(OfferedDate);
                MinArticle.Add(ResultPostWeek);
                MinArticle.Add(user);

                xml.Add(MinArticle);

                string path = Path;
                if (Directory.Exists(path))
                {

                    string[] dirs = Directory.GetFiles(path);
                    xml.Save(path + freeFileIndex(dirs) + ".xml");
                }
            }
            catch (Exception e)
            {

                return;
            }
        }



        public bool PageIsValid(string id,string name)
        {
            string path = getPagesConfigPath(id) + name + ".xml";
            bool valid = File.Exists(path);
            return valid;
        }

        public CreatePageResult CreatePageXml(CreatePageModel model)
        {
            List<string> names = GetPagesName(model.ForUser);
            if (names.Contains(model.Name)) return CreatePageResult.PageExist;

                string ToSave_Path = getPagesConfigPath(model.ForUser);
                string FullPath = ToSave_Path + model.Name + ".xml";

                DirectoryInfo dir = new DirectoryInfo(ToSave_Path);
                if (!dir.Exists) dir.Create();
                
                XDocument xdoc = new XDocument();
                XElement page = new XElement("Page");
                XAttribute name = new XAttribute("name", model.Name);
                XAttribute bg = new XAttribute("background", "https://img3.akspic.ru/image/32856-derevyannyj_nastil-etazh-drevesina-morilka-laminat-1920x1080.jpg");
                page.Add(name);
                page.Add(bg);

                xdoc.Add(page);
                xdoc.Save(FullPath);

            return CreatePageResult.OK;
        }

        private int freeFileIndex(string[] dirs)
        {
            try
            {
                int last = -1;
                foreach (string str in dirs)
                {
                    int it = Convert.ToInt32(str.Split("/").Last().Split(".")[0]);
                    if (last + 1 == it)
                    {
                        last = it;
                        continue;
                    }
                    else
                    {
                        return last + 1;
                    }
                }
            }
            catch (Exception e)
            {
                return -1;
            }
            return dirs.Length;
        }

        public void LoadPageDocument(string login,string PageName)
        {
            this.doc = null;
            XDocument doc = XDocument.Load(getPageConfigPath(login,PageName));
            this.doc = doc;
            this.PageName = PageName;
            this.login = login;
        }
       
        public void SavePageDocument()
        {
            doc.Save(getPageConfigPath(login, this.PageName));
           
        }
        public void SavePageInfo(PageInfoModel pageInfo)
        {
            XElement page = doc.Element("Page");
            if (pageInfo != null)
            {
                XElement element = ValidateElementProperty(page, "PageInfo");
                XElement height = ValidateElementProperty(element, "Height");
                if (pageInfo.PageHeight != null) height.SetValue(pageInfo.PageHeight);
                

            }
        }
        public static PageInfoModel getPageInfo(XElement page)
        {
            PageInfoModel model = new PageInfoModel();
            XElement element = ValidateElementProperty(page, "PageInfo");
            XElement height = ValidateElementProperty(element, "Height");
            if (height.Value != null) model.PageHeight = height.Value;

            return model;
        }
        public void SaveBlocks(List<SaveBlockViewModel> model)
        {
            XElement page = doc.Element("Page");
            if (model != null)
            {
                foreach (var block in model)
                {

                    XElement element = ValidateElementProperty(page, block.FullName);
                    setBlockXMLInfo(element, block.info);
                    if (block.AdditionInfo != null)
                    {
                        foreach (var pair in block.AdditionInfo)
                        {
                            AddPropertyViewModel addProperty = new AddPropertyViewModel();
                            addProperty.To = block.FullName;
                            addProperty.Property = pair.Key;
                            addProperty.Value = pair.Value;
                            AddProperty(page, addProperty);

                            ProcessAdditionalInformation(pair.Key, pair.Value);
                        }
                    }
                }
            }
            
            
        }

        public void ProcessAdditionalInformation(string key,string value)//Дополнительные действия над дополнительной информацией (используется для обработки особых свойств блока)
        {
            switch(key)
            {
                case "html":
                    
                    break;
            }
        }

        public async Task SaveImagesAsync(List<SaveImageModel> Images, PicturePaths type = PicturePaths.Default)
        {
            XElement page = doc.Element("Page");
            if (Images.Count > 0)
            {

                foreach (var block in Images)
                {
                    string path = await SaveAsync(block.file, MakePath(type), login);
                    
                    string PathIn = _environment.WebRootPath + path;
                    
                    var directories = ImageMetadataReader.ReadMetadata(PathIn);
                    if (directories.Count > 5)
                    {
                        string[] args = path.Split('.');
                        string NewLocalPath = args[0] + "_NoExif" + "." + args[1];
                        string PathOut = _environment.WebRootPath + NewLocalPath;

                        //ImageProcesser.RemoveExif(PathIn, PathOut);
                        File.Delete(PathIn);
                        block.info.path = NewLocalPath;
                    }
                    else
                    {
                        block.info.path = path;
                    }

                    ProcessImage(page, block.ImageFor, block.info);
                }
               
            }
        }
        public async Task SaveFilesAsync(List<SaveFileModel> Files)
        {
            XElement page = doc.Element("Page");
            if (Files.Count > 0)
            {

                foreach (var block in Files)
                {
                    string path = await SaveAsync(block.file, getPersonalResourcesPath()+"Files/", login);
                    block.info.path = path;

                    ProcessFile(page, block.FileFor, block.info);

                }
            }
        }
        public void SetImages(List<SetImageModel> Files)
        {
            XElement page = doc.Element("Page");
            if (Files.Count > 0)
            {
                foreach (var block in Files)
                {


                    string path = "";


                    switch (block.Type)
                    {
                        case "FromCommunity":
                            path = getCommunityPath() + "Resources/Images/" + block.ImageName;
                            break;
                        case "FromGalary":
                            path = getPersonalResourcesPath() + "Pictures/" + login + "/" + block.ImageName;
                            break;
                    }
                    block.info.path = path;
                    
                    ProcessImage(page, block.ImageFor, block.info);

                }
            }
            
        }

        public void SetFiles(List<SetFileModel> Files)
        {
            XElement page = doc.Element("Page");
            if (Files.Count > 0)
            {
                foreach (var block in Files)
                {
                    string path = "";
                    switch (block.Type)
                    {
                        case "FromCommunity":
                            path = getCommunityPath() + "Resources/Files/" + block.FileName;
                            break;
                        case "FromGalary":
                            path = getPersonalResourcesPath() + "Files/" + login + "/" + block.FileName;
                            break;
                    }

                    block.info.path = path;

                    

                    ProcessFile(page, block.FileFor, block.info);

                }
            }

        }

       

        public async Task WritePageData(List<SaveFileModel> saveFileModelList, List<SaveImageModel> saveImagesModelList) 
        {

            await SaveFilesAsync(saveFileModelList);
            await SaveImagesAsync(saveImagesModelList);
 
        }
        
        private void ProcessImage(XElement page, string ImageFor, ImageInfoModel info)
        {
            switch (ImageFor)
            {
                case "background":
                    page.Attribute("background").SetValue(info.path);
                    break;
                default:
                    XElement element = ValidateElementProperty(page, ImageFor);


                    setBlockXMLImageInfo(element, info);
                    break;
            }
           

        }
        private void ProcessFile(XElement page, string ImageFor, FileInfoModel info)
        {
            switch (ImageFor)
            {
                case "background":
                    page.Attribute("background").SetValue(info.path);
                    break;
                default:
                    XElement element = ValidateElementProperty(page, ImageFor);


                    setBlockXMLFileInfo(element, info);
                    break;
            }


        }
        public static XElement ValidateElementProperty(XElement element, string property,bool Create = true)
        {

            XElement b;
            if ((property == "") || (property == null))return null;
            if (element.Element(property) == null)
            {
                if(Create)
                {
                    b = new XElement(property);
                    element.Add(b);
                }
                else
                {
                    return null;
                }
                
            }
            else
            {
                b = element.Element(property);
            }


            return b;

        }

        public void AddProperty(XElement page, AddPropertyViewModel model) //Добавляет свойство в документ  Необходимо сохранить документ 
        {
           

            XElement end = getElementbyPath(page, model.To);

            XElement pr = ValidateElementProperty(end, model.Property);
            if (model.Value != null) pr.SetValue(model.Value);
            
            

        }
        static public XElement getElementbyPath(XElement root, string path)
        {
            if ((path == "") || (path == null)) return root;
            string[] args = path.Split('.');
            foreach (string p in args)
            {
                root = ValidateElementProperty(root, p);
            }
            return root;
        }


        //-----
       

        
        public static void setBlockXMLImageInfo(XElement block, ImageInfoModel info)
        {
            XElement Img = ValidateElementProperty(block, "img");
            if (info.path != null) Img.SetValue(info.path);



        }
        public static void setBlockXMLFileInfo(XElement block, FileInfoModel info)
        {
            XElement file = ValidateElementProperty(block, "file");
            if (info.path != null) file.SetValue(info.path);



        }


        //------

            
        public static void setBlockXMLInfo(XElement block, Info info)
        {
            if (info != null)
            {
                XElement PositionElement = ValidateElementProperty(block, "Position");
                if (info.left != null) PositionElement.SetAttributeValue("left", info.left);
                if (info.top != null) PositionElement.SetAttributeValue("top", info.top);
                XElement TransformElement = ValidateElementProperty(block, "Transform");
                if (info.height != null) TransformElement.SetAttributeValue("height", info.height);
                if (info.width != null) TransformElement.SetAttributeValue("width", info.width);
                if (info.rotate != null) TransformElement.SetAttributeValue("rotate", info.rotate);
                XElement SkewElement = ValidateElementProperty(TransformElement, "Skew");
                if (info.skew != null) SkewElement.SetAttributeValue("x", info.skew.x);
                if (info.skew != null) SkewElement.SetAttributeValue("y", info.skew.y);
                XElement TranslateElement = ValidateElementProperty(TransformElement, "Translate");
                if (info.translate!= null) TranslateElement.SetAttributeValue("x", info.translate.x);
                if (info.translate != null) TranslateElement.SetAttributeValue("y", info.translate.y);
                XElement BackgroundColor = ValidateElementProperty(block, "Bgcolor");
                if(info.bgcolor != null) BackgroundColor.SetAttributeValue("color", info.bgcolor);
                XElement Effect = ValidateElementProperty(block, "Effect");
                if (info.effect != null) Effect.SetAttributeValue("effect", info.effect);
                XElement Scale = ValidateElementProperty(block, "Scale");
                if (info.scale != null) Effect.SetAttributeValue("scale", info.scale);
                XElement Layer = ValidateElementProperty(block, "Layer");
                if (info.layer != null) Layer.SetAttributeValue("layer", info.layer);
            }

        }

        public static SaveBlockViewModel getBlockModel(XElement block)
        {
            SaveBlockViewModel blockInfo = new SaveBlockViewModel();
            Info info = new Info();
            
            XElement PositionElement = ValidateElementProperty(block, "Position");
            info.left = (PositionElement.Attribute("left") == null) ? "0" : PositionElement.Attribute("left").Value;
            info.top = (PositionElement.Attribute("top") == null) ? "0" : PositionElement.Attribute("top").Value;

            XElement TransformElement = ValidateElementProperty(block, "Transform");
            info.height = (TransformElement.Attribute("height") == null) ? "200" : TransformElement.Attribute("height").Value;
            info.width = (TransformElement.Attribute("width") == null) ? "200" : TransformElement.Attribute("width").Value;
            info.rotate = (TransformElement.Attribute("rotate") == null) ? "0" : TransformElement.Attribute("rotate").Value;


            XElement SkewElement = ValidateElementProperty(TransformElement, "Skew");
            if((SkewElement.Attribute("x") != null) && (SkewElement.Attribute("y") != null))
            {
                Vector2D skew = new Vector2D(SkewElement.Attribute("x").Value, SkewElement.Attribute("y").Value);
                info.skew = skew;
            }
            else
            {
                Vector2D skew = new Vector2D();
                info.skew = skew;
            }
            

            XElement TranslateElement = ValidateElementProperty(TransformElement, "Translate");
            if ((TranslateElement.Attribute("x") != null) && (TranslateElement.Attribute("y") != null))
            {
                Vector2D translate = new Vector2D(TranslateElement.Attribute("x").Value, TranslateElement.Attribute("y").Value);
                info.translate = translate;
            }
            else
            {
                Vector2D translate = new Vector2D();
                info.translate = translate;
            }
                

            XElement BackgroundColor = ValidateElementProperty(block, "Bgcolor");
            if (BackgroundColor.Attribute("color") != null) info.bgcolor = BackgroundColor.Attribute("color").Value;
            else info.bgcolor = "#0003";

            XElement Effect = ValidateElementProperty(block, "Effect");
            if (info.effect != null) Effect.SetAttributeValue("effect", info.effect);
            if (Effect.Attribute("effect") != null) info.effect = Effect.Attribute("effect").Value;
            else info.effect = "none";


            XElement Scale = ValidateElementProperty(block, "Scale");
            if (Scale.Attribute("scale") != null) info.scale = Scale.Attribute("scale").Value; else info.scale = "1";

            XElement Layer = ValidateElementProperty(block, "Layer");
            if (Layer.Attribute("layer") != null) info.layer = Layer.Attribute("layer").Value; else info.layer = "5";

            blockInfo.FullName = block.Name.ToString();
            blockInfo.info = info;



            return blockInfo;
        }


        public void DeleteBlock(string block)
        {
            
            XElement page = doc.Element("Page");

            if (page.Element(block) != null)
            {
                page.Element(block).Remove();
            }
            

        }
       


        public void DeleteUserData(string login,bool Reserve = true)
        {
            if (Reserve) ReservePage(login);

            var path = _environment.ContentRootPath + "/";
            var p1 = getPagesConfigPath(login);
            var p2 = path + getPersonalResourcesPath() + "Files/" + login;
            var p3 = path + getPersonalResourcesPath() + "Pictures/" + login;
            if (File.Exists(p1)) File.Delete(p1);
            if (File.Exists(p2)) File.Delete(p2);
            if (File.Exists(p3)) File.Delete(p3);
        }

        public void ReservePage(string login)
        {
            var path = _environment.ContentRootPath + "/";
            var p1 = getPagesConfigPath(login);
            var p2 = getUserFilesPath(login);
            var p3 = getPicturesPath(login);

            string time = DateTime.Now.ToString("d") ;
            string ReserveDataPages = getReserveData(login) + time + "/Pages/";
            string ReserveDataFiles = getReserveData(login) + time + "/Files/";
            string ReserveDataPictures = getReserveData(login) + time + "/Pictures";

            CopyDir(p1, ReserveDataPages);
            CopyDir(p2, ReserveDataFiles);
            CopyDir(p3, ReserveDataPictures);
        }

        int CopyDir(string FromDir, string ToDir)
        {
            if (!Directory.Exists(FromDir)) return 1;
            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.GetFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                if (File.Exists(s2)) continue;
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(FromDir))
            {
                CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
            }
            return 0;
        }

        public string MakePath(PicturePaths path)
        {
            switch(path)
            {
                case PicturePaths.Default:
                    return PersonalResourcesPath + "Pictures/";
                case PicturePaths.ServerResource:
                    return ServerPictures;
            }
            return null;
        }

        public string getPagesPath() => PagesPath;
        public string getPagesPathWithRoot() => "ApplicationData" + PagesPath;
        public string getPagesConfigPath(string login) => _environment.ContentRootPath + "/ApplicationData" + PagesPath + "PagesStateConfig/" + login + "/";

        public string getPageConfigPath(string login,string page) => getPagesConfigPath(login) + page + ".xml";

        public string getReserveData(string login)  => _environment.ContentRootPath + "/ApplicationData/Reserve/" + login + "/";

        public string getUserFilesPath(string login) => _environment.WebRootPath +"/"+ getPersonalResourcesPath() + "Files/" + login + "/";
        public string getPicturesPath(string login) => _environment.WebRootPath + "/" + getPersonalResourcesPath() + "Pictures/" + login + "/";

        public string getPersonalArticlesPath() => PersonalArticles;
        public string getPersonalArticlesPathWithRoot() => _environment.ContentRootPath + "/ApplicationData"  + PersonalArticles;


        public string getPersonalResourcesPath() => PersonalResourcesPath;
        public string getPersonalResourcesPathWithRoot() => "wwwroot" + PersonalResourcesPath;


        public string getCommunityPath() => CommunityPath;
        public string getCommunityPathWithRoot() => "wwwroot" +  CommunityPath;
    }


    public enum PicturePaths
    {
        ServerResource,
        Default
    }

    public enum ArticlePath
    {
        Posted,
        Offered,
        Deleted
    }








}

