using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Util;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Enums;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// H5纯签约
    /// </summary>
    public class WechatH5EntrustWebService : WechatpayServiceBase<WechatH5EntrustWebRequest>, IWechatH5EntrustWebService
    {


        public WechatH5EntrustWebService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }

        public Task<string> GetUrl(WechatH5EntrustWebRequest param)
        {
            Validate(Config, param);
            var builder = CreateParameterBuilder();
            BuildConfig(builder, param);
            string url = builder.ToUrl(true, WechatpaySignType.HmacSha256);
            return Task.FromResult($"{GetRequestUrl(Config)}?{url}");

        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetH5EntrustWebUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatH5EntrustWebRequest param)
        {
            builder.Add("plan_id", param.PlanId).Add("contract_code", param.ContractCode)
                 .Add("request_serial", param.RequestSerial).Add("contract_display_account", param.ContractDisplayAccount)
                 .NotifyUrl(param.NotifyUrl).Add("version", "1.0").Timestamp().Add("clientip", Server.GetLanIp()).Add("return_appid", param.ReturnAppid)
                 .Remove(WechatpayConst.SignType).Remove(WechatpayConst.NonceStr).Remove(WechatpayConst.SpbillCreateIp);
        }
    }
}
