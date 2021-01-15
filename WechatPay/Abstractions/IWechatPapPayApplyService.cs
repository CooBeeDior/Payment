using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System.Threading.Tasks;

namespace WechatPay.Abstractions
{

    /// <summary>
    /// 申请扣款
    /// </summary>
    [PayService("申请扣款服务", PayOriginType.WechatPay)]
    public interface IWechatPapPayApplyService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 扣款
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatPapPayApplyResponse>> Deduct(WechatPapPayApplyRequest request);
    }
}
