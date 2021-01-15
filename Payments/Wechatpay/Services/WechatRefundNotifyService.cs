using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Payments.Extensions;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using Payments.WechatPay.Services.Base;
using System;
using System.IO;

namespace Payments.WechatPay.Services
{
    /// <summary>
    /// 退款通知
    /// </summary>
    public class WechatRefundNotifyService : WechatPayNotifyServiceBase<WechatRefundNotifyResponse>, IWechatRefundNotifyService
    {

        public WechatRefundNotifyService( IHttpContextAccessor httpContextAccessor, ILoggerFactory loggerFactory) : base( httpContextAccessor)
        {

        }
      
 

        protected override void InitResult()
        {
            //建议使用 WechatRefundQueryService
            //TODO解密 https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_16&index=10
            Request?.EnableRewind();
            var sm = Request?.Body;
            var body = sm?.ToContent();
            Result = new WechatPayResult<WechatRefundNotifyResponse>(Config, body, Request);
        }

    }
}
