using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using System.Threading.Tasks;
namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 查询红包记录服务
    /// </summary>
    [PayService("查询红包记录服务", PayOriginType.WechatPay)]
    public interface IWechatPayHbInfoService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatPayHbInfoResponse>> Query(WechatPayHbInfoRequest request);
    }
}
