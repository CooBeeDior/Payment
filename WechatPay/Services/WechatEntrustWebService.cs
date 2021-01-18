using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using WechatPay;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Services.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace WechatPay.Services
{
    /// <summary>
    /// 公众号APP申请签约
    /// </summary>
    public class WechatEntrustWebService : WechatPayServiceBase<WechatEntrustWebRequest>, IWechatEntrustWebService
    {


        public WechatEntrustWebService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {

        }

        public Task<string> GetUrl(WechatEntrustWebRequest request)
        {
            Validate(Config, request);
            var builder = CreateParameterBuilder();
            BuildConfig(builder, request);
            string url = builder.ToUrl(true);
            return Task.FromResult($"{GetRequestUrl(Config)}?{url}");
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetEntrustWebUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatEntrustWebRequest param)
        {
            builder.Add("plan_id", param.PlanId).Add("contract_code", param.ContractCode)
                 .Add("request_serial", param.RequestSerial).Add("contract_display_account", param.ContractDisplayAccount)
                 .NotifyUrl(param.NotifyUrl).Add("version", "1.0").Timestamp().Add("return_app", param.ReturnApp).Add("return_web", param.ReturnWeb)
                 .Remove(WechatPayConst.SignType).Remove(WechatPayConst.NonceStr);
        }
    }
}
