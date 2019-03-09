using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 订单查询服务
    /// </summary>
    public class WechatOrderQueryService : WechatpayServiceBase<WechatOrderQueryRequest>, IWechatOrderQueryService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatOrderQueryService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {
          
        }



        public Task<PayResult> QueryAsync(WechatOrderQueryRequest param)
        {
            return Request(param);
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatOrderQueryRequest param)
        {
            builder.OutTradeNo(param.OutTradeNo).TransactionId(param.TransactionId);
        }

        protected override void ValidateParam(WechatOrderQueryRequest param)
        {
            if (param.OutTradeNo.IsEmpty() && param.TransactionId.IsEmpty())
            {
                throw new ArgumentNullException("TransactionId and OutTradeNo not all null");
            }
        }

        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetOrderQueryUrl();
        }
    }
}
