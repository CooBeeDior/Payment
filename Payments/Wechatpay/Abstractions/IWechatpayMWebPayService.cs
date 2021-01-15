using Payments.Attributes;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.WechatPay.Abstractions
{ /// <summary>
  /// 微信MWeb支付
  /// </summary>
    [PayService("微信MWeb支付")]
    public interface IWechatPayMWebPayService : IWechatConfigSetter, IWechatPayExtParam, IWechatPayPayService<WechatPayMWebPayRequest, WechatPayMWebPayResponse>
    {

    }


}
