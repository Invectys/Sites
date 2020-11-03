using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.ThingCounter;
using YourSpace.Services;

namespace YourSpace.Modules.Pages.Page.Components
{
    public class CPagePresentation : ComponentBase
    {
        public string ImagePath { get { return "../" + Model.ImageBackground.Replace('\\', '/'); } }

        [Parameter] public bool Init { get; set; } = false;

        [Parameter] public int Likes { get; set; }
        [Parameter] public string Url { get; set; }
        [Parameter] public int Subscribers { get; set; }


        [Parameter] public string Class { get; set; }
        [Parameter] public MPageCardBlock Model { get; set; }
        [Parameter] public EventCallback<string> onDeletePage { get; set; }
        [Parameter] public bool Edit { get; set; } = false;


        [Inject] protected ISPagesUrl SUrl { get; set; }
        [Inject] protected ISThingCounter sMarks { get; set; }


        public void BlockEdited()
        {
            StateHasChanged();
        }

        public async Task<int> GetSubscribers()
        {
            var notes = await sMarks.GetCounterAmountNotes(Model.PageId, MCounterType.Subscribe());
            return notes.Count;
        }

        public async Task<int> GetLikes()
        {
            var notes = await sMarks.GetCounterAmountNotesByPage(Model.PageId, MCounterType.Like());
            return notes.Count;
        }

        protected override async Task OnInitializedAsync()
        {
            if(Init)
            {
                Likes = await GetLikes();
                Subscribers = await GetSubscribers();
                Url = await SUrl.GetPageUrl(Model.PageId);
            }
        }

        protected override void OnInitialized()
        {
            
        }
    }
}
