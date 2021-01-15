using Payments.Attributes;
using Payments.Core.Enum;
using Payments.WechatPay.Parameters.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 微信Native场景一支付
    /// </summary>
    [PayService("微信Native场景一支付", PayOriginType.WechatPay)]
    public interface IWechatPayNativePayOneService: IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 构造url
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<string> BuildUrl(WechatPayNativePayOneRequest param);
    }
}
