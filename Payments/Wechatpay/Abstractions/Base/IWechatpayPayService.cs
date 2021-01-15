using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using System.Threading.Tasks;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 支付 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWechatPayPayService<TRequest, TResponse> : IWechatConfigSetter,IWechatPayExtParam where TRequest : WechatPayPayRequestBase where TResponse : WechatPayPayResponseBase
    {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<TResponse>> PayAsync(TRequest request);
    }
}
