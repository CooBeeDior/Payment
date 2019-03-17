using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// Native场景一支付
    /// </summary>
    public class WechatpayNativePayOneRequest : Validation, IWechatpayRequest, IValidation
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string ProductId { get; set; }
    }
}
