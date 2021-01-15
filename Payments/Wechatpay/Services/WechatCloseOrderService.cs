﻿using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
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
    /// 关闭订单服务
    /// </summary>
    public class WechatCloseOrderService : WechatPayServiceBase<WechatCloseOrderRequest>, IWechatCloseOrderService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatCloseOrderService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {

        }


        public Task<WechatPayResult<WechatCloseOrderResponse>> CloseAsync(WechatCloseOrderRequest request)
        {
            return Request<WechatCloseOrderResponse>(request);
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatCloseOrderRequest param)
        {
            builder.OutTradeNo(param.OutTradeNo).Remove(WechatPayConst.SpbillCreateIp);//.Remove(WechatPayConst.NotifyUrl);
        }

       

        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetOrderCloseUrl();
        }
    }
}
