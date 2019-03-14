using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
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
        Task<PayResult> SendGroupReadPack(WechatSendRedPackRequest param);
    }
}
