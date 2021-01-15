using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Parameters;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using Payments.WechatPay.Services.Base;
using System;
using System.Threading.Tasks;


namespace Payments.WechatPay.Services
{
    /// <summary>
    /// 扣款结果通知
    /// </summary>
    public class WechatContractNotifyService : WechatPayNotifyServiceBase<WechatContractNotifyResponse>, IWechatContractNotifyService
    {

        public WechatContractNotifyService( ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor) : base( httpContextAccessor)
        {

        }


    }
 
}
