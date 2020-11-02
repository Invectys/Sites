using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class ArticleModel
    {
        public ArticleModel()
        {
            ImageInfo = new ImageInfoModel();
            ImageInfo.left = "0px";
            ImageInfo.top = "0px";
        }

        public int index { get; set; }
        public string Title { get; set; }
        public string PicturePath { get; set; }
        public string Information { get; set; }
        public string User { get; set; }
        public ImageInfoModel ImageInfo { get; set; }
    }
}
