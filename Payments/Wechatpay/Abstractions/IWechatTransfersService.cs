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
    /// 企业转账服务
    /// </summary>
    [PayService("企业转账服务", PayOriginType.WechatPay)]
    public interface IWechatTransfersService
    {
        Task<PayResult> Transfer(WechatTransfersRequest param);
    }
}
