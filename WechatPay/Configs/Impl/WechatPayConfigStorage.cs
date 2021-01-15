using Payments.Exceptions;
using Payments.Extensions;
using Payments.Util.ParameterBuilders;
using WechatPay.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace WechatPay.Configs
{
     
    public class WechatPayConfigStorage : IWechatPayConfigStorage
    {
        private ConcurrentDictionary<string, WechatPayConfig> dic = new ConcurrentDictionary<string, WechatPayConfig>();


        public void AddWechatPayConfig(string name, WechatPayConfig WechatPayConfig)
        {
            WechatPayConfig.Validate();
            dic.TryAdd(name, WechatPayConfig);
        }

        public Task<WechatPayConfig> GetConfigAsync(string name)
        {
            return Task.FromResult(this.GetConfig(name));
        }

        public WechatPayConfig GetConfig(string name)
        {
            WechatPayConfig WechatPayConfig = null;
            if (!dic.TryGetValue(name, out WechatPayConfig))
            {
                throw new Exception($"不存在{name}该配置");
            }

            return WechatPayConfig;
        }
    } 
   

}
