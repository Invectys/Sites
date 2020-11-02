using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Other
{
    public static class Helpful
    {
        
        public static void MixNames(List<string> A)
        {
            if(A.Count > 1)
            {
                Random RND = new Random();

                for (int i = 0; i < A.Count; i++)
                {
                    var tmp = A[0];
                    A.RemoveAt(0);
                    A.Insert(RND.Next(A.Count), tmp);
                }
            }
           
        }
    }
}
