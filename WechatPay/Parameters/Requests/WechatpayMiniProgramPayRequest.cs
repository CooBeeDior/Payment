using Payments.Core;
using System.ComponentModel.DataAnnotations;

namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 微信小程序支付参数
    /// </summary>
    public class WechatPayMiniProgramPayRequest : WechatPayPayRequestBase
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        //[Required]
        [MaxLength(128)]
        public override string OpenId { get; set; }
    }
}