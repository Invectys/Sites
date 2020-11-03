using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.ModalWindow
{
    public class ModalParameters
    {
        private Dictionary<string, object> _parameters;

        public ModalParameters()
        {
            _parameters = new Dictionary<string, object>();
        }

        public void Add(string parameterKey, object value)
        {
            _parameters[parameterKey] = value;
        }

        public T Get<T>(string parameterKey)
        {
            return (T)_parameters[parameterKey];
        }

        public T TryGet<T>(string parameterKey, out bool have)
        {
            if(_parameters.ContainsKey(parameterKey))
            {
                have = true;
                return (T)_parameters[parameterKey];
            }

            have = false;
            return default;
        }
    }
}
