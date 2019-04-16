using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Exceptions;
using Payments.Extensions;
using Payments.Util;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;
using System.Net.Http;
namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 微信小程序支付服务
    /// </summary> 
    public class WechatpayMiniProgramPayService : WechatpayServiceBase, IWechatpayMiniProgramPayService
    {
        /// <summary>
        /// 初始化微信小程序支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatpayMiniProgramPayService(IWechatpayConfigProvider configProvider, IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(configProvider, httpClientFactory, loggerFactory)
        {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public Task<WechatpayResult<WechatpayMiniProgramPayResponse>> PayAsync(WechatpayMiniProgramPayRequest request)
        {
            return base.PayAsync<WechatpayMiniProgramPayResponse>(request);
        }



        /// <summary>
        /// 获取交易类型
        /// </summary>
        protected override string GetTradeType()
        {
            return "JSAPI";
        }

 
    }
}