using Payments.Attributes;
using Payments.Core.Enum;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 微信App支付服务
    /// </summary>
    [PayService("微信App支付", PayOriginType.WechatPay)]
    public interface IWechatPayAppPayService : IWechatConfigSetter, IWechatPayExtParam, IWechatPayPayService<WechatPayAppPayRequest, WechatPayAppPayResponse>
    {

    }
}
