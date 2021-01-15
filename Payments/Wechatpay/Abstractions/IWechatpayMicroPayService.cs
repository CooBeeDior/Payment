using Payments.Attributes;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 提交付款码支付
    /// </summary>
    [PayService("微信付款码支付")]
    public interface IWechatPayMicroPayService : IWechatConfigSetter, IWechatPayExtParam, IWechatPayPayService<WechatPayMicroPayRequest, WechatPayMicroPayResponse>
    {
    }
}
