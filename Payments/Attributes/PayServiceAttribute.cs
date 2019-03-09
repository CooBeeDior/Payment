using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class PayServiceAttribute : Attribute
    {
        public PayServiceAttribute(string Name)
        {
            this.Name = Name;
        }
        public string Name { get; }
    }
}
