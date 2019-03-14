using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        //    services.TryAddSingleton<IAlipayConfigProvider>(new AlipayConfigProvider(alipayConfig));
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
        //    services.TryAddSingleton<IAlipayConfigProvider, TAlipayConfigProvider>();
        //    services.TryAddScoped<IAlipayNotifyService, AlipayNotifyService>();
        //    services.TryAddScoped<IAlipayReturnService, AlipayReturnService>();
        //    services.AddPayService(PayOriginType.AliPay);
        //}
        /// <summary>
        /// 注册微信支付
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        public static void AddWechatPay(this IServiceCollection services, Action<WechatpayConfig> setupAction = null)
        {
            var wechatpayConfig = new WechatpayConfig();
            setupAction?.Invoke(wechatpayConfig);
            services.TryAddSingleton<IWechatpayConfigProvider>(new WechatpayConfigProvider(wechatpayConfig));
            services.TryAddScoped<IWechatpayNotifyService, WechatpayNotifyService>();
            services.AddPayService(PayOriginType.WechatPay);
        }

        /// <summary>
        /// 注册微信支付
        /// </summary>
        /// <typeparam name="TWechatpayConfigProvider"></typeparam>
        /// <param name="services"></param>
        public static void AddWechatPay<TWechatpayConfigProvider>(this IServiceCollection services) where TWechatpayConfigProvider : class, IWechatpayConfigProvider
        {
            services.TryAddScoped<IWechatpayConfigProvider, TWechatpayConfigProvider>();
            services.TryAddScoped<IWechatpayNotifyService, WechatpayNotifyService>();
            services.AddPayService(PayOriginType.WechatPay);
        }
        //public static void AddPay(this IServiceCollection services, Action<AlipayConfig> aliPaySetupAction = null, Action<WechatpayConfig> wechatPaySetupAction = null)
        //{
        //    services.AddAliPay(aliPaySetupAction);
        //    services.AddWechatPay(wechatPaySetupAction);
        //    services.AddPayService();
        //}

        //public static void AddPay<TWechatpayConfigProvider, TAlipayConfigProvider>(this IServiceCollection services) where TWechatpayConfigProvider : class, IWechatpayConfigProvider where TAlipayConfigProvider : class, IAlipayConfigProvider
        //{
        //    //services.AddAliPay<TAlipayConfigProvider>();
        //    services.AddWechatPay<TWechatpayConfigProvider>();
        //    services.AddPayService();
        //}

        private static void AddPayService(this IServiceCollection services, PayOriginType payOriginType)
        {
            AddPayService(services, new List<PayOriginType>() { payOriginType });
        }


        private static void AddPayService(this IServiceCollection services, IList<PayOriginType> payOriginTypes = null)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
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
                    services.AddScoped(interfaceType, implType);
                }

            }
        }

    }



}
