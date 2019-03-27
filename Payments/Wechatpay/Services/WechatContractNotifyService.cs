using Microsoft.AspNetCore.Http;
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
    /// 扣款结果通知
    /// </summary>
    public class WechatContractNotifyService : WechatpayNotifyServiceBase<WechatContractNotifyResponse>, IWechatContractNotifyService
    {

        public WechatContractNotifyService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor) : base(configProvider, httpContextAccessor)
        {

        }


    }
 
}
