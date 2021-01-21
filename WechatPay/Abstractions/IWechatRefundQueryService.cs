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
using WechatPay.Configs;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 退款订单查询
    /// </summary>
    [PayService("退款订单查询", PayOriginType.WechatPay)]
    public interface IWechatRefundQueryService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatRefundQueryResponse>> RefundQuery(WechatRefundQueryRequest request);
    }
}
