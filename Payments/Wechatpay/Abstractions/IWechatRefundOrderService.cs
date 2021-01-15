using Payments.Attributes;
using Payments.Core;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 订单退款服务
    /// </summary>
    [PayService("订单退款服务", PayOriginType.WechatPay)]
    public interface IWechatRefundOrderService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatRefundOrderResponse>> RefundAsync(WechatRefundOrderRequest request);
    }
}
