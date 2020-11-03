using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Services;

namespace YourSpace.Modules.Music
{
    public class CMusicPlayer : ComponentBase
    {

        [Parameter] public string PlayerId { get; set; }
        [Parameter] public string Class { get; set; }

        [Parameter] public MMusic Music { get; set; } = new MMusic();
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public ISMusic SMusic { get; set; }


        protected override void OnInitialized()
        {
            
        }

        protected override async void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {

            }
           
        }

        
        public static void LunchMusic()
        {
        }

    }

    
}
