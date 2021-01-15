using Microsoft.Extensions.DependencyInjection;
using Payments.Attributes;
using Payments.Core.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Payments.Extensions
{
    /// <summary>
    /// 支付扩展 注依赖ILoggerFactory  IHttpContextAccessor
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 注册阿里支付
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        //public static void AddAliPay(this IServiceCollection services, Action<AlipayConfig> setupAction = null)
        //{
        //    var alipayConfig = new AlipayConfig();
        //    setupAction?.Invoke(alipayConfig);
        //    services.AddSingleton<IAlipayConfigProvider>(new AlipayConfigProvider(alipayConfig));
        //    services.TryAddScoped<IAlipayNotifyService, AlipayNotifyService>();
        //    services.TryAddScoped<IAlipayReturnService, AlipayReturnService>();
        //    services.AddPayService(PayOriginType.AliPay);
        //}

        /// <summary>
        /// 注册阿里支付
        /// </summary>
        /// <typeparam name="TAlipayConfigProvider"></typeparam>
        /// <param name="services"></param>
        //public static void AddAliPay<TAlipayConfigProvider>(this IServiceCollection services) where TAlipayConfigProvider : class, IAlipayConfigProvider
        //{
        //    services.AddSingleton<IAlipayConfigProvider, TAlipayConfigProvider>();
        //    services.TryAddScoped<IAlipayNotifyService, AlipayNotifyService>();
        //    services.TryAddScoped<IAlipayReturnService, AlipayReturnService>();
        //    services.AddPayService(PayOriginType.AliPay);
        //}
        /// <summary>
        /// 注册微信支付
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        //public static IServiceCollection AddWechatPay(this IServiceCollection services, Action<IDictionary<string, WechatPayConfig>> action = null)
        //{
        //    var WechatPayConfig = new WechatPayConfig();
        //    setupAction?.Invoke(WechatPayConfig);
        //    services.AddHttpClient("wechat", WechatPayConfig);
        //    services.AddSingleton<IWechatPayConfigStorage>(new WechatPayConfigProvider(WechatPayConfig));
        //    services.TryAddScoped<IWechatPayNotifyService, WechatPayNotifyService>();
        //    services.AddPayService(PayOriginType.WechatPay);
        //    return services;
        //}

        //public static IServiceCollection AddWechatPay(this IServiceCollection services, Action<WechatPayConfig> action = null)
        //{
        //    var WechatPayConfig = new WechatPayConfig();
        //    setupAction?.Invoke(WechatPayConfig);
        //    services.AddHttpClient("wechat", WechatPayConfig);
        //    services.AddSingleton<IWechatPayConfigStorage>(new WechatPayConfigProvider(WechatPayConfig));
        //    services.TryAddScoped<IWechatPayNotifyService, WechatPayNotifyService>();
        //    services.AddPayService(PayOriginType.WechatPay);
        //    return services;
        //}


        //public static void AddPay(this IServiceCollection services, Action<AlipayConfig> aliPaySetupAction = null, Action<WechatPayConfig> WechatPaySetupAction = null)
        //{
        //    services.AddAliPay(aliPaySetupAction);
        //    services.AddWechatPay(WechatPaySetupAction);
        //    services.AddPayService();
        //}

        //public static void AddPay<TWechatPayConfigProvider, TAlipayConfigProvider>(this IServiceCollection services) where TWechatPayConfigProvider : class, IWechatPayConfigStorage where TAlipayConfigProvider : class, IAlipayConfigProvider
        //{
        //    //services.AddAliPay<TAlipayConfigProvider>();
        //    services.AddWechatPay<TWechatPayConfigProvider>();
        //    services.AddPayService();
        //}




        public static IServiceCollection AddPayService(this IServiceCollection services, Assembly assembly, PayOriginType payOriginType)
        {
            return AddPayService(services, assembly, new List<PayOriginType>() { payOriginType });
        }



        public static IServiceCollection AddPayService(this IServiceCollection services, Assembly assembly, IList<PayOriginType> payOriginTypes = null)
        {
            var currentAssembly = assembly;
            var types = currentAssembly.GetTypes();
            var interfaceTypes = types.Where(o => o.IsInterface && o.GetCustomAttribute<PayServiceAttribute>(false) != null);
            if (payOriginTypes != null && payOriginTypes.Count > 0)
            {
                interfaceTypes = interfaceTypes.Where(o => payOriginTypes.Contains(o.GetCustomAttribute<PayServiceAttribute>(false).PayOriginType));
            }
            foreach (var interfaceType in interfaceTypes)
            {
                var findTypes = types.Where(o => o.IsClass && interfaceType.IsAssignableFrom(o)).ToList();
                foreach (var implType in findTypes)
                {
                    services.AddTransient(interfaceType, implType);
                }

            }
            return services;
        }

    }



}
