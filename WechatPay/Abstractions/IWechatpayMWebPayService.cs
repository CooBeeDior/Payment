using Payments.Attributes;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using WechatPay.Configs;

namespace WechatPay.Abstractions
{ /// <summary>
  /// 微信MWeb支付
  /// </summary>
    [PayService("微信MWeb支付")]
    public interface IWechatPayMWebPayService : IWechatConfigSetter, IWechatPayExtendParam, IWechatPayPayService<WechatPayMWebPayRequest, WechatPayMWebPayResponse>
    {

    }


}
