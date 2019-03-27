using Payments.Core;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Response;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 支付 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWechatpayPayService<TRequest, TResponse> where TRequest : WechatpayPayRequestBase where TResponse : WechatpayPayResponseBase
    {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatpayResult<TResponse>> PayAsync(TRequest request);
    }
}
