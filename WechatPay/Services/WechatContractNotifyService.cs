using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;
using System;
using System.Threading.Tasks;


namespace WechatPay.Services
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
