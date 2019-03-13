using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Enum
{
    /// <summary>
    /// 支付种类
    /// </summary>
    public enum PayOriginType
    {
        /// <summary>
        /// 微信支付
        /// </summary>
        WechatPay,
        /// <summary>
        /// 支付宝支付
        /// </summary>
        AliPay,
        /// <summary>
        /// 银联支付
        /// </summary>
        UnionPay,
        /// <summary>
        /// PayPal
        /// </summary>
        PayPal,
        /// <summary>
        /// 其他
        /// </summary>
        Other

    }
}
