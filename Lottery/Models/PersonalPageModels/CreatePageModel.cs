using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models.PersonalPageModels
{
    public class CreatePageModel
    {
        public string Name { get; set; }
        public string ForUser { get; set; }
        
        public CreatePageModel(string login,string name = "default")
        {
            ForUser = login;
            Name = name;
        }
        public CreatePageModel()
        {

        }
    }
}
