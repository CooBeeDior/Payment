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
    /// 订单查询服务
    /// </summary>
    [PayService("订单查询服务", PayOriginType.WechatPay)]
    public interface IWechatOrderQueryService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returnsrequest
        Task<WechatPayResult<WechatOrderQueryResponse>> QueryAsync(WechatOrderQueryRequest request);
    }
}
