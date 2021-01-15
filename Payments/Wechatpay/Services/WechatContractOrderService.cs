using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.WechatPay;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Parameters;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using Payments.WechatPay.Services.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.WechatPay.Services
{  
    /// <summary>
     /// 公众号APP申请签约
     /// </summary>
    public class WechatContractOrderService : WechatPayServiceBase<WechatContractOrderRequest>, IWechatContractOrderService
    {


        public WechatContractOrderService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {

        }

        public Task<WechatPayResult<WechatContractOrderResponse>> Sign(WechatContractOrderRequest request)
        {
            return Request<WechatContractOrderResponse>(request);

        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetContractOrderUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatContractOrderRequest param)
        {
            builder.Add("contract_mchid", Config.MerchantId).Add("contract_appid", Config.AppId).OutTradeNo(param.OutTradeNo)
                 .DeviceInfo(param.DeviceInfo).Body(param.Body).Detail(param.Detail).Attach(param.Attach).NotifyUrl(param.NotifyUrl)
                 .TotalFee(param.TotalFee).TimeStart(param.TimeStart).TimeExpire(param.TimeExpire).GoodsTag(param.GoodsTag)
                 .TradeType(param.TradeType).ProductId(param.ProductId).LimitPay(param.LimitPay).OpenId(param.OpenId).Add("plan_id", param.PlanId)
                 .Add("contract_code", param.ContractCode).Add("request_serial", param.RequestSerial).Add("contract_display_account", param.ContractDisplayAccount)
                 .Add("contract_notify_url", param.ContractNotifyUrl);
        }
    }
}
