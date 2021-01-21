using Payments.Attributes;
using Payments.Core.Enum;
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
    /// 支付中签约服务
    /// </summary>
    [PayService("支付中签约服务", PayOriginType.WechatPay)]
    public interface IWechatContractOrderService: IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 签约
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatContractOrderResponse>> Sign(WechatContractOrderRequest request);

    }
}
