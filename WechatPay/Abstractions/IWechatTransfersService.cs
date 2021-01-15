using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
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
    /// 企业转账服务
    /// </summary>
    [PayService("企业转账服务", PayOriginType.WechatPay)]
    public interface IWechatTransfersService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 转账
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatTransfersResponse>> Transfer(WechatTransfersRequest request);
    }
}
