using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Configs;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 微信App支付服务
    /// </summary>
    [PayService("微信App支付", PayOriginType.WechatPay)]
    public interface IWechatPayAppPayService : IWechatConfigSetter, IWechatPayExtendParam, IWechatPayPayService<WechatPayAppPayRequest, WechatPayAppPayResponse>
    {

    }
}
