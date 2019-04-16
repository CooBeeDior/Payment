using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
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
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Services
{
     

    /// <summary>
    /// 微信NWeb支付服务
    /// </summary>
    public class WechatpayMWebPayService : WechatpayServiceBase, IWechatpayMWebPayService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatpayMWebPayService(IWechatpayConfigProvider configProvider, IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(configProvider, httpClientFactory, loggerFactory)
        {
        }

        public Task<WechatpayResult<WechatpayMWebPayResponse>> PayAsync(WechatpayMWebPayRequest request)
        {
            return base.PayAsync<WechatpayMWebPayResponse>(request);
        }


        /// <summary>
        /// 获取交易类型
        /// </summary>
        protected override string GetTradeType()
        {
            return "MWEB";
        }
        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected override void ValidateParam(WechatpayPayRequestBase param)
        {
      
        }

 


    }
}
