using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.Browser
{
    public class SBrowser
    {
        private readonly IJSRuntime _js;

        public SBrowser(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<EDeviceResolution> DetectResolution()
        {
            EDeviceResolution resolution = EDeviceResolution.ExtraSmall;
            BrowserDimension dimension = await GetDimensions();
            if (dimension.Width > 576)
            {
                resolution = EDeviceResolution.Small;
            } 
            if (dimension.Width > 768)
            {
                resolution = EDeviceResolution.Medium;
            } 
            if (dimension.Width > 992)
            {
                resolution = EDeviceResolution.Large;
            }
            if (dimension.Width > 1200)
            {
                resolution = EDeviceResolution.ExtraLarge;
            }
            return resolution;
        }

        public async Task<BrowserDimension> GetDimensions()
        {
            return await _js.InvokeAsync<BrowserDimension>("getDimensions");
        }
    }

    public class BrowserDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public enum EDeviceResolution
    {
        ExtraSmall,
        Small,
        Medium,
        Large,
        ExtraLarge
    }

}
