using Payments.Attributes;
using Payments.Core;
using Payments.Core.Enum;
using Payments.Wechatpay.Parameters.Response;

namespace Payments.Wechatpay.Abstractions {
    /// <summary>
    /// 微信支付通知服务
    /// </summary>
    [PayService("微信支付通知服务", PayOriginType.WechatPay)]
    public interface IWechatpayNotifyService : INotifyService<WechatpayNotifyResponse> {
    }
}
