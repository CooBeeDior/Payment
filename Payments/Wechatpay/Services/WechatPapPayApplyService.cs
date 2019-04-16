using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Util;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Enums;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 申请扣款服务
    /// </summary>
    public class WechatPapPayApplyService : WechatpayServiceBase<WechatPapPayApplyRequest>, IWechatPapPayApplyService
    { 
        /// <summary>
       /// 初始化微信小程序支付服务
       /// </summary>
       /// <param name="provider">微信支付配置提供器</param>
        public WechatPapPayApplyService(IWechatpayConfigProvider configProvider, IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(configProvider, httpClientFactory, loggerFactory)
        {
        }

        public Task<WechatpayResult<WechatPapPayApplyResponse>> Deduct(WechatPapPayApplyRequest request)
        {
            return Request<WechatPapPayApplyResponse>(request);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetPapPayApplyUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatPapPayApplyRequest param)
        {
            builder.Body(param.Body).Detail(param.Detail).Attach(param.Attach)
                  .OutTradeNo(param.OutTradeNo).TotalFee(param.TotalFee).FeeType(param.FeeType)
                  .GoodsTag(param.GoodsTag).NotifyUrl(param.NotifyUrl).TradeType("PAP").Add("contract_id", param.ContractId)
                  .Receipt(param.Receipt);
        }
    }
}
