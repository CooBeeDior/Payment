using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信JsAPi支付
    /// </summary>

    [PayService("微信JsApi支付", PayOriginType.WechatPay)]
    public interface IWechatpayJsApiPayService : IWechatpayPayService<WechatpayJsApiPayRequest, WechatpayJsApiPayResponse>
    {

    }
}
