using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class SetFileModel
    {
        public string Type { get; set; }
        public string FileFor { get; set; }
        public string FileName { get; set; }
       public FileInfoModel info { get; set; }

        public SetFileModel(string For,string File,string From, FileInfoModel info = null)
        {
            FileName = File;
            FileFor = For;
            Type = From;
            if (info == null) this.info = new FileInfoModel(); else this.info = info;


        }
    }
}
