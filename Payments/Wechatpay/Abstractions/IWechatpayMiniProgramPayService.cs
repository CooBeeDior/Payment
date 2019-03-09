using Payments.Attributes;
using Payments.Wechatpay.Parameters.Requests;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信小程序支付服务
    /// </summary>
    [PayService("微信小程序支付")]
    public interface IWechatpayMiniProgramPayService : IWechatpayPayService<WechatpayMiniProgramPayRequest>
    {

    }
}