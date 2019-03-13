using Payments.Attributes;
using Payments.Core;
using Payments.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 订单退款通知服务
    /// </summary>
    [PayService("订单退款通知服务", PayOriginType.WechatPay)]
    public interface IWechatRefundNotifyService : INotifyService
    {

        /// <summary>
        /// 微信退款单号
        /// </summary>
        string RefundId { get; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        string OutRefundNo { get; }

        /// <summary>
        /// 退款总金额
        /// </summary>
        decimal RefundFee { get; }

        /// <summary>
        /// 退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        decimal SettlementRefundFee { get; }

        /// <summary>
        /// 退款成功时间
        /// </summary>
        DateTime SuccessTime { get; }


    }
}
