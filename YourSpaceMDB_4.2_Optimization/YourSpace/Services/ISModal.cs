//Показ модального окна 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using YourSpace.Modules.ModalWindow;

namespace YourSpace.Services
{
    public interface ISModal
    {
        event Action<ModalResult,int> OnClose;

        void Show<T>(string title) where T : CModalTemplete;
        void Show<T>(string title, ModalParameters parameters) where T : CModalTemplete;
        void Show<T>(string title, ModalParameters parameters, int modalId ) where T : CModalTemplete;
        void Show<T>(string title, ModalParameters parameters, Action<ModalResult> closeAction) where T : CModalTemplete;
        void Show(Type contentComponent, string title, ModalParameters parameters, ModalOptions options, Action<ModalResult> closeAction);
        void Show<T>(string title, ModalParameters parameters,ModalOptions options, Action<ModalResult> closeAction) where T : CModalTemplete;
        void Show(Type contentComponent, string title, ModalParameters modalParameters, ModalOptions options,int modalId = 1);
        void Close<T>(ModalResult result) where T : ComponentBase;
        void Close(ModalResult result, int modalId);
        void Cancel<T>() where T : ComponentBase;
        void Cancel(int modalId);
       
    }
}
