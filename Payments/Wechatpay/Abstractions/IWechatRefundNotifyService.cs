using Payments.Attributes;
using Payments.Core.Enum;
using Payments.WechatPay.Parameters.Response;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 订单退款通知服务
    /// </summary>
    [PayService("订单退款通知服务", PayOriginType.WechatPay)]
    public interface IWechatRefundNotifyService : IWechatConfigSetter, IWechatNotifyService<WechatRefundNotifyResponse>
    {

      


    }
}
