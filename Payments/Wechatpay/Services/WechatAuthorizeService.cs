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
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 授权服务
    /// </summary>
    public class WechatAuthorizeService : WechatpayServiceBase<WechatAuthorizeRequest>, IWechatAuthorizeService
    {
        public WechatAuthorizeService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }
        public Task<string> Query(WechatAuthorizeRequest param)
        {
            var builder = CreateParameterBuilder();
            return Request(Config, builder);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        { 
            return config.GetAuthorizeUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatAuthorizeRequest param)
        {
            builder.Add("appid", Config.AppId).Add("redirect_uri", WebUtility.HtmlEncode(param.RedirectUri)).Add("response_type", "code")
                .Add("scope", param.Scope).Add("state", param.State);
        }

        protected override async Task<string> Request(WechatpayConfig config, WechatpayParameterBuilder builder)
        {
            string url = $"{GetRequestUrl(config)}?{builder.ToUrl(false)}#wechat_redirect";
            var resonse = await Web.Client()
                .Get(url)      
                .ResultAsync();
            return await resonse.Content.ReadAsStringAsync();
        }
    }
}
