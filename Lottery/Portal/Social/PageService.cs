using Lottery.Models;
using Lottery.Models.PersonalPageModels;
using Lottery.Models.SaveModels;
using Lottery.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Portal.Social
{
    public class PageService
    {
        private readonly FileControl _fileControl;
        public  ProcessPageModel ProcessPageInfo;

        public PageService(FileControl fileControl)
        {
            _fileControl = fileControl;
        }
        public void CreatePage(CreatePageModel model)
        {

            Task.Run(() => _fileControl.CreatePageXml(model));

        }


       

        public async Task<int> ProcessPageInformation(ProcessPageModel model)
        {
            ProcessPageInfo = model;
            _fileControl.SetFiles(model.setFileModelList);
            _fileControl.SetImages(model.SetImages);
            _fileControl.SaveBlocks(model.SaveBlockViewModels);
            _fileControl.SavePageInfo(model.PageInfo);
            var task = Task.Run(()=>_fileControl.WritePageData(model.saveFileModelList,model.SaveImages));
            task.Wait();
            SavePageDocument();

            return 200;
        }

        public void SavePageDocument()
        {
            _fileControl.SavePageDocument();

        }

        public void LoadPageDocument(string user,string page)
        {
            _fileControl.LoadPageDocument(user, page);
        }

        

        public void DeleteBlock(string block)
        {
           _fileControl.DeleteBlock(block);

        }

        
    }
}
