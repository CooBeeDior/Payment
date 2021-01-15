using Payments.Attributes;
using Payments.Core.Enum;
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
    /// 支付中签约服务
    /// </summary>
    [PayService("支付中签约服务", PayOriginType.WechatPay)]
    public interface IWechatContractOrderService: IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 签约
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatContractOrderResponse>> Sign(WechatContractOrderRequest request);

    }
}
