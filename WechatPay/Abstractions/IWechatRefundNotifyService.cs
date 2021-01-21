using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Configs;
using WechatPay.Parameters.Response;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 订单退款通知服务
    /// </summary>
    [PayService("订单退款通知服务", PayOriginType.WechatPay)]
    public interface IWechatRefundNotifyService : IWechatConfigSetter, IWechatNotifyService<WechatRefundNotifyResponse>
    {

      


    }
}
