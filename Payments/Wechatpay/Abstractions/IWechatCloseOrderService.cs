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
    /// 关闭订单服务
    /// </summary>
    [PayService("关闭订单服务", PayOriginType.WechatPay)]
    public interface IWechatCloseOrderService: IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatCloseOrderResponse>> CloseAsync(WechatCloseOrderRequest request);
    }
}
