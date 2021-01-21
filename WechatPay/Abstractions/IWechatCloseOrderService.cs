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
    /// 关闭订单服务
    /// </summary>
    [PayService("关闭订单服务", PayOriginType.WechatPay)]
    public interface IWechatCloseOrderService: IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatCloseOrderResponse>> CloseAsync(WechatCloseOrderRequest request);
    }
}
