using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourSpace.Modules.ModalWindow;
using YourSpace.Attributes;
using System.Reflection;
using YourSpace.Components;
using YourSpace.Modules.Pages.Blocks;
using YourSpace.Modules.Gallery;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Localization;
using YourSpace.Resources;
using YourSpace.Resources.ValidationMessages;

namespace YourSpace.Components
{
    public class CSetupPageBlock : CModalTemplete
    {
        [Parameter] public EventCallback eventValueChanged { get; set; }
        [Parameter] public MPageBlock Block { get; set; }
        protected Setting[] SettingsForSetting { get; set; }
        
        [Inject] public IStringLocalizer<CSetupPageBlock> L { get; set; }

        protected override void OnInitialized()
        {
            Type type = Block.GetType();
            PropertyInfo[] properties = type.GetProperties();
            List<Setting> listSettings = new List<Setting>();
            foreach (PropertyInfo property in properties)
            {
                object[] attrs = property.GetCustomAttributes(false);

                foreach(var v in attrs)
                {
                    if(v.GetType().IsAssignableFrom(typeof(AttributeSettingPageBlock)))
                    {
                        AttributeSettingPageBlock attr = (AttributeSettingPageBlock)v;
                        listSettings.Add(new Setting() { Label = attr.Label, Property = property });
                        break;
                    }
                    
                }
                
            }
            SettingsForSetting = listSettings.ToArray();

        }

        public RenderFragment Render<T,ValueModel>(Setting setting) where T : ComponentBase => builder =>
        {
            Type input = typeof(T);
            Type mValue = typeof(ValueModel);

            PropertyInfo property = setting.Property;
            builder.OpenComponent(0, input);

            var val = property.GetValue(Block);
            builder.AddAttribute(1, "Value", val);
            builder.AddAttribute(3, "ValueChanged", RuntimeHelpers.TypeCheck<
                EventCallback<ValueModel>>(
                EventCallback.Factory.Create<ValueModel>(this, 
                EventCallback.Factory.CreateInferred(this, __value => property.SetValue(Block, __value), 
                (ValueModel)property.GetValue(Block)))));

            var constant = System.Linq.Expressions.Expression.Constant(Block, Block.GetType());
            var exp = System.Linq.Expressions.MemberExpression.Property(constant, property);
            var lamb = System.Linq.Expressions.Expression.Lambda(exp);

            builder.AddAttribute(4, "ValueExpression", lamb);
            var label = L.GetAllStrings().Select(n=>n.Value).ToList();
            builder.AddAttribute(5, "Label", L[setting.Label]);

            builder.CloseComponent();
        };

        private void ValueChanged()
        {
            if (eventValueChanged.HasDelegate)
            {
                eventValueChanged.InvokeAsync(this);
            }
        }
    }

    public struct Setting
    {
        public PropertyInfo Property;
        public string Label;
    }

}
