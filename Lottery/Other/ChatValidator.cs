using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Other
{
    public  class ChatValidator
    {
         int maxMessageLen = 200;
         int Time = 30;
        Dictionary<string, bool> TimerAllowing=  new Dictionary<string, bool>();
        public bool isAllowed(string name,string Message)
        {

            if ((Message.Length > maxMessageLen) || (Message.Length == 0))
            {
                return false;
            }
            if (!TimerAllowing.ContainsKey(name))
            {
                TimerAllowing.Add(name, true);
            }
            if (!TimerAllowing[name]) return false;

            

            TimerAllowing[name] = false;

            return true;
        }


        void TimerAllow(object o)
        {
            string name = (string)o;
            TimerAllowing[name] = true;
        }

    }
}
