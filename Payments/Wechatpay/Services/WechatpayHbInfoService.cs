using Microsoft.Extensions.Logging;
using Payments.Core.Response;
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
using System.Threading.Tasks;
namespace Payments.WechatPay.Services
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
        public WechatPayHbInfoService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
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
            builder.Remove(WechatPayConst.AppId).Remove(WechatPayConst.SignType)
                     .Remove(WechatPayConst.SpbillCreateIp)
                                    .Add(WechatPayConst.WxAppid, Config.AppId).Add(WechatPayConst.ClientIp, Server.GetLanIp())
               .Add(WechatPayConst.MchBillNo, param.MchBillNo);
        }
    }
}
