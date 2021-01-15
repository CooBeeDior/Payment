﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.WechatPay.Configs
{
    public interface IWechatPayConfigFactory
    {     

        WechatPayConfig GetConfig(string name);

        Task<WechatPayConfig> GetConfigAsync(string name);
    }
}
