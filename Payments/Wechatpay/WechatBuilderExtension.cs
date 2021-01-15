using Microsoft.Extensions.DependencyInjection;
using Payments.WechatPay.Configs;
using System;

namespace Payments.WechatPay
{
    public static class WechatBuilderExtension
    {
        public static IWechatBuilder AddWehcatpayStorage<TStorage>(this IWechatBuilder wechatBuilder) where TStorage : class, IWechatPayConfigStorage, new()
        {
            wechatBuilder.Services.AddSingleton<IWechatPayConfigStorage,TStorage>();
            return wechatBuilder;
        }

        public static IWechatBuilder AddWehcatpayStorage(this IWechatBuilder wechatBuilder, Func<IServiceProvider, IWechatPayConfigStorage> func)
        {
            var storage = func.Invoke(wechatBuilder.Services.BuildServiceProvider());
            wechatBuilder.Services.AddSingleton<IWechatPayConfigStorage>(storage);
            return wechatBuilder;
        }
    }
}
