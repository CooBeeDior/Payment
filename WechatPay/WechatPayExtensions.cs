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
using System.Security.Authentication;

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
                    var certificate = new X509Certificate2(WechatPayConfig.CertificateData, WechatPayConfig.CertificatePwd, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
                    var handler = new HttpClientHandler()
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        SslProtocols = SslProtocols.Tls12,
                    };
                    handler.ClientCertificates.Add(certificate);
                    handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                    return handler;
                });
            }

        }

    }


}
