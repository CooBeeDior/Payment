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
 
  
    public class WechatDownloadfundflowService : WechatPayServiceBase<WechatDownloadfundflowRequest>, IWechatDownloadfundflowService
    {


        public WechatDownloadfundflowService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(httpClientFactory, loggerFactory)
        {

        }


        public Task<WechatPayResult<WechatPayResponse>> Dowbload(WechatDownloadfundflowRequest request)
        {
            return Request<WechatPayResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetDownloadFundFlowUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatDownloadfundflowRequest param)
        {
            builder.BillDate(param.BillDate).AccountType(param.AccountType).TarType(param.TarType).SignType(param.SignType)
                .Remove(WechatPayConst.NonceStr);
        }
    }
}
