using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Payments.Extensions;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 查询签约关系服务
    /// </summary>
    public class WechatQueryContractService : WechatpayServiceBase<WechatQueryContractRequest>, IWechatQueryContractService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatQueryContractService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }

        public Task<WechatpayResult<WechatQueryContractResponse>> Query(WechatQueryContractRequest request)
        {
            return Request<WechatQueryContractResponse>(request);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetQueryContractUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatQueryContractRequest param)
        {
            builder.Add("contract_id", param.ContractId).Add("plan_id", param.PlanId).Add("contract_code", param.ContractCode)
                      .Add("version", "1.0").Remove(WechatpayConst.NonceStr).Remove(WechatpayConst.SpbillCreateIp);
        }
    }
}
