using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Wechatpay.Parameters.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信JsApi支付服务
    /// </summary>
    [PayService("微信JsApi支付", PayOriginType.WechatPay)]
    public interface IWechatpayJsApiPayService : IWechatpayPayService<WechatpayJsApiPayRequest>
    {

    }
}
