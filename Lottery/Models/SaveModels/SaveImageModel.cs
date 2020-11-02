using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class SaveImageModel
    {
        public string ImageFor { get; set; }
        public IFormFile file { get; set; }
        public ImageInfoModel info { get; set; }

        public SaveImageModel(string For,IFormFile file,ImageInfoModel model)
        {

            this.file = file;
            ImageFor = For;

            if (model != null)
                info = new ImageInfoModel(model);
            else
                info = new ImageInfoModel();
            
        }
    }
}
