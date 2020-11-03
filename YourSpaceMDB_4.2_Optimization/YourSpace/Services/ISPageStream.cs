using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Page;

namespace YourSpace.Services
{
    public interface ISPageStream
    {
        public Task WritePage(MPage page);
        public Task<MPage> ReadPage(string pageName);
    }
}
