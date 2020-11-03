using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.ModalWindow
{
    public class ModalResult
    {

        public object Data { get; }
        public Type DataType { get; }
        public bool Cancelled { get; }
        public Type ModalType { get; set; }

        public ModalResult(object data, Type resultType, bool cancelled, Type modalType)
        {
            Data = data;
            DataType = resultType;
            Cancelled = cancelled;
            ModalType = modalType;
        }

        public static ModalResult OK<T>(T result) => OK(result, default);
        public static ModalResult OK<T>(T result, Type modalType) => new ModalResult(result, typeof(T), false, modalType);
        public static ModalResult Cancel() => Cancel(default);
        public static ModalResult Cancel(Type modalType) => new ModalResult(default, typeof(object), true, modalType);
    }
}
