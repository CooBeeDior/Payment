using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Exceptions
{
    public class PayException : Exception
    {
        public PayException(ValidationResultCollection validationResultCollection) : base(validationResultCollection?.ToString())
        {
         
        }
    }
}
