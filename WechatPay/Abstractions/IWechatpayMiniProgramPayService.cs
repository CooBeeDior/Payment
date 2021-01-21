using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Configs;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 微信小程序支付服务
    /// </summary>
    [PayService("微信小程序支付", PayOriginType.WechatPay)]
    public interface IWechatPayMiniProgramPayService : IWechatConfigSetter, IWechatPayExtendParam, IWechatPayPayService<WechatPayMiniProgramPayRequest, WechatPayMiniProgramPayResponse>
    {

    }
}