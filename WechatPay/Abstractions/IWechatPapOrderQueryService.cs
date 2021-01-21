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
    /// 查询扣款订单服务
    /// </summary>
    [PayService("查询扣款订单服务", PayOriginType.WechatPay)]
    public interface IWechatPapOrderQueryService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 扣款
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatPapOrderQueryResponse>> Query(WechatPapOrderQueryRequest request);
    }
}
