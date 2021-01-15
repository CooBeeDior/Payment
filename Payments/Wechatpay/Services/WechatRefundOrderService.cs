using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Properties;
using Payments.WechatPay;
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
               .RefundAccount(param.RefundAccount).Remove(WechatPayConst.SpbillCreateIp).Remove(WechatPayConst.NotifyUrl);
        }

        protected override void ValidateParam(WechatRefundOrderRequest param)
        {
            if (param.TransactionId.IsEmpty() && param.OutTradeNo.IsEmpty())
            {
                throw new ArgumentNullException(PayResource.TIdOutTradeAllNull);
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
