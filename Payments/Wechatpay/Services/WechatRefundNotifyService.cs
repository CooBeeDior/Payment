using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Payments.Extensions;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.IO;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 退款通知
    /// </summary>
    public class WechatRefundNotifyService : WechatpayNotifyServiceBase<WechatRefundNotifyResponse>, IWechatRefundNotifyService
    {

        public WechatRefundNotifyService(IWechatpayConfigProvider configProvider, IHttpContextAccessor httpContextAccessor, ILoggerFactory loggerFactory) : base(configProvider, httpContextAccessor)
        {

        }
      
 

        protected override void InitResult()
        {
            //建议使用 WechatRefundQueryService
            //TODO解密 https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_16&index=10
            Request?.EnableRewind();
            var sm = Request?.Body;
            var body = sm?.ToContent();
            Result = new WechatpayResult<WechatRefundNotifyResponse>(Config, body, Request);
        }

    }
}
