using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Abstractions
{

    /// <summary>
    /// 申请扣款
    /// </summary>
    [PayService("申请扣款服务", PayOriginType.WechatPay)]
    public interface IWechatPapPayApplyService  
    {
        /// <summary>
        /// 扣款
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatpayResult<WechatPapPayApplyResponse>> Deduct(WechatPapPayApplyRequest request);
    }
}
