using Payments.Attributes;
using Payments.Core;

namespace Payments.Wechatpay.Abstractions {
    /// <summary>
    /// 微信支付通知服务
    /// </summary>
    [PayService("微信支付通知服务")]
    public interface IWechatpayNotifyService : INotifyService {
    }
}
