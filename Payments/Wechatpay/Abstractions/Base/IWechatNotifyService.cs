using Payments.Core;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;

namespace Payments.Wechatpay.Abstractions.Base
{
    /// <summary>
    /// 支付通知服务
    /// </summary>
    public interface IWechatNotifyService<TResponse> : INotifyService where TResponse : WechatpayResponse
    {
        /// <summary>
        /// 请求结果
        /// </summary>
        WechatpayResult<TResponse> Result { get; }

    }
}
