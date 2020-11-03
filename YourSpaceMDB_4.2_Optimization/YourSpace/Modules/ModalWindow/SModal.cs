using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using YourSpace.Services;

namespace YourSpace.Modules.ModalWindow
{
    public class SModal : ISModal
    {
        public event Action<ModalResult,int> OnClose;
        internal event Action<int> CloseModal;
        internal event Action<string, RenderFragment, ModalParameters, ModalOptions,int> OnShow;
        private Type _modaltype;


        private List<(int, Action<ModalResult>)> CloseActions = new List<(int, Action<ModalResult>)>();

        public SModal()
        {
            OnClose += CloseHandler;
        }

        public void Cancel(int modalId) 
        {
            CloseModal?.Invoke(modalId);
            OnClose?.Invoke(ModalResult.Cancel(_modaltype), modalId);
        }

        public void Cancel<T>() where T : ComponentBase
        {
            int modalId = GetDefaultModalInd(typeof(T));
            CloseModal?.Invoke(modalId);
            OnClose?.Invoke(ModalResult.Cancel(_modaltype),modalId);
        }

        public void Close(ModalResult result, int modalId)
        {
            result.ModalType = _modaltype;
            CloseModal?.Invoke(modalId);
            OnClose?.Invoke(result, modalId);
        }
        public void Close<T>(ModalResult result) where T : ComponentBase
        {
            int modalId = GetDefaultModalInd(typeof(T));
            result.ModalType = _modaltype;
            CloseModal?.Invoke(modalId);
            OnClose?.Invoke(result, modalId);
        }

        public void Show<T>(string title) where T : CModalTemplete
        {
            int modalId = GetDefaultModalInd(typeof(T));
            Show<T>(title, new ModalParameters(), new ModalOptions(), modalId);
        }
        public void Show<T>(string title, ModalParameters parameters) where T : CModalTemplete
        {
            int modalId = GetDefaultModalInd(typeof(T));
            Show<T>(title, parameters, new ModalOptions(), modalId);
        }
        public void Show<T>(string title, ModalParameters parameters, int modalId) where T : CModalTemplete
        {
            Show<T>(title, parameters, new ModalOptions(), modalId);
        }
        public void Show<T>(string title, ModalParameters parameters = null, ModalOptions options = null, int modalId = 1) where T : ComponentBase
        {
            Show(typeof(T), title, parameters, options, modalId);
        }
        public void Show(Type contentComponent, string title, ModalParameters modalParameters, ModalOptions options, int modalId = 1)
        {
            if(!typeof(CModalTemplete).IsAssignableFrom(contentComponent))
            {
                throw new Exception("Must be a modal component");
            }

            var content = new RenderFragment(x => { x.OpenComponent(1,contentComponent); x.AddAttribute(1,"ModalId",modalId); x.CloseComponent(); });
            _modaltype = contentComponent;


            OnShow?.Invoke(title, content, modalParameters, options, modalId);
        }
        public void Show(Type contentComponent,string title, ModalParameters parameters, ModalOptions options, Action<ModalResult> closeAction) 
        {
            int modalId = GetDefaultModalInd(contentComponent);
            CloseActions.Add((modalId, closeAction));
            Show(contentComponent,title, parameters, options, modalId);
        }
        public void Show<T>(string title, ModalParameters parameters,ModalOptions options,Action<ModalResult> closeAction) where T : CModalTemplete
        {
            int modalId = GetDefaultModalInd(typeof(T));

            if(closeAction != null) CloseActions.Add((modalId, closeAction));
            Show<T>(title, parameters, options, modalId);
        }
        public void Show<T>(string title, ModalParameters parameters,Action<ModalResult> closeAction) where T : CModalTemplete
        {
            Show<T>(title, parameters, new ModalOptions(), closeAction);
        }


        private void CloseHandler(ModalResult result,int modalId)
        {
            for(int i = 0; i < CloseActions.Count;i++)
            {
                (int, Action<ModalResult>) set = CloseActions[i];
                if(set.Item1 == modalId)
                {
                    /*if(!result.Cancelled) */set.Item2.Invoke(result);
                    CloseActions.RemoveAt(i);
                }
            }
        }
        private int GetDefaultModalInd(Type type)
        {
            MethodInfo method = type.GetMethod("GetDefaultModalId");
            if (method == null)
            {
                throw new Exception("Determine method GetDefaultModalId() with return type integer in" + type.FullName);
            }
            int modalId = (int)method.Invoke(null, null);
            return modalId;
        }
    }
}
