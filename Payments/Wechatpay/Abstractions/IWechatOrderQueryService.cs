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
    /// 订单查询服务
    /// </summary>
    [PayService("订单查询服务", PayOriginType.WechatPay)]
    public interface IWechatOrderQueryService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returnsrequest
        Task<WechatPayResult<WechatOrderQueryResponse>> QueryAsync(WechatOrderQueryRequest request);
    }
}
