using Payments.Core;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 支付通知服务
    /// </summary>
    public interface IWechatNotifyService<TResponse> : INotifyService, IWechatConfigSetter where TResponse : WechatPayResponse
    {
        /// <summary>
        /// 请求结果
        /// </summary>
        WechatPayResult<TResponse> Result { get; }

    }
}
