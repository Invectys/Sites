using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Attributes
{
    public class AttributeSettingPageBlock : System.Attribute
    {
        public string Label;

        public AttributeSettingPageBlock(string label)
        {
            Label = label;
        }
    }
}
