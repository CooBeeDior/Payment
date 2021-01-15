using Payments.Util.Validations;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payments.Core
{
    /// <summary>
    /// 支付通知服务
    /// </summary>
    public interface INotifyService :IWechatConfigSetter
    {         
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
