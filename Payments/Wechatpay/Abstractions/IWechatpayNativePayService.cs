using Payments.Attributes;
using Payments.Wechatpay.Parameters.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信Native支付服务
    /// </summary>
    [PayService("微信Native支付")]
    public interface IWechatpayNativePayService : IWechatpayPayService<WechatpayNativePayRequest>
    {

    }
}
