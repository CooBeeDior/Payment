using Microsoft.Extensions.DependencyInjection;
using Payments.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliPay.Configs
{
    public class AliPayServiceProvider : IAliPayServiceProvider
    {
        private readonly IServiceProvider _serviceProvider;
        public AliPayServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public TAliPayService GetService<TAliPayService>(string configName = "default") where TAliPayService : class
        {
            var AliPayConfigFactory = _serviceProvider.GetService<IAliPayConfigFactory>();
            if (AliPayConfigFactory == null)
            {
                throw new Exception($"未找到服务{typeof(IAliPayConfigFactory).FullName}的实现");
            }
            var AliPayConfig = AliPayConfigFactory.GetConfig(configName);
            return this.GetService<TAliPayService>(AliPayConfig);

        }

        public TAliPayService GetService<TAliPayService>(AliPayConfig AliPayConfig) where TAliPayService : class
        {
            AliPayConfig.CheckNull(nameof(AliPayConfig));
            var service = _serviceProvider.GetService(typeof(TAliPayService)) as TAliPayService;
            if (service == null)
            {
                throw new Exception($"未找到服务{typeof(TAliPayService).FullName}的实现");
            }
            if (service is IAliPayConfigSetter wechatConfigSetter)
            {
                wechatConfigSetter.SetConfig(AliPayConfig);
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
                    else if (item.ParameterType == typeof(AliPayConfig))
                    {
                        flag = true;
                        args.Add(AliPayConfig);
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
                    throw new Exception($"方法SetConfig缺少AliPayConfig参数");
                }
                methodType.Invoke(service, args.ToArray());
            }
            return service;
        }
    }
}
