using Payments.WechatPay.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.WechatPay.Configs
{
    public interface IWehcatPayServiceProvider
    {
        TWehcatService GetService<TWehcatService>(string configName = "default") where TWehcatService : class, IWechatConfigSetter;


        TWehcatService GetService<TWehcatService>(WechatPayConfig WechatPayConfig) where TWehcatService : class, IWechatConfigSetter;
    }
}
