using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payments.WechatPay.Parameters.Requests
{
    /// <summary>
    /// 查询扣款订单服务
    /// </summary>
    public class WechatPapOrderQueryRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 微信订单号
        /// </summary>
        [MaxLength(32)]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [MaxLength(32)]
        public string OutTradeNo { get; set; }
    }
}
