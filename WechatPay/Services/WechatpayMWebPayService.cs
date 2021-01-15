using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Extensions;
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
    /// 微信NWeb支付服务
    /// </summary>
    public class WechatPayMWebPayService : WechatPayServiceBase, IWechatPayMWebPayService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPayMWebPayService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
        }

        public Task<WechatPayResult<WechatPayMWebPayResponse>> PayAsync(WechatPayMWebPayRequest request)
        {
            return base.PayAsync<WechatPayMWebPayResponse>(request);
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
        protected override void ValidateParam(WechatPayPayRequestBase param)
        {
      
        }

 


    }
}
