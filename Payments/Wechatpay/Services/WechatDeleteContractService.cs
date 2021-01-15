﻿using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
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
    /// 申请解约服务
    /// </summary>
    public class WechatDeleteContractService : WechatPayServiceBase<WechatDeleteContractRequest>, IWechatDeleteContractService
    {


        public WechatDeleteContractService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {

        }

        public Task<WechatPayResult<WechatDeleteContractResponse>> Cancel(WechatDeleteContractRequest request)
        {
            return Request<WechatDeleteContractResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetDeleteContractUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatDeleteContractRequest param)
        {
            builder.Add("plan_id", param.PlanId).Add("contract_code", param.ContractCode).Add("contract_id", param.ContractId).Add("contract_termination_remark", param.ContractTerminationRemark)
                .Add("version", "1.0")
                .Remove(WechatPayConst.NonceStr).Remove(WechatPayConst.SpbillCreateIp);
        }
    }
}
