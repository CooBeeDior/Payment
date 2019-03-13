using Payments.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class PayServiceAttribute : Attribute
    {
        public PayServiceAttribute(string Name) : this(Name, PayOriginType.Other)
        {

        }

        public PayServiceAttribute(string Name, PayOriginType PayOriginType)
        {
            this.Name = Name;
            this.PayOriginType = PayOriginType;
        }
        public string Name { get; }

        public PayOriginType PayOriginType { get; } = PayOriginType.Other;
    }
}
