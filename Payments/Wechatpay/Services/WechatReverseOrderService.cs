using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;

namespace Payments.Wechatpay.Services
{
    public class WechatReverseOrderService : WechatpayServiceBase<WechatReverseOrderRequest>, IWechatReverseOrderService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatReverseOrderService(IWechatpayConfigProvider configProvider, IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(configProvider, httpClientFactory, loggerFactory)
        {

        }

        public Task<WechatpayResult<WechatReverseOrderResponse>> ReverseAsync(WechatReverseOrderRequest request)
        {
            return Request<WechatReverseOrderResponse>(request);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetReverseUrl();
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected override void ValidateParam(WechatReverseOrderRequest param)
        {
            if (param.TransactionId.IsEmpty() && param.OutTradeNo.IsEmpty())
            {
                throw new Exception("order no all null");
            }
        }


        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatReverseOrderRequest param)
        {
            builder.TransactionId(param.TransactionId).OutTradeNo(param.OutTradeNo)
                   .Remove(WechatpayConst.SpbillCreateIp);

        }
     
    }
}