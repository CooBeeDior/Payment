using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System.Threading.Tasks;
using WechatPay.Configs;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 查询红包记录服务
    /// </summary>
    [PayService("查询红包记录服务", PayOriginType.WechatPay)]
    public interface IWechatPayHbInfoService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatPayHbInfoResponse>> Query(WechatPayHbInfoRequest request);
    }
}
