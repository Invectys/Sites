using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class FileInfoModel
    {
        public FileInfoModel()
        {

        }


        public FileInfoModel(FileInfoModel model)
        {
            path = model.path;
           
        }

        public string path { get; set; }
        
        
        
    }
}
