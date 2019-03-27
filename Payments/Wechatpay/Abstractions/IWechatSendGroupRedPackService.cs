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
    /// 发放裂变红包服务
    /// </summary>
    [PayService("发放裂变红包服务", PayOriginType.WechatPay)]
    public interface IWechatSendGroupRedPackService
    {
        /// <summary>
        /// 发红裂变红包
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatpayResult<WechatSendRedPackResponse>> SendGroupReadPack(WechatSendRedPackRequest request);
    }
}
