using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.WechatPay.Enums
{
    /// <summary>
    ///校验用户姓名选项
    /// </summary>
    public enum CheckNameType
    {
        /// <summary>
        /// 不校验真实姓名
        /// </summary>
        NO_CHECK,
        /// <summary>
        /// 强校验真实姓名
        /// </summary>
        FORCE_CHECK
    }
}
