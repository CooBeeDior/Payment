using Payments.Attributes;
using Payments.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 扣款结果通知
    /// </summary>
    [PayService("扣款结果通知", PayOriginType.WechatPay)]
    public interface IWechatContractNotifyService : IWechatConfigSetter
    {
    }
}
