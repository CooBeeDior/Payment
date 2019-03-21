using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
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
        /// <param name="param"></param>
        /// <returns></returns>
        Task<PayResult> Query(WechatpayHbInfoRequest param);
    }
}
