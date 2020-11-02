using Lottery.Models.PersonalPageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models.SaveModels
{
    public class ProcessPageModel
    {

        public List<SaveBlockViewModel> SaveBlockViewModels { get; set; }
        public List<SaveImageModel> SaveImages { get; set; }
        public List<SetImageModel> SetImages { get; set; }
        public List<SaveFileModel> saveFileModelList { get; set; }
        public List<SetFileModel> setFileModelList { get; set; }
        public PageInfoModel PageInfo { get; set; }
        public ProcessPageModel()
        {
            PageInfo = null;
            SaveBlockViewModels = null;
            SaveImages = null;
            SetImages = null;
            saveFileModelList = null;
            setFileModelList = null;
        }
    }
}
