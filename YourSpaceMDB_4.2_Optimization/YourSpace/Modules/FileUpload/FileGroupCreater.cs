using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.FileUpload
{
    public static class FileGroupCreater
    {
        public static IEnumerable<IGrouping<DateTime, string>> CreateGroupByDate(List<string> files)
        {
            var list = new Dictionary<DateTime, List<string>>();
            var parser = FileNameParser.GetInstance();

            DateTime group(string val)
            {
                var values = parser.GetFileNameValues(val);
                var date = values.CreationDate;
                string format = "MM:yyyy";
                var key = DateTime.ParseExact(date.ToString(format), format, CultureInfo.InvariantCulture);
                return key;
            }

            var groups = files.GroupBy(group);
            return groups;
        }
    }

   
}
