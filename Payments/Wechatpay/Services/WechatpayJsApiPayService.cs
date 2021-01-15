using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Parameters;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using Payments.WechatPay.Services.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace Payments.WechatPay.Services
{
    /// <summary>
    /// 微信JsApi支付服务
    /// </summary>
    public class WechatPayJsApiPayService : WechatPayServiceBase, IWechatPayJsApiPayService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPayJsApiPayService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
        }

        public Task<WechatPayResult<WechatPayJsApiPayResponse>> PayAsync(WechatPayJsApiPayRequest request)
        {
            return base.PayAsync<WechatPayJsApiPayResponse>(request);
        }


        /// <summary>
        /// 获取交易类型
        /// </summary>
        protected override string GetTradeType()
        {
            return "JSAPI";
        }
        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected override void ValidateParam(WechatPayPayRequestBase param)
        {
            param.OpenId.CheckNull(nameof(param.OpenId));
        }

   


    }
}
