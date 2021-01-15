using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Services.Base;

namespace Payments.WechatPay.Services
{
    /// <summary>
    /// 签约、解约结果通知
    /// </summary>
    public class WechatSignNotifyService : WechatPayNotifyServiceBase<WechatSignNotifyResponse>, IWechatSignNotifyService
    {

        public WechatSignNotifyService( ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor) : base( httpContextAccessor)
        {

        }


    }
}
