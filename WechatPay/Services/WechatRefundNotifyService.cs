using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Payments.Extensions;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;
using System;
using System.IO;

namespace WechatPay.Services
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
