using WechatPay.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Payments.Core.Service;

namespace WechatPay.Configs
{
    public interface IWehcatPayServiceProvider: IPayServiceProvider
    { 

        TWehcatService GetService<TWehcatService>(WechatPayConfig wechatPayConfig) where TWehcatService : class;
    }
}
