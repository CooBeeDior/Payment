using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 查询签约关系服务
    /// </summary>
    [PayService("查询签约关系服务", PayOriginType.WechatPay)]
    public interface IWechatQueryContractService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatQueryContractResponse>> Query(WechatQueryContractRequest request);
    }
}
