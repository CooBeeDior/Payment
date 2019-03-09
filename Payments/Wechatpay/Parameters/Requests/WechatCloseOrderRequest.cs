using Payments.Core;
using Payments.Exceptions;
using Payments.Properties;
using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 关闭订单
    /// </summary>
    public class WechatCloseOrderRequest : Validation, IWechatpayRequest, IValidation
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessageResourceType = typeof(PayResource), ErrorMessageResourceName = "OutTradeNo32")]
        public string OutTradeNo { get; set; }




    }
}
