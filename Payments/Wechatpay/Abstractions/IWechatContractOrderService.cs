using Payments.Attributes;
using Payments.Core.Enum;
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
    /// 支付中签约服务
    /// </summary>
    [PayService("支付中签约服务", PayOriginType.WechatPay)]
    public interface IWechatContractOrderService
    {
        /// <summary>
        /// 签约
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatpayResult<WechatContractOrderResponse>> Sign(WechatContractOrderRequest request);

    }
}
