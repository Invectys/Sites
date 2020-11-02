using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models.SaveModels
{
    public class  Vector2D
    {
        public string x { get; set; }
        public string y { get; set; }

        public Vector2D(string _x="0",string _y = "0")
        {
            if (_x != null) x = _x; else x = "0";
            if (_y != null) y = _y; else y = "0";
        }
    }
}
