using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Properties;
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

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 查询扣款订单服务
    /// </summary>
    public class WechatPapOrderQueryService : WechatpayServiceBase<WechatPapOrderQueryRequest>, IWechatPapOrderQueryService
    {
        /// <summary>
        /// 初始化微信小程序支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPapOrderQueryService(IWechatpayConfigProvider provider, ILoggerFactory loggerFactory) : base(provider, loggerFactory)
        {
        }

        public Task<WechatpayResult<WechatPapOrderQueryResponse>> Query(WechatPapOrderQueryRequest request)
        {
            return Request<WechatPapOrderQueryResponse>(request);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetPapOrderQueryUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatPapOrderQueryRequest param)
        {
            builder.TransactionId(param.TransactionId).OutTradeNo(param.OutTradeNo).Remove(WechatpayConst.SpbillCreateIp);
        }

        protected override void ValidateParam(WechatPapOrderQueryRequest param)
        {
            if (param.OutTradeNo.IsEmpty() && param.TransactionId.IsEmpty())
            {
                throw new ArgumentNullException(PayResource.TIdOutTradeAllNull);
            }
        }
    }
}
