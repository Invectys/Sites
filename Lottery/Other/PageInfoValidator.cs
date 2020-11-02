using Lottery.Models.SaveModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Other
{
    public static class PageInfoValidator
    {

        public static int MaxAdditionalInfoStrings = 5;
        public static (int min, int max) LayerRange = (5,100);

        public static int Validate(ProcessPageModel model)
        {
            if(model.SaveBlockViewModels != null)
            {
                foreach (var v in model.SaveBlockViewModels)
                {
                    if(v.AdditionInfo != null)if(v.AdditionInfo.Values.Count > MaxAdditionalInfoStrings) return 1;

                }
            }
            
            return 0;
        }
    }
}
