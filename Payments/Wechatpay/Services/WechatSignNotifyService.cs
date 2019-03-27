using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Payments.Extensions;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Abstractions.Base;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.IO;

namespace Payments.Wechatpay.Services
{

    /// <summary>
    /// 签约、解约结果通知
    /// </summary>
    public class WechatSignNotifyService : WechatpayNotifyServiceBase<WechatSignNotifyResponse>, IWechatSignNotifyService
    {

        public WechatSignNotifyService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor) : base(configProvider, httpContextAccessor)
        {

        }


    }
}
