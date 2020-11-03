using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace YourSpace.Modules.Inputs
{
    public class AppInputBase<T> : InputBase<T>
    {


        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            throw new NotImplementedException();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ValueChanged = EventCallback.Factory.Create<T>(this, AppValueChanged);
        }

        private void AppValueChanged(T value)
        {

        }
    }
}
