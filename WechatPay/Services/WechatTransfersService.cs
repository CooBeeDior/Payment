﻿using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util;
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
    /// 企业转账服务
    /// </summary>
    public class WechatTransfersService : WechatPayServiceBase<WechatTransfersRequest>, IWechatTransfersService
    {
        public WechatTransfersService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
        }
        public Task<WechatPayResult<WechatTransfersResponse>> Transfer(WechatTransfersRequest request)
        {
            return Request<WechatTransfersResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetTransfersUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatTransfersRequest param)
        {
            builder.Add(WechatPayConst.MchAppId, Config.AppId).Add(WechatPayConst.MchId, Config.MerchantId).Add(WechatPayConst.DeviceInfo, param.DeviceInfo)
               .Add(WechatPayConst.PartnerTradeNo, param.PartnerTradeNo).OpenId(param.OpenId)
                .Add(WechatPayConst.CheckName, param.CheckName?.ToString()).Add(WechatPayConst.ReUserName, param.ReUserName)
                .Add(WechatPayConst.Amount, (param.Amount * 100).ToInt()).Add(WechatPayConst.Desc, param.Desc).SpbillCreateIp(Server.GetLanIp()); ;

        }

     
    }
}
