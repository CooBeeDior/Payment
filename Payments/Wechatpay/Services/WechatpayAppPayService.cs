using Microsoft.Extensions.Logging;
using Payments.Core;
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
    /// 微信App支付服务
    /// </summary>
    public class WechatpayAppPayService : WechatpayServiceBase, IWechatpayAppPayService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatpayAppPayService(IWechatpayConfigProvider provider, ILoggerFactory loggerFactory) : base(provider, loggerFactory)
        {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public Task<PayResult> PayAsync(WechatpayAppPayRequest request)
        {
            return base.PayAsync(request);
        }


        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatpayPayRequestBase param)
        {
            base.InitBuilder(builder, param);
            builder.Remove(WechatpayConst.SceneInfo);

        }
        /// <summary>
        /// 获取交易类型
        /// </summary>
        protected override string GetTradeType()
        {
            return "APP";
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected override string GetResult(WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result)
        {
            return new WechatpayParameterBuilder(config)
                .AppId(config.AppId)
                .PartnerId(config.MerchantId)
                 .PrepayId(result.GetPrepayId())
                .NonceStr(Id.GetId())
                .Timestamp()
                .Package()
                .ToJson();
        }
    }
}
