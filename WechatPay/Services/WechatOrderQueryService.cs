using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Properties;
using WechatPay;
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
    /// 订单查询服务
    /// </summary>
    public class WechatOrderQueryService : WechatPayServiceBase<WechatOrderQueryRequest>, IWechatOrderQueryService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatOrderQueryService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
          
        }



        public Task<WechatPayResult<WechatOrderQueryResponse>> QueryAsync(WechatOrderQueryRequest request)
        {
            return Request<WechatOrderQueryResponse>(request);
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatOrderQueryRequest param)
        {
            builder.OutTradeNo(param.OutTradeNo).TransactionId(param.TransactionId);
        }

        protected override void ValidateParam(WechatOrderQueryRequest param)
        {
            if (param.OutTradeNo.IsEmpty() && param.TransactionId.IsEmpty())
            {
                throw new ArgumentNullException("TransactionId,OutTradeNo不能同时为空");
            }
        }

        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetOrderQueryUrl();
        }
    }
}
