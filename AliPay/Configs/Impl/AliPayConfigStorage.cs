using Payments.Exceptions;
using Payments.Extensions;
using Payments.Util.ParameterBuilders;
using AliPay.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace AliPay.Configs
{
     
    public class AliPayConfigStorage : IAliPayConfigStorage
    {
        private ConcurrentDictionary<string, AliPayConfig> dic = new ConcurrentDictionary<string, AliPayConfig>();


        public void AddAliPayConfig(string name, AliPayConfig AliPayConfig)
        {
            AliPayConfig.Validate();
            dic.TryAdd(name, AliPayConfig);
        }

        public Task<AliPayConfig> GetConfigAsync(string name)
        {
            return Task.FromResult(this.GetConfig(name));
        }

        public AliPayConfig GetConfig(string name)
        {
            AliPayConfig AliPayConfig = null;
            if (!dic.TryGetValue(name, out AliPayConfig))
            {
                throw new Exception($"不存在{name}该配置");
            }

            return AliPayConfig;
        }
    } 
   

}
