using Payments.Util.Validations;
using Payments.Util.Validations.Attribbutes;
using Payments.Wechatpay.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 申请扣款
    /// </summary>
    public class WechatPapPayApplyRequest : Validation, IWechatpayRequest, IValidation
    {
        /// <summary>
        /// 订单标题
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Body { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        [MaxLength(8192)]
        public virtual string Detail { get; set; }
        /// <summary>
        /// 附加数据
        /// </summary>
        [MaxLength(128)]
        public virtual string Attach { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string OutTradeNo { get; set; }

        /// <summary>
        /// 支付金额， 
        /// </summary>
        [Required]
        [MinValue(0)]
        public virtual decimal TotalFee { get; set; }


        /// <summary>
        /// 货币类型
        /// </summary>
        public virtual FeeType? FeeType { get; set; }

        /// <summary>
        /// 订单优惠标记
        /// </summary>
        [MaxLength(32)]
        public virtual string GoodsTag { get; set; }


        /// <summary>
        /// 回调通知地址
        /// </summary>
        //[Required]
        public virtual string NotifyUrl { get; set; }

        /// <summary>
        /// 委托代扣协议id
        /// </summary>
        public virtual string ContractId { get; set; }


        /// <summary>
        /// 电子发票入口开放标识 Y，传入Y时，支付成功消息和支付详情页将出现开票入口
        /// </summary>
        [MaxLength(8)]
        public virtual string Receipt { get; set; }

    }
}
