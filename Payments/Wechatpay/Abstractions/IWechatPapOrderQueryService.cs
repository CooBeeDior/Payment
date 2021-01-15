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
    /// 查询扣款订单服务
    /// </summary>
    [PayService("查询扣款订单服务", PayOriginType.WechatPay)]
    public interface IWechatPapOrderQueryService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 扣款
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatPapOrderQueryResponse>> Query(WechatPapOrderQueryRequest request);
    }
}
