using Payments.Core;
using Payments.Util.Validations;
using Payments.Util.Validations.Attribbutes;
using WechatPay.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 退款订单
    /// </summary>
    public class WechatRefundOrderRequest : Validation, IWechatPayRequest,IValidation
    {
        /// <summary>
        /// 微信订单号
        /// </summary>   
        [MaxLength(32)]
        public virtual string TransactionId { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>   
        [MaxLength(32)]
        public virtual string OutTradeNo { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary> 
        [Required]
        [MaxLength(32)]
        public virtual string OutRefundNo { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        [Required]
        [MinValue(0)]
        public virtual decimal TotalFee { get; set; }

        /// <summary>
        /// 退款金额 
        /// </summary>
        [Required]
        [MinValue(0)]
        public virtual decimal RefundFee { get; set; }

        /// <summary>
        /// 退款货币种类
        /// </summary>
        [MaxLength(8)]
        public virtual FeeType? RefundFeeType { get; set; }

        /// <summary>
        /// 退款原因
        /// </summary>
        [MaxLength(80)]
        public virtual string RefundDesc { get; set; }

        /// <summary>
        /// 退款资金来源
        /// </summary>
        [MaxLength(30)]
        public virtual string RefundAccount { get; set; }

        /// <summary>
        /// 退款结果通知url
        /// </summary>
        [MaxLength(256)]
        public virtual string NotifyUrl { get; set; }
    }
}
