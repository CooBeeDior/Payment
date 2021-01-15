using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WechatPay.Abstractions;
using WechatPay.Parameters.Response;
using WechatPay.Services.Base;

namespace WechatPay.Services
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
