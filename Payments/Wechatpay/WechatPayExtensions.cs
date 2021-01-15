using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Extensions;
using Payments.WechatPay.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Payments.WechatPay
{
    public static class WechatPayExtensions
    {
        public static IWechatBuilder AddWechatPay(this IServiceCollection services, WechatPayConfig defaultConfig = null)
        {
            var provider = new WechatPayConfigStorage();
            if (defaultConfig != null)
            {
                //添加默认的配置
                provider.AddWechatPayConfig("default", defaultConfig);
            }
            services.AddSingleton<IWechatPayConfigStorage>(provider);
            services.AddSingleton<IWechatPayConfigFactory, WechatPayConfigFactory>();
            services.AddSingleton<IWehcatPayServiceProvider, WehcatPayServiceProvider>();

            services.AddPayService(PayOriginType.WechatPay);
            return new WechatBuilder(services);
        }

        public static IWechatBuilder AddWechatPay(this IServiceCollection services, Action<WechatPayConfig> action = null)
        {
            var provider = new WechatPayConfigStorage();
            if (action != null)
            {
                WechatPayConfig defaultConfig = new WechatPayConfig();
                action(defaultConfig);
                //添加默认的配置
                provider.AddWechatPayConfig("default", defaultConfig);
            }
            services.AddSingleton<IWechatPayConfigStorage>(provider);
            services.AddSingleton<IWechatPayConfigFactory, WechatPayConfigFactory>();
            services.AddSingleton<IWehcatPayServiceProvider, WehcatPayServiceProvider>();

            services.AddPayService(PayOriginType.WechatPay);
            return new WechatBuilder(services);
        }
    }


}
