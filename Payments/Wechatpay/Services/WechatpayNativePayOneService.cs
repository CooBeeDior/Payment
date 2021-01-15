using Microsoft.Extensions.Logging;
using Payments.Extensions;
using Payments.Util;
using Payments.WechatPay;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Parameters;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.WechatPay.Services
{
    /// <summary>
    /// 微信Native场景一支付
    /// </summary>
    public class WechatPayNativePayOneService : IWechatPayNativePayOneService
    {
        private readonly IWechatPayConfigStorage _WechatPayConfigProvider;
        protected ILoggerFactory LoggerFactory { get; }

        protected WechatPayConfig Config { get; private set; }

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPayNativePayOneService(IWechatPayConfigStorage WechatPayConfigProvider, ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
            _WechatPayConfigProvider = WechatPayConfigProvider;

        }
   
        public void SetConfig(WechatPayConfig config)
        {
            Config = config;
        }
        public Task<string> BuildUrl(WechatPayNativePayOneRequest request)
        {
            string url = GetRequestUrl(Config);
            var builder = new WechatPayParameterBuilder(Config);
            if (_extParam != null && _extParam.Any())
            {
                foreach (var item in _extParam)
                {
                    builder.Add(item.Key, item.Value);
                }
            }
            InitBuilder(builder, request);
            url = $"{url}?{builder.ToUrl()}";
            return Task.FromResult<string>(url);

        }
        private IDictionary<string, object> _extParam = null;
        public void ExtensionParameter(IDictionary<string, object> extParam)
        {
            _extParam = extParam;
        }
        protected virtual string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetBizPayUrl();
        }

        protected virtual void InitBuilder(WechatPayParameterBuilder builder, WechatPayNativePayOneRequest param)
        {
            builder.AppId(Config.AppId).MerchantId(Config.MerchantId).Add("time_stamp", DateTime.Now.GetUnixTimestamp())
                .ProductId(param.ProductId).NonceStr(Id.GetId());


        }


    }
}
