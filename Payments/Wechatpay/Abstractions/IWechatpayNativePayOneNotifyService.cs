using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Wechatpay.Parameters.Requests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信扫码支付异步回调
    /// </summary>
    [PayService("微信扫码支付异步回调", PayOriginType.WechatPay)]
    public interface IWechatpayNativePayOneNotifyService
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> ReturnMessage(WechatpayNativePayRequest request);
    }
}
