using Microsoft.Extensions.Logging;
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
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 查询企业付款
    /// </summary>
    public class WechatGetTransferInfoService : WechatpayServiceBase<WechatGetTransferInfoRequest>, IWechatGetTransferInfoService
    {
        public WechatGetTransferInfoService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }

        public Task<WechatpayResult<WechatGetTransferInfoResponse>> Query(WechatGetTransferInfoRequest request)
        {
            return Request<WechatGetTransferInfoResponse>(request);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetTransferInfoUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatGetTransferInfoRequest param)
        {
            builder.AppId(Config.AppId).Add("mch_id", Config.MerchantId).NonceStr(Id.GetId()).Add(WechatpayConst.PartnerTradeNo, param.PartnerTradeNo);
        }

        protected override Task<HttpClientHandler> SetCertificate()
        {
            HttpClientHandler handler = new HttpClientHandler(); 
            handler.SetCertificate(Config.CertificateData, Config.CertificatePwd);
            return Task.FromResult(handler);
        }
    }
}
