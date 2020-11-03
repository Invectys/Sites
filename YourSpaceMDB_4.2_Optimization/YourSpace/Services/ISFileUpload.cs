//Сервис загрузки файлов разных типов НА СЕРВЕР

using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Services
{
    public interface ISFileUpload
    {
        public string MakeName(IFileListEntry file);
        public Task Upload(IFileListEntry file, string path,string fileName);
    }
}
