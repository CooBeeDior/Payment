using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Configs;
using WechatPay.Parameters.Response;


namespace WechatPay.Abstractions
{

    /// <summary>
    /// 签约、解约结果通知
    /// </summary>
    [PayService("微信签约通知服务", PayOriginType.WechatPay)]
    public interface IWechatSignNotifyService : IWechatConfigSetter, IWechatNotifyService<WechatSignNotifyResponse>
    {
       
    }
}
