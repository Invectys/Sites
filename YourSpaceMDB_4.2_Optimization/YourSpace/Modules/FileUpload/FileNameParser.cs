using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.CodeTemplates;

namespace YourSpace.Modules.FileUpload
{
    public class FileNameParser : Singleton<FileNameParser>
    {
        public readonly string DateFormat = "MM-dd-yyyy-HH-mm";

        private readonly string _idKey = "id";
        private readonly string _dateKey = "creationDate";

        public MFileNameValues GetFileNameValues(string filePath)
        {
            MFileNameValues values = new MFileNameValues();
            var list = GetFileNameValuesDictionary(filePath);
            values.Id = list[_idKey];
            values.CreationDate = DateTime.ParseExact(list[_dateKey],DateFormat,CultureInfo.InvariantCulture); 
            return values;
        }

        public string MakeName(string fileExtension)
        {
            string date = DateTime.Now.ToString(DateFormat);
            string id = Guid.NewGuid().ToString();
            string fileName = $"{_dateKey}={date},{_idKey}={id}" + fileExtension;
            return fileName;
        }

        private Dictionary<string,string> GetFileNameValuesDictionary(string filePath)
        {
            string[] arr = filePath.Split("\\");
            var name = arr.Last().Split('.')[0];
            var list = name.Split(',').Select(value => value.Split('=')).ToDictionary(pair => pair[0], pair => pair[1]);
            return list;
        }
    }

    public class MFileNameValues
    {
        public DateTime CreationDate { get; set; }
        public string Id { get; set; }
    }
}
