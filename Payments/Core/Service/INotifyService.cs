using Payments.Util.Validations;
using Payments.Wechatpay.Parameters.Response.Base;
using Payments.Wechatpay.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payments.Core
{
    /// <summary>
    /// 支付通知服务
    /// </summary>
    public interface INotifyService<TResponse> where TResponse : WechatpayResponse
    {
        /// <summary>
        /// 请求结果
        /// </summary>
        WechatpayResult<TResponse> Result { get; }
        /// <summary>
        /// 验证
        /// </summary>
        Task<ValidationResultCollection> ValidateAsync();
        /// <summary>
        /// 返回成功消息
        /// </summary>
        string Success();
        /// <summary>
        /// 返回失败消息
        /// </summary>
        string Fail();
    }
}
