using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Payments.Core.Enum
{
    /// <summary>
    /// 支付签名类型
    /// </summary>
    public enum PaySignType
    {
        /// <summary>
        /// Md5
        /// </summary>
        [Description("MD5")]
        Md5,
        /// <summary>
        /// HMAC-SHA256
        /// </summary>
        [Description("HMAC-SHA256")]
        HmacSha256
    }
}
