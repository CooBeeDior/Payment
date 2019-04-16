using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 企业转账服务
    /// </summary>
    public class WechatTransfersService : WechatpayServiceBase<WechatTransfersRequest>, IWechatTransfersService
    {
        public WechatTransfersService(IWechatpayConfigProvider provider, ILoggerFactory loggerFactory) : base(provider, loggerFactory)
        {
        }
        public Task<WechatpayResult<WechatTransfersResponse>> Transfer(WechatTransfersRequest request)
        {
            return Request<WechatTransfersResponse>(request);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetTransfersUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatTransfersRequest param)
        {
            builder.Add(WechatpayConst.MchAppId, Config.AppId).Add(WechatpayConst.MchId, Config.MerchantId).Add(WechatpayConst.DeviceInfo, param.DeviceInfo)
               .Add(WechatpayConst.PartnerTradeNo, param.PartnerTradeNo).OpenId(param.OpenId)
                .Add(WechatpayConst.CheckName, param.CheckName?.ToString()).Add(WechatpayConst.ReUserName, param.ReUserName)
                .Add(WechatpayConst.Amount, (param.Amount * 100).ToInt()).Add(WechatpayConst.Desc, param.Desc);

        }

        protected override Task<HttpClientHandler> SetCertificate()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.SetCertificate(Config.CertificateData, Config.CertificatePwd);
            return Task.FromResult(handler);
        }
    }
}
