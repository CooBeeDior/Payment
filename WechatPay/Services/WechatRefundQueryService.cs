using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Extensions;
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
    /// 退款订单查询
    /// </summary>
    public class WechatRefundQueryService : WechatPayServiceBase<WechatRefundQueryRequest>, IWechatRefundQueryService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatRefundQueryService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {

        }

        public Task<WechatPayResult<WechatRefundQueryResponse>> RefundQuery(WechatRefundQueryRequest request)
        {
            return Request<WechatRefundQueryResponse>(request);
        }
        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetRefundQueryUrl();
        }
        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected override void ValidateParam(WechatRefundQueryRequest param)
        {
            if (param.OutTradeNo.IsEmpty() && param.TransactionId.IsEmpty() && param.RefundId.IsEmpty() && param.OutRefundNo.IsEmpty())
            {
                throw new Exception("orderno all null");
            }
        }
        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatRefundQueryRequest param)
        {
            builder.TransactionId(param.TransactionId).OutTradeNo(param.OutTradeNo)
                   .OutRefundNo(param.OutRefundNo).RefundId(param.RefundId).Offset(param.Offset)
                   .Remove(WechatPayConst.SpbillCreateIp).Remove(WechatPayConst.NotifyUrl); ;
        }
    }
}
