using WechatPay.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WechatPay.Configs
{
    public interface IWehcatPayServiceProvider
    {
        TWehcatService GetService<TWehcatService>(string configName = "default") where TWehcatService : class;


        TWehcatService GetService<TWehcatService>(WechatPayConfig WechatPayConfig) where TWehcatService : class;
    }
}
