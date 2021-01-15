using WechatPay.Abstractions;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System.Threading.Tasks;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 支付 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWechatPayPayService<TRequest, TResponse> : IWechatConfigSetter,IWechatPayExtendParam where TRequest : WechatPayPayRequestBase where TResponse : WechatPayPayResponseBase
    {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<TResponse>> PayAsync(TRequest request);
    }
}
