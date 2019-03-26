using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;


namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 企业转账服务
    /// </summary>
    public class WechatTransfersService : WechatpayServiceBase<WechatTransfersRequest>, IWechatTransfersService
    {
        public WechatTransfersService(IWechatpayConfigProvider provider, ILoggerFactory loggerFactory) : base(provider, loggerFactory)
        {
        }
        public Task<WechatpayResult<WechatTransfersResponse>> Transfer(WechatTransfersRequest param)
        {
            return Request<WechatTransfersResponse>(param);
        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetTransfersUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatTransfersRequest param)
        {
            builder.Add(WechatpayConst.MchAppId, Config.AppId).Add(WechatpayConst.MchId, Config.MerchantId).Add(WechatpayConst.DeviceInfo, param.DeviceInfo)
                .NonceStr(Id.GetId()).Add(WechatpayConst.PartnerTradeNo, param.PartnerTradeNo).OpenId(param.OpenId)
                .Add(WechatpayConst.CheckName, param.CheckName?.ToString()).Add(WechatpayConst.ReUserName, param.ReUserName)
                .Add(WechatpayConst.Amount, (param.Amount * 100).ToInt()).Add(WechatpayConst.Desc, param.Desc)
                .Add(WechatpayConst.SpbillCreateIp, Server.GetLanIp());
        }

        protected override WechatpayParameterBuilder CreateParameterBuilder()
        {
            var builder = new WechatpayCertParameterBuilder(Config);
            return builder;
        }
    }
}
