using Payments.Attributes;
using Payments.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 企业付款到银行卡
    /// </summary>
    [PayService("企业付款到银行卡", PayOriginType.WechatPay)]
    public  interface IWechatPayBankService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatPayBankResponse>> Pay(WechatPayBankRequest request);
    }

 
}
