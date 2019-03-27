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
    /// 申请解约服务
    /// </summary>   
    [PayService("申请解约服务", PayOriginType.WechatPay)]
    public interface IWechatDeleteContractService
    {
        /// <summary>
        /// 解约
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatpayResult<WechatDeleteContractResponse>> Cancel(WechatDeleteContractRequest request);

    }
}
