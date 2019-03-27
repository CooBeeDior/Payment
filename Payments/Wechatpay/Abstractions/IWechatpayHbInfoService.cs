using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using System.Threading.Tasks;
namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 查询红包记录服务
    /// </summary>
    [PayService("查询红包记录服务", PayOriginType.WechatPay)]
    public interface IWechatpayHbInfoService
    {
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatpayResult<WechatpayHbInfoResponse>> Query(WechatpayHbInfoRequest request);
    }
}
