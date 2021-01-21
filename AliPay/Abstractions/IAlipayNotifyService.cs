using Payments.Attributes;
using Payments.Core;

namespace AliPay.Abstractions {
    /// <summary>
    /// 支付宝通知服务
    /// </summary>
    [PayService("支付宝通知服务")]
    public interface IAlipayNotifyService : INotifyService {
        /// <summary>
        /// 买家支付宝用户号
        /// </summary>
        string BuyerId { get; }
    }
}
