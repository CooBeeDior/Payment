using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Configs;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 微信JsAPi支付
    /// </summary>

    [PayService("微信JsApi支付", PayOriginType.WechatPay)]
    public interface IWechatPayJsApiPayService : IWechatConfigSetter, IWechatPayExtendParam, IWechatPayPayService<WechatPayJsApiPayRequest, WechatPayJsApiPayResponse>
    {

    }
}
