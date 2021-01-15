using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Util;
using Payments.WechatPay;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Enums;
using Payments.WechatPay.Parameters;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Services.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.WechatPay.Services
{
    /// <summary>
    /// H5纯签约
    /// </summary>
    public class WechatH5EntrustWebService : WechatPayServiceBase<WechatH5EntrustWebRequest>, IWechatH5EntrustWebService
    {


        public WechatH5EntrustWebService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {

        }

        public Task<string> GetUrl(WechatH5EntrustWebRequest request)
        {
            Validate(Config, request);
            var builder = CreateParameterBuilder();
            BuildConfig(builder, request);
            string url = builder.ToUrl(true, WechatPaySignType.HmacSha256);
            return Task.FromResult($"{GetRequestUrl(Config)}?{url}");

        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetH5EntrustWebUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatH5EntrustWebRequest param)
        {
            builder.Add("plan_id", param.PlanId).Add("contract_code", param.ContractCode)
                 .Add("request_serial", param.RequestSerial).Add("contract_display_account", param.ContractDisplayAccount)
                 .NotifyUrl(param.NotifyUrl).Add("version", "1.0").Timestamp().Add("clientip", Server.GetLanIp()).Add("return_appid", param.ReturnAppId)
                 .Remove(WechatPayConst.SignType).Remove(WechatPayConst.NonceStr).Remove(WechatPayConst.SpbillCreateIp);
        }
    }
}
