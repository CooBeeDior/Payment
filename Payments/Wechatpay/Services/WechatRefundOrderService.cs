using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Properties;
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
    /// 订单退款
    /// </summary>
    public class WechatRefundOrderService : WechatpayServiceBase<WechatRefundOrderRequest>, IWechatRefundOrderService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatRefundOrderService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }



        public Task<WechatpayResult<WechatRefundOrderResponse>> RefundAsync(WechatRefundOrderRequest request)
        {
            return Request<WechatRefundOrderResponse>(request);
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatRefundOrderRequest param)
        {
            builder.TransactionId(param.TransactionId).OutTradeNo(param.OutTradeNo)
                .OutRefundNo(param.OutRefundNo).TotalFee(param.TotalFee).RefundFeeType(param.RefundFeeType)
                .RefundFee(param.RefundFee).NotifyUrl(param.NotifyUrl).Add(WechatpayConst.RefundDesc, param.RefundDesc)
               .RefundAccount(param.RefundAccount).Remove(WechatpayConst.SpbillCreateIp).Remove(WechatpayConst.NotifyUrl);
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
        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetRefundQueryUrl();
        }

        protected override WechatpayParameterBuilder CreateParameterBuilder()
        {
            var builder = new WechatpayCertParameterBuilder(Config);
            return builder;
        }
    }
}
