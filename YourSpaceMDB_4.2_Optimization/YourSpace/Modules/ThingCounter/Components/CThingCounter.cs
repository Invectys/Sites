using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using YourSpace.Pages;
using YourSpace.Services;

namespace YourSpace.Modules.ThingCounter.Components
{
    public class CThingCounter : OwningComponentBase<ISThingCounter>
    {
        public bool IsAdded { get; set; }
        public int Amount { get; set; }

        [Parameter] public MThingCounter IdModel { get; set; }
        [Parameter] public string PageId { get; set; } = "";

        [CascadingParameter] protected Task<AuthenticationState> Authentication { get; set; }

        public async Task Add()
        {
            var user = (await Authentication).User;
            await Service.Add(user, IdModel.Id, IdModel.ThingType, PageId);
            Amount++;
            IsAdded = true;
            StateHasChanged();
        }

        public async Task Remove()
        {
            var user = (await Authentication).User;
            await Service.Remove(user, IdModel.Id, IdModel.ThingType);
            Amount--;
            IsAdded = false;
            StateHasChanged();
        }


        protected async override Task OnInitializedAsync()
        {
            var user = (await Authentication).User;
            IsAdded = await Service.IsAdded(user, IdModel.Id, IdModel.ThingType);
            Amount = (await Service.GetCounterAmountNotes(IdModel.Id, IdModel.ThingType)).Count;
        }
    }
}
