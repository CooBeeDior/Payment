using Payments.Attributes;
using Payments.Core;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Abstractions.Base;
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
    /// 签约、解约结果通知
    /// </summary>
    [PayService("微信签约通知服务", PayOriginType.WechatPay)]
    public interface IWechatSignNotifyService : IWechatNotifyService<WechatSignNotifyResponse>
    {
       
    }
}
