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
    /// 申请解约服务
    /// </summary>   
    [PayService("申请解约服务", PayOriginType.WechatPay)]
    public interface IWechatDeleteContractService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 解约
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatDeleteContractResponse>> Cancel(WechatDeleteContractRequest request);

    }
}
