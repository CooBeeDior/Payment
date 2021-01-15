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
    /// 发放普通红包服务
    /// </summary>
    [PayService("发放普通红包服务", PayOriginType.WechatPay)]
    public interface IWechatSendRedPackService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 发送普通红包
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatSendRedPackResponse>> SendReadPack(WechatSendRedPackRequest request);
    }
}
