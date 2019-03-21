using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Util;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;
namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 查询企业付款
    /// </summary>
    public class WechatGetTransferInfoService : WechatpayServiceBase<WechatGetTransferInfoRequest>, IWechatGetTransferInfoService
    {
        public WechatGetTransferInfoService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }

        public Task<PayResult> Query(WechatGetTransferInfoRequest param)
        {
            return Request(param);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetTransferInfoUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatGetTransferInfoRequest param)
        {
            builder.AppId(Config.AppId).Add("mch_id", Config.MerchantId).NonceStr(Id.GetId()).Add(WechatpayConst.PartnerTradeNo, param.PartnerTradeNo);
        }

        protected override WechatpayParameterBuilder CreateParameterBuilder()
        {
            var builder = new WechatpayCertParameterBuilder(Config);
            return builder;
        }
    }
}
