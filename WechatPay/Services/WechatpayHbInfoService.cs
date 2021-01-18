using Microsoft.Extensions.Logging;
using Payments.Core.Response;
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
using System.Threading.Tasks;
namespace WechatPay.Services
{
    /// <summary>
    /// 查询红包记录服务
    /// </summary>
    public class WechatPayHbInfoService : WechatPayServiceBase<WechatPayHbInfoRequest>, IWechatPayHbInfoService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPayHbInfoService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(httpClientFactory, loggerFactory)
        {

        }

        public Task<WechatPayResult<WechatPayHbInfoResponse>> Query(WechatPayHbInfoRequest request)
        {
            return Request<WechatPayHbInfoResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetGethbinfoUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatPayHbInfoRequest param)
        {
            builder.Remove(WechatPayConst.AppId).Add(WechatPayConst.WxAppid, Config.AppId).Add(WechatPayConst.ClientIp, Server.GetLanIp())
               .Add(WechatPayConst.MchBillNo, param.MchBillNo);
        }
    }
}
