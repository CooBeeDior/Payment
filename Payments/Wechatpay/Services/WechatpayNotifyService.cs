using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Services.Base;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 微信支付通知服务
    /// </summary>
    public class WechatpayNotifyService : WechatpayNotifyServiceBase<WechatpayNotifyResponse>, IWechatpayNotifyService
    {

        public WechatpayNotifyService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor) : base(configProvider, httpContextAccessor)
        {

        }


    }
}
