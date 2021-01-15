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
    /// 查询签约关系服务
    /// </summary>
    [PayService("查询签约关系服务", PayOriginType.WechatPay)]
    public interface IWechatQueryContractService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatQueryContractResponse>> Query(WechatQueryContractRequest request);
    }
}
