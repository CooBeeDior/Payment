﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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

namespace WechatPay.Services
{
    public class WechatReverseOrderService : WechatPayServiceBase<WechatReverseOrderRequest>, IWechatReverseOrderService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatReverseOrderService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(httpClientFactory, loggerFactory)
        {

        }

        public Task<WechatPayResult<WechatReverseOrderResponse>> ReverseAsync(WechatReverseOrderRequest request)
        {
            return Request<WechatReverseOrderResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetReverseUrl();
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected override void ValidateParam(WechatReverseOrderRequest param)
        {
            if (param.TransactionId.IsEmpty() && param.OutTradeNo.IsEmpty())
            {
                throw new Exception("order no all null");
            }
        }


        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatReverseOrderRequest param)
        {
            builder.TransactionId(param.TransactionId).OutTradeNo(param.OutTradeNo);

        }

    }
}