using Payments.Attributes;
using Payments.Core.Enum;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using System.Threading.Tasks;

namespace Payments.WechatPay.Abstractions
{

    /// <summary>
    /// 申请扣款
    /// </summary>
    [PayService("申请扣款服务", PayOriginType.WechatPay)]
    public interface IWechatPapPayApplyService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 扣款
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatPapPayApplyResponse>> Deduct(WechatPapPayApplyRequest request);
    }
}
