using Microsoft.Extensions.Logging;
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
    /// 订单退款
    /// </summary>
    public class WechatRefundOrderService : WechatPayServiceBase<WechatRefundOrderRequest>, IWechatRefundOrderService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatRefundOrderService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {

        }



        public Task<WechatPayResult<WechatRefundOrderResponse>> RefundAsync(WechatRefundOrderRequest request)
        {
            return Request<WechatRefundOrderResponse>(request);
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatRefundOrderRequest param)
        {
            builder.TransactionId(param.TransactionId).OutTradeNo(param.OutTradeNo)
                .OutRefundNo(param.OutRefundNo).TotalFee(param.TotalFee).RefundFeeType(param.RefundFeeType)
                .RefundFee(param.RefundFee).NotifyUrl(param.NotifyUrl).Add(WechatPayConst.RefundDesc, param.RefundDesc)
               .RefundAccount(param.RefundAccount).Remove(WechatPayConst.NotifyUrl);
        }

        protected override void ValidateParam(WechatRefundOrderRequest param)
        {
            if (param.TransactionId.IsEmpty() && param.OutTradeNo.IsEmpty())
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
            return config.GetOrderRefundUrl();
        }

      
    }
}
