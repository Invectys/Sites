using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using YourSpace.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.FileUpload
{
    public class SFileUpload : ISFileUpload
    {
        private readonly ISFilesPathBuilder _pathBuilder;


        public SFileUpload(ISFilesPathBuilder pathBuilder)
        {
            _pathBuilder = pathBuilder;
        }
        public async Task Upload(IFileListEntry file,string path, string fileName)
        {
            var memoryStream = new MemoryStream();
            await file.Data.CopyToAsync(memoryStream);

            string fullPath = path + "/" + fileName;

            using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            }

        }

        public string MakeName(IFileListEntry file)
        {
            string fileExt = "." + file.Name.Split(".").Last();
            return FileNameParser.GetInstance().MakeName(fileExt);
        }
    }
}
