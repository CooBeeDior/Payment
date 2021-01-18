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
    /// <summary>
    /// 下载交易账单
    /// </summary>
    public class WechatDownloadbillService : WechatPayServiceBase<WechatDownloadbillRequest>, IWechatDownloadbillService
    {


        public WechatDownloadbillService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(httpClientFactory, loggerFactory)
        {

        }

       
        public Task<WechatPayResult<WechatPayResponse>> Dowbload(WechatDownloadbillRequest request)
        {
            return Request<WechatPayResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetDownloadBillUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatDownloadbillRequest param)
        {
            builder.BillDate(param.BillDate).BillType(param.BillType).TarType(param.TarType)
                .Remove(WechatPayConst.NonceStr);
        }
    }
}
