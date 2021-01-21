using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using WechatPay.Configs;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 微信Native支付服务
    /// </summary>
    [PayService("微信Native支付", PayOriginType.WechatPay)]
    public interface IWechatPayNativePayService : IWechatConfigSetter, IWechatPayExtendParam, IWechatPayPayService<WechatPayNativePayRequest, WechatPayNativePayResponse>
    {

    }
}
