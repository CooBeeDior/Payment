using Payments.Attributes;
using Payments.Core.Enum;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 微信Native支付服务
    /// </summary>
    [PayService("微信Native支付", PayOriginType.WechatPay)]
    public interface IWechatPayNativePayService : IWechatConfigSetter, IWechatPayExtParam, IWechatPayPayService<WechatPayNativePayRequest, WechatPayNativePayResponse>
    {

    }
}
