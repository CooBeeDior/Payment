using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Services
{  
    /// <summary>
     /// 公众号APP申请签约
     /// </summary>
    public class WechatContractOrderService : WechatpayServiceBase<WechatContractOrderRequest>, IWechatContractOrderService
    {


        public WechatContractOrderService(IWechatpayConfigProvider configProvider, IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(configProvider, httpClientFactory, loggerFactory)
        {

        }

        public Task<WechatpayResult<WechatContractOrderResponse>> Sign(WechatContractOrderRequest request)
        {
            return Request<WechatContractOrderResponse>(request);

        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetContractOrderUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatContractOrderRequest param)
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
