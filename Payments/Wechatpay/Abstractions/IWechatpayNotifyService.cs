using Payments.Attributes;
using Payments.Core.Enum;
using Payments.WechatPay.Parameters.Response;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 微信支付通知服务
    /// </summary>
    [PayService("微信支付通知服务", PayOriginType.WechatPay)]
    public interface IWechatPayNotifyService : IWechatConfigSetter, IWechatNotifyService<WechatPayNotifyResponse> {
    }
}
