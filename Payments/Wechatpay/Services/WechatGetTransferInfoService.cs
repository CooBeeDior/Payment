using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util;
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
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
namespace Payments.WechatPay.Services
{
    /// <summary>
    /// 查询企业付款
    /// </summary>
    public class WechatGetTransferInfoService : WechatPayServiceBase<WechatGetTransferInfoRequest>, IWechatGetTransferInfoService
    {
        public WechatGetTransferInfoService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(httpClientFactory, loggerFactory)
        {

        }

        public Task<WechatPayResult<WechatGetTransferInfoResponse>> Query(WechatGetTransferInfoRequest request)
        {
            return Request<WechatGetTransferInfoResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetTransferInfoUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatGetTransferInfoRequest param)
        {
            builder.AppId(Config.AppId).Add("mch_id", Config.MerchantId).NonceStr(Id.GetId()).Add(WechatPayConst.PartnerTradeNo, param.PartnerTradeNo);
        }


    }
}
