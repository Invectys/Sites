using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Services;

namespace YourSpace.Modules.FileSave
{
    public class SFileSave : ISFileSave
    {
        IJSRuntime _jSRuntime;

        public SFileSave(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task SaveAsBase64(string fileName, string base64, string type = "application/zip")
        {
            await _jSRuntime.InvokeVoidAsync("BlazorFileSaver.saveAsBase64", fileName, base64, type);
        }

    }
}
