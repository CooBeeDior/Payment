using Payments.Attributes;
using Payments.Core.Enum;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 微信JsAPi支付
    /// </summary>

    [PayService("微信JsApi支付", PayOriginType.WechatPay)]
    public interface IWechatPayJsApiPayService : IWechatConfigSetter, IWechatPayExtParam, IWechatPayPayService<WechatPayJsApiPayRequest, WechatPayJsApiPayResponse>
    {

    }
}
