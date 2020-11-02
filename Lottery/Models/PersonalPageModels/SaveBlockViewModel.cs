using Lottery.Models.SaveModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models.PersonalPageModels
{
    [JsonObject]
    public class Info
    {
        public string left { get; set; }
        public string top { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public string rotate { get; set; }
        public Vector2D skew { get; set; }
        public Vector2D translate { get; set; }
        public string bgcolor { get; set; }
        public string effect { get; set; }
        public string scale { get; set; }
        public string layer { get; set; }
    }
    
   

    [JsonObject]
    public class SaveBlockViewModel
    {
        public string FullName { get; set; }
 
        public Info info { get; set; }

        public Dictionary<string, string> AdditionInfo { get; set; }

    }
}
