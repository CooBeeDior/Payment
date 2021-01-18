using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using WechatPay;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace WechatPay.Services
{
    
    public class WechatBatchquerycommentService : WechatPayServiceBase<WechatBatchquerycommentRequest>, IWechatBatchquerycommentService
    {

        public WechatBatchquerycommentService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(httpClientFactory, loggerFactory)
        {

        } 

        public Task<WechatPayResult<WechatPayResponse>> Dowbload(WechatBatchquerycommentRequest request)
        {
            return Request<WechatPayResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetBatchQueryCommentUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatBatchquerycommentRequest param)
        {
            builder.SignType(param.SignType).BeginTime(param.BeginTime).EndTime(param.EndTime).Offset(param.Offset).Limit(param.Limit.ToString())
                .Remove(WechatPayConst.NonceStr);
        }
    }
}
