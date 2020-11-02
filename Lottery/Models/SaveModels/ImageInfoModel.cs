using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class ImageInfoModel
    {
        

        public ImageInfoModel()
        {

        }
        public ImageInfoModel(ImageInfoModel model)
        {
            path = model.path;
            left = model.left;
            top = model.top;
        }

        public string path { get; set; }
        [StringLength(6)]
        public string left { get; set; }
        [StringLength(6)]
        public string top { get; set; }
        
    }
}
