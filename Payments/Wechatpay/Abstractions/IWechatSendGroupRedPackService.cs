using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
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
    /// 发放裂变红包服务
    /// </summary>
    [PayService("发放裂变红包服务", PayOriginType.WechatPay)]
    public interface IWechatSendGroupRedPackService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 发红裂变红包
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatSendRedPackResponse>> SendGroupReadPack(WechatSendRedPackRequest request);
    }
}
