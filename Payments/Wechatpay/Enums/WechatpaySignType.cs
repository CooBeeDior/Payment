using System.ComponentModel;

namespace Payments.WechatPay.Enums
{
    /// <summary>
    /// 微信支付签名类型
    /// </summary>
    public enum WechatPaySignType
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
