using Microsoft.Extensions.Logging;
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
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
namespace WechatPay.Services
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
