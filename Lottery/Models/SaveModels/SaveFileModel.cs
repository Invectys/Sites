using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class SaveFileModel
    {
        public string FileFor { get; set; }
        public IFormFile file { get; set; }
        public FileInfoModel info { get; set; }

        public SaveFileModel(string For,IFormFile file,FileInfoModel info = null)
        {
            this.file = file;
            if (info == null) this.info = new FileInfoModel(); else this.info = info;
            FileFor = For;
        }
    }
}
