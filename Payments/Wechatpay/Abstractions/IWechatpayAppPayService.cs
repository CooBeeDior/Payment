using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Parameters.Response.Base;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信App支付服务
    /// </summary>
    [PayService("微信App支付", PayOriginType.WechatPay)]
    public interface IWechatpayAppPayService : IWechatpayPayService<WechatpayAppPayRequest, WechatpayAppPayResponse>
    {

    }
}
