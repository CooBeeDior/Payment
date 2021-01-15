using Payments.Core;
using Payments.Exceptions;
using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Payments.WechatPay.Parameters.Requests
{
    /// <summary>
    /// 查询订单
    /// </summary>
    public class WechatOrderQueryRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [MaxLength(32)]
        public virtual string OutTradeNo { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        [MaxLength(32)]
        public virtual string TransactionId { get; set; }


    }
}
