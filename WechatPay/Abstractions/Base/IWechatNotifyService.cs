using Payments.Core;
using WechatPay.Configs;
using WechatPay.Parameters.Response;
using WechatPay.Results;

namespace WechatPay.Abstractions
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
