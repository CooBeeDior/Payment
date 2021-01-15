using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Extensions;
using WechatPay.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;

namespace WechatPay
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

            services.AddPayService(typeof(WechatPayExtensions).Assembly, PayOriginType.WechatPay);
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

            services.AddPayService(typeof(WechatPayExtensions).Assembly, PayOriginType.WechatPay);
            return new WechatBuilder(services);
        }

        public static void AddHttpClient(this IServiceCollection services, string name, WechatPayConfig WechatPayConfig)
        {
            if (WechatPayConfig.CertificateData != null)
            {
                services.AddHttpClient(name).ConfigurePrimaryHttpMessageHandler(() =>
                {
                    var certificate = new X509Certificate2(WechatPayConfig.CertificateData, WechatPayConfig.CertificatePwd, X509KeyStorageFlags.MachineKeySet);
                    var handler = new HttpClientHandler();
                    handler.ClientCertificates.Add(certificate);
                    return handler;
                });
            }

        }

    }


}
