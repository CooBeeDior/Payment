using Payments.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 微信JsApi支付参数
    /// </summary>
    public class WechatpayJsApiPayRequest : WechatpayPayRequestBase
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        [Required]
        [MaxLength(128)]
        public override string OpenId { get; set; }
    }

}
