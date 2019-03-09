using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Util.Validations
{
    /// <summary>
    /// 验证操作
    /// </summary>
    public interface IValidation
    {
        /// <summary>
        /// 验证
        /// </summary>
        ValidationResultCollection Validate();
    }
}
