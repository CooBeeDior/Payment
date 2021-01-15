using Payments.Attributes;
using Payments.Core.Enum;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 微信小程序支付服务
    /// </summary>
    [PayService("微信小程序支付", PayOriginType.WechatPay)]
    public interface IWechatPayMiniProgramPayService : IWechatConfigSetter, IWechatPayExtParam, IWechatPayPayService<WechatPayMiniProgramPayRequest, WechatPayMiniProgramPayResponse>
    {

    }
}