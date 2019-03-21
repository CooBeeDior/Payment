using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Wechatpay.Parameters.Requests;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信提交付款码支付
    /// </summary>

    [PayService("微信JsApi支付", PayOriginType.WechatPay)] 
    public interface IWechatpayJsApiPayService : IWechatpayPayService<WechatpayJsApiPayRequest>
    {

    }
}
