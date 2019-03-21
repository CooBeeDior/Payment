using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
using System.Threading.Tasks;
namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 关闭订单服务
    /// </summary>
    [PayService("关闭订单服务", PayOriginType.WechatPay)]
    public interface IWechatCloseOrderService
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<PayResult> CloseAsync(WechatCloseOrderRequest param);
    }
}
