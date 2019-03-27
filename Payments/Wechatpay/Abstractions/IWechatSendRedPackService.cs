using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
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
    /// 发放普通红包服务
    /// </summary>
    [PayService("发放普通红包服务", PayOriginType.WechatPay)]
    public interface IWechatSendRedPackService
    {
        /// <summary>
        /// 发送普通红包
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatpayResult<WechatSendRedPackResponse>> SendReadPack(WechatSendRedPackRequest request);
    }
}
