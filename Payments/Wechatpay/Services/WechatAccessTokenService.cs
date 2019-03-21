using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Util.Http;
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
    /// 授权access_token服务
    /// </summary>
    public class WechatAccessTokenService : WechatpayServiceBase<WechatAccessTokenRequest>, IWechatAccessTokenService
    {
        public WechatAccessTokenService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }

        /// <summary>
        /// { 
        ///  "access_token":"ACCESS_TOKEN",
        ///  "expires_in":7200,
        ///  "refresh_token":"REFRESH_TOKEN",
        ///  "openid":"OPENID",
        ///  "scope":"SCOPE" 
        ///  }
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Task<string> Query(WechatAccessTokenRequest param)
        {
            var builder = CreateParameterBuilder();
            return Request(Config, builder);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetAccessTokenUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatAccessTokenRequest param)
        {
            builder.Add("appid", Config.AppId).Add("secret", Config.PrivateKey).Add("code", param.Code).Add("grant_type", "authorization_code");
        }

        protected override async Task<string> Request(WechatpayConfig config, WechatpayParameterBuilder builder)
        {
            string url = $"{GetRequestUrl(config)}?{builder.ToUrl(false)}";
            var resonse = await Web.Client()
                .Get(url)
                .ResultAsync();
            return await resonse.Content.ReadAsStringAsync();
        }

    }
}
