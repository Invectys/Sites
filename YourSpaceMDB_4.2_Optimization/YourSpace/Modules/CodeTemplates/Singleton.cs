using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.CodeTemplates
{
    public class Singleton<T>
    {
        private static T _instance;
        public static T GetInstance()
        {
            if(_instance == null)
            {
                _instance = (T)Activator.CreateInstance(typeof(T));
            }
            return _instance;
        }
    }
}
