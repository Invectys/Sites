
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Services;
using YourSpace.Modules.ModalWindow;

namespace YourSpace.Modules.ModalWindow
{
    public partial class Modal
    {
        const string _defaultSize = "";
        const string _defaultStyle = "blazored-modal";
        const string _defaultPosition = "";

        [Inject] private ISModal ModalService { get; set; }

        public string Id { get { return "Modal" + ModalId; } }

        [Parameter] public bool HideWrapper { get; set; }
        [Parameter] public bool HideHeader { get; set; }
        [Parameter] public bool HideCloseButton { get; set; }
        [Parameter] public bool DisableBackgroundCancel { get; set; }
        [Parameter] public string Position { get; set; }
        [Parameter] public string Size { get; set; }
        [Parameter] public string Style { get; set; }
        [Parameter] public int ModalId { get; set; }

        private bool ComponentDisableBackgroundCancel { get; set; }
        private bool ComponentHideWrapper { get; set; }
        private bool ComponentHideHeader { get; set; }
        private bool ComponentHideCloseButton { get; set; }
        private string ComponentPosition { get; set; }
        private string ComponentStyle { get; set; }
        private string ComponentSize { get; set; }
        private bool IsVisible { get; set; }
        private string Title { get; set; } = "";
        private RenderFragment Content { get; set; }
        private ModalParameters Parameters { get; set; }

        protected override void OnInitialized()
        {
            ((SModal)ModalService).OnShow += ShowModal;
            ((SModal)ModalService).CloseModal += CloseModal;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SetTitle(string title)
        {
            Title = title;
            StateHasChanged();
        }
        private async void ShowModal(string title,RenderFragment content,ModalParameters parameters,ModalOptions options, int modalId = 1)
        {
            if (ModalId != modalId) return;
            Title = title;
            Content = content;
            Parameters = parameters;
            IsVisible = true;
            SetModalOptions(options);
            await InvokeAsync(StateHasChanged);
        }
        private async void CloseModal(int modalId = 1)
        {
            if (ModalId != modalId) return;
            Title = "";
            Content = null;
            ComponentStyle = "";
            IsVisible = false;
            await InvokeAsync(StateHasChanged);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                ((SModal)ModalService).OnShow -= ShowModal;
                ((SModal)ModalService).CloseModal -= CloseModal;
            }
        }

        private void HandleBackgroundClick()
        {
            if (ComponentDisableBackgroundCancel) return;
            ModalService.Cancel(ModalId);
        }

        private void SetModalOptions(ModalOptions options)
        {
            if (options == null) return;

            ComponentHideHeader = HideHeader;
            if (options.HideHeader.HasValue)
                ComponentHideHeader = options.HideHeader.Value;

            ComponentHideCloseButton = HideCloseButton;
            if (options.HideCloseButton.HasValue)
                ComponentHideCloseButton = options.HideCloseButton.Value;

            ComponentDisableBackgroundCancel = DisableBackgroundCancel;
            if (options.DisableBackgroundCancel.HasValue)
                ComponentDisableBackgroundCancel = options.DisableBackgroundCancel.Value;

            

            ComponentPosition = string.IsNullOrWhiteSpace(options.Position) ? Position : options.Position;
            if (string.IsNullOrWhiteSpace(ComponentPosition))
                ComponentPosition = _defaultPosition;

            ComponentStyle = string.IsNullOrWhiteSpace(options.Style) ? Style : options.Style;
            if (string.IsNullOrWhiteSpace(ComponentStyle))
                ComponentStyle = _defaultStyle;

            ComponentSize = string.IsNullOrWhiteSpace(options.Size) ? Size : options.Size;
            if (string.IsNullOrWhiteSpace(ComponentSize))
                ComponentSize = _defaultSize;

            
        }
    }
}
