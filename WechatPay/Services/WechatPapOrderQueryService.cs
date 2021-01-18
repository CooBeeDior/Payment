using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Properties;
using Payments.Util;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using WechatPay;

namespace WechatPay.Services
{
    /// <summary>
    /// 查询扣款订单服务
    /// </summary>
    public class WechatPapOrderQueryService : WechatPayServiceBase<WechatPapOrderQueryRequest>, IWechatPapOrderQueryService
    {
        /// <summary>
        /// 初始化微信小程序支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPapOrderQueryService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
        }

        public Task<WechatPayResult<WechatPapOrderQueryResponse>> Query(WechatPapOrderQueryRequest request)
        {
            return Request<WechatPapOrderQueryResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetPapOrderQueryUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatPapOrderQueryRequest param)
        {
            builder.TransactionId(param.TransactionId).OutTradeNo(param.OutTradeNo);
        }

        protected override void ValidateParam(WechatPapOrderQueryRequest param)
        {
            if (param.OutTradeNo.IsEmpty() && param.TransactionId.IsEmpty())
            {
                throw new ArgumentNullException("TransactionId,OutTradeNo不能同时为空");
            }
        }
    }
}
