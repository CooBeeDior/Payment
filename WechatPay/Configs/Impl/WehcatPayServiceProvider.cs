using Payments.Extensions;
using WechatPay.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
namespace WechatPay.Configs
{
    public class WehcatPayServiceProvider : IWehcatPayServiceProvider
    {
        private readonly IServiceProvider _serviceProvider;
        public WehcatPayServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public TWehcatService GetService<TWehcatService>(string configName = "default") where TWehcatService : class, IWechatConfigSetter
        {
            configName.CheckNull(nameof(configName));
            var service = _serviceProvider.GetService(typeof(TWehcatService)) as TWehcatService;
            if (service == null)
            {
                throw new Exception($"未找到服务{typeof(TWehcatService).FullName}的实现");
            }
            var WechatPayConfigFactory = _serviceProvider.GetService<IWechatPayConfigFactory>();
            if (WechatPayConfigFactory == null)
            {
                throw new Exception($"未找到服务{typeof(IWechatPayConfigFactory).FullName}的实现");
            }
            var WechatPayConfig = WechatPayConfigFactory.GetConfig(configName);
            service.SetConfig(WechatPayConfig);
            return service;
        }

        public TWehcatService GetService<TWehcatService>(WechatPayConfig WechatPayConfig) where TWehcatService : class, IWechatConfigSetter
        {
            WechatPayConfig.CheckNull(nameof(WechatPayConfig));
            var service = _serviceProvider.GetService(typeof(TWehcatService)) as TWehcatService;
            if (service == null)
            {
                throw new Exception($"未找到服务{typeof(TWehcatService).FullName}的实现");
            }
            service.SetConfig(WechatPayConfig);
            return service;
        }
    }
}
