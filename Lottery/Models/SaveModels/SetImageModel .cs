using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class SetImageModel
    {
        public string Type { get;set; }
        public string ImageFor { get; set; }
        public string ImageName { get; set; }
        public ImageInfoModel info { get; set; }

        public SetImageModel(string For,string Image,string type,ImageInfoModel model)
        {
            Type = type;
            ImageName = Image;
            ImageFor = For;

            if (model != null)
                info = new ImageInfoModel(model);
            else
                info = new ImageInfoModel();
            
        }
    }
}
