using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;
namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 申请解约服务
    /// </summary>
    public class WechatDeleteContractService : WechatpayServiceBase<WechatDeleteContractRequest>, IWechatDeleteContractService
    {


        public WechatDeleteContractService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }

        public Task<WechatpayResult<WechatDeleteContractResponse>> Cancel(WechatDeleteContractRequest request)
        {
            return Request<WechatDeleteContractResponse>(request);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetDeleteContractUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatDeleteContractRequest param)
        {
            builder.Add("plan_id", param.PlanId).Add("contract_code", param.ContractCode).Add("contract_id", param.ContractId).Add("contract_termination_remark", param.ContractTerminationRemark)
                .Add("version", "1.0")
                .Remove(WechatpayConst.NonceStr).Remove(WechatpayConst.SpbillCreateIp);
        }
    }
}
