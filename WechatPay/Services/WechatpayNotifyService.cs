using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Payments.Attributes;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters.Response;
using WechatPay.Services.Base;

namespace WechatPay.Services
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
