using Payments.Attributes;
using Payments.Wechatpay.Parameters.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 提交付款码支付
    /// </summary>
    [PayService("微信提交付款码支付")]
    public interface IWechatpayMicroPayService : IWechatpayPayService<WechatpayMicroPayRequest>
    {
    }
}
