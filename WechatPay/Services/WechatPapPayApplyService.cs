﻿using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Util;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Enums;
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
    /// 申请扣款服务
    /// </summary>
    public class WechatPapPayApplyService : WechatPayServiceBase<WechatPapPayApplyRequest>, IWechatPapPayApplyService
    { 
        /// <summary>
       /// 初始化微信小程序支付服务
       /// </summary>
       /// <param name="provider">微信支付配置提供器</param>
        public WechatPapPayApplyService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
        }

        public Task<WechatPayResult<WechatPapPayApplyResponse>> Deduct(WechatPapPayApplyRequest request)
        {
            return Request<WechatPapPayApplyResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetPapPayApplyUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatPapPayApplyRequest param)
        {
            builder.Body(param.Body).Detail(param.Detail).Attach(param.Attach)
                  .OutTradeNo(param.OutTradeNo).TotalFee(param.TotalFee).FeeType(param.FeeType)
                  .GoodsTag(param.GoodsTag).NotifyUrl(param.NotifyUrl).TradeType("PAP").Add("contract_id", param.ContractId)
                  .Receipt(param.Receipt);
        }
    }
}
