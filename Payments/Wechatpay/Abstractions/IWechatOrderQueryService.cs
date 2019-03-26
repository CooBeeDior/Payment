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
    /// 订单查询服务
    /// </summary>
    [PayService("订单查询服务", PayOriginType.WechatPay)]
    public interface IWechatOrderQueryService  
    { 
        /// <summary>
      /// 订单查询
      /// </summary>
      /// <param name="param"></param>
      /// <returns></returns>
        Task<WechatpayResult<WechatOrderQueryResponse>> QueryAsync(WechatOrderQueryRequest param);
    }
}
