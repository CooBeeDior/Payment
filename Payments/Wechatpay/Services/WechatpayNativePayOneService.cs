using Microsoft.Extensions.Logging;
using Payments.Extensions;
using Payments.Util;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 微信Native场景一支付
    /// </summary>
    public class WechatpayNativePayOneService : IWechatpayNativePayOneService
    {
        protected ILoggerFactory LoggerFactory { get; }

        protected WechatpayConfig Config { get; }

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatpayNativePayOneService(IWechatpayConfigProvider provider, ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
            Config = provider.GetConfig();

        }


        public Task<string> BuildUrl(WechatpayNativePayOneRequest param)
        {
            string url = GetRequestUrl(Config);
            var builder = new WechatpayParameterBuilder(Config);
            InitBuilder(builder, param);
            url = $"{url}?{builder.ToUrl()}";
            return Task.FromResult<string>(url);

        }

        protected virtual string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetBizPayUrl();
        }

        protected virtual void InitBuilder(WechatpayParameterBuilder builder, WechatpayNativePayOneRequest param)
        {
            builder.AppId(Config.AppId).MerchantId(Config.MerchantId).Add("time_stamp", DateTime.Now.GetUnixTimestamp())
                .ProductId(param.ProductId).NonceStr(Id.GetId());


        }
    }
}
