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
    /// 查询签约关系服务
    /// </summary>
    [PayService("查询签约关系服务", PayOriginType.WechatPay)]
    public interface IWechatQueryContractService
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatpayResult<WechatQueryContractResponse>> Query(WechatQueryContractRequest request);
    }
}
