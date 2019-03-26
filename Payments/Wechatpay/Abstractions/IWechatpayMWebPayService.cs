using Payments.Attributes;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Wechatpay.Abstractions
{ /// <summary>
  /// 微信MWeb支付
  /// </summary>
    [PayService("微信MWeb支付")]
    public interface IWechatpayMWebPayService : IWechatpayPayService<WechatpayMWebPayRequest, WechatpayMWebPayResponse>
    {

    }


}
