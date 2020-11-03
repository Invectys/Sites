using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Services
{
    public interface ISPagesRating
    {
        public Task<List<MPageInfo>> GetRating();
    }
}
