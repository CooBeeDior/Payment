using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;
namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 公众号APP申请签约
    /// </summary>
    public class WechatEntrustWebService : WechatpayServiceBase<WechatEntrustWebRequest>, IWechatEntrustWebService
    {


        public WechatEntrustWebService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }

        public Task<string> GetUrl(WechatEntrustWebRequest param)
        {
            Validate(Config, param);
            var builder = CreateParameterBuilder();
            BuildConfig(builder, param);
            string url = builder.ToUrl(true);
            return Task.FromResult($"{GetRequestUrl(Config)}?{url}");
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetEntrustWebUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatEntrustWebRequest param)
        {
            builder.Add("plan_id", param.PlanId).Add("contract_code", param.ContractCode)
                 .Add("request_serial", param.RequestSerial).Add("contract_display_account", param.ContractDisplayAccount)
                 .NotifyUrl(param.NotifyUrl).Add("version", "1.0").Timestamp().Add("return_app", param.ReturnApp).Add("return_web", param.ReturnWeb)
                 .Remove(WechatpayConst.SignType).Remove(WechatpayConst.NonceStr).Remove(WechatpayConst.SpbillCreateIp);
        }
    }
}
