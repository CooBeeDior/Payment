using Payments.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payments.Util.Validations
{
    public class Validation : IValidation
    {
        /// <summary>
        /// 验证
        /// </summary>
        public virtual ValidationResultCollection Validate()
        {
            var result = DataAnnotationValidation.Validate(this);
            if (result.IsValid)
                return ValidationResultCollection.Success;
            throw new Warning(result.First().ErrorMessage);
        }
    }
}
