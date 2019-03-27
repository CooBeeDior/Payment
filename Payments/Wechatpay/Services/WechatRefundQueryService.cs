using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Extensions;
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
    /// 退款订单查询
    /// </summary>
    public class WechatRefundQueryService : WechatpayServiceBase<WechatRefundQueryRequest>, IWechatRefundQueryService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatRefundQueryService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }

        public Task<WechatpayResult<WechatRefundQueryResponse>> RefundQuery(WechatRefundQueryRequest request)
        {
            return Request<WechatRefundQueryResponse>(request);
        }
        protected override string GetRequestUrl(WechatpayConfig config)
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
        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatRefundQueryRequest param)
        {
            builder.TransactionId(param.TransactionId).OutTradeNo(param.OutTradeNo)
                   .OutRefundNo(param.OutRefundNo).RefundId(param.RefundId).Offset(param.Offset)
                   .Remove(WechatpayConst.SpbillCreateIp).Remove(WechatpayConst.NotifyUrl); ;
        }
    }
}
