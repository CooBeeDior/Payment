using Payments.Attributes;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 提交付款码支付
    /// </summary>
    [PayService("微信付款码支付")]
    public interface IWechatPayMicroPayService : IWechatConfigSetter, IWechatPayExtendParam, IWechatPayPayService<WechatPayMicroPayRequest, WechatPayMicroPayResponse>
    {
    }
}
