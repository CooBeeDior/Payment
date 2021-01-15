using Payments.Attributes;
using Payments.Core;
using Payments.Core.Enum;
using Payments.Core.Response;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 订单退款服务
    /// </summary>
    [PayService("订单退款服务", PayOriginType.WechatPay)]
    public interface IWechatRefundOrderService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatRefundOrderResponse>> RefundAsync(WechatRefundOrderRequest request);
    }
}
