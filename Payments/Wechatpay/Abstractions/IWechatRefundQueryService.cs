using Payments.Attributes;
using Payments.Core;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 退款订单查询
    /// </summary>
    [PayService("退款订单查询", PayOriginType.WechatPay)]
    public interface IWechatRefundQueryService
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatpayResult<WechatRefundQueryResponse>> RefundQuery(WechatRefundQueryRequest request);
    }
}
