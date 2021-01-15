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
    /// 申请解约服务
    /// </summary>   
    [PayService("申请解约服务", PayOriginType.WechatPay)]
    public interface IWechatDeleteContractService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 解约
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatDeleteContractResponse>> Cancel(WechatDeleteContractRequest request);

    }
}
