using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Payments.Extensions;
using Payments.WechatPay;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Parameters;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using Payments.WechatPay.Services.Base;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.WechatPay.Services
{
    /// <summary>
    /// 查询签约关系服务
    /// </summary>
    public class WechatQueryContractService : WechatPayServiceBase<WechatQueryContractRequest>, IWechatQueryContractService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatQueryContractService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {

        }

        public Task<WechatPayResult<WechatQueryContractResponse>> Query(WechatQueryContractRequest request)
        {
            return Request<WechatQueryContractResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetQueryContractUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatQueryContractRequest param)
        {
            builder.Add("contract_id", param.ContractId).Add("plan_id", param.PlanId).Add("contract_code", param.ContractCode)
                      .Add("version", "1.0").Remove(WechatPayConst.NonceStr).Remove(WechatPayConst.SpbillCreateIp);
        }
    }
}
