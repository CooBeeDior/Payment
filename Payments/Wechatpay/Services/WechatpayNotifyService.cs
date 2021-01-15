using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Payments.Attributes;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Services.Base;

namespace Payments.WechatPay.Services
{
    /// <summary>
    /// 微信支付通知服务
    /// </summary>
    public class WechatPayNotifyService : WechatPayNotifyServiceBase<WechatPayNotifyResponse>, IWechatPayNotifyService
    {

        public WechatPayNotifyService( ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor) : base( httpContextAccessor)
        {

        }


    }
}
