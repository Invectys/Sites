//Сервис загрузки файлов с сервера
//Используется в скачивании персональных данных

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Services
{
    public interface ISFileSave
    {
        public Task SaveAsBase64(string fileName, string base64, string type = "application/zip");
    }
}
