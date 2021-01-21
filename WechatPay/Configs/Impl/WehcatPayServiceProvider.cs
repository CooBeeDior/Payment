using Payments.Extensions;
using WechatPay.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq;

namespace WechatPay.Configs
{
    public class WehcatPayServiceProvider : IWehcatPayServiceProvider
    {
        private readonly IServiceProvider _serviceProvider;
        public WehcatPayServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public TWehcatService GetService<TWehcatService>(string configName = "default") where TWehcatService : class
        {
            var wechatPayConfigFactory = _serviceProvider.GetService<IWechatPayConfigFactory>();
            if (wechatPayConfigFactory == null)
            {
                throw new Exception($"未找到服务{typeof(IWechatPayConfigFactory).FullName}的实现");
            }
            var wechatPayConfig = wechatPayConfigFactory.GetConfig(configName);
            return this.GetService<TWehcatService>(wechatPayConfig);

        }

        public TWehcatService GetService<TWehcatService>(WechatPayConfig wechatPayConfig) where TWehcatService : class
        {
            wechatPayConfig.CheckNull(nameof(WechatPayConfig));
            var service = _serviceProvider.GetService(typeof(TWehcatService)) as TWehcatService;
            if (service == null)
            {
                throw new Exception($"未找到服务{typeof(TWehcatService).FullName}的实现");
            }
            if (service is IWechatConfigSetter wechatConfigSetter)
            {
                wechatConfigSetter.SetConfig(wechatPayConfig);
            }
            else
            {
                var methodType = service.GetType().GetMethod("SetConfig");
                if (methodType == null)
                {
                    throw new Exception($"未找到方法SetConfig");
                }
                if (methodType.IsStatic || methodType.IsAbstract)
                {
                    throw new Exception($"未找到非静态或非抽象的方法SetConfig");
                }
                IList<object> args = new List<object>();
                bool flag = false;
                foreach (var item in methodType.GetParameters())
                {
                    if (item.HasDefaultValue)
                    {
                        args.Add(item.DefaultValue);
                    }
                    else if (item.ParameterType == typeof(WechatPayConfig))
                    {
                        flag = true;
                        args.Add(wechatPayConfig);
                    }
                    else if (item.IsOptional)
                    {

                    }
                    else
                    {
                        var arg = _serviceProvider.GetService(item.ParameterType);
                        args.Add(arg);
                    }

                }
                if (!flag)
                {
                    throw new Exception($"方法SetConfig缺少WechatPayConfig参数");
                }
                methodType.Invoke(service, args.ToArray());
            }
            return service;
        }
    }
}
