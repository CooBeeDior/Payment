using Payments.Attributes;
using Payments.Core;
using Payments.Core.Enum;
using Payments.Wechatpay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 订单退款通知服务
    /// </summary>
    [PayService("订单退款通知服务", PayOriginType.WechatPay)]
    public interface IWechatRefundNotifyService : INotifyService<WechatRefundNotifyResponse>
    {

      


    }
}
