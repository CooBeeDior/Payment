using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Payments.Extensions;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;
using System;
using System.IO;
using WechatPay.Parameters.Requests;
using System.Net.Http;
using System.Threading.Tasks;
using WechatPay.Parameters;

namespace WechatPay.Services
{
    /// <summary>
    /// 查询企业付款到银行卡
    /// </summary>
    public class WechatQueryPayBankService : WechatPayServiceBase<WechatQueryPayBankRequest>, IWechatQueryPayBankService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatQueryPayBankService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(httpClientFactory, loggerFactory)
        {

        }

        public Task<WechatPayResult<WechatQueryPayBankResponse>> Query(WechatQueryPayBankRequest request)
        {
            return Request<WechatQueryPayBankResponse>(request);
        }

    
        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetQueryPayBankUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatQueryPayBankRequest param)
        {
            builder.Add(WechatPayConst.PartnerTradeNo, param.PartnerTradeNo);

        }
    }
}
