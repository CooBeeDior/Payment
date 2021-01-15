using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Util;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WechatPay.Services
{

    /// <summary>
    /// 微信Native支付服务
    /// </summary>
    public class WechatPayNativePayService : WechatPayServiceBase, IWechatPayNativePayService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPayNativePayService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public Task<WechatPayResult<WechatPayNativePayResponse>> PayAsync(WechatPayNativePayRequest request)
        {
            return base.PayAsync<WechatPayNativePayResponse>(request);
        }



        /// <summary>
        /// 获取交易类型
        /// </summary>
        protected override string GetTradeType()
        {
            return "NATIVE";
        }

    
    }
}
