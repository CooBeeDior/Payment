using Payments.WechatPay.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.WechatPay.Abstractions
{
    public interface IWechatConfigSetter
    {
        void SetConfig(WechatPayConfig config);
    }
}
