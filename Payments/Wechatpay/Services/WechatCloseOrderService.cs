using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;
namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 关闭订单服务
    /// </summary>
    public class WechatCloseOrderService : WechatpayServiceBase<WechatCloseOrderRequest>, IWechatCloseOrderService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatCloseOrderService(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory) : base(configProvider, loggerFactory)
        {

        }


        public Task<PayResult> CloseAsync(WechatCloseOrderRequest param)
        {
            return Request(param);
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatCloseOrderRequest param)
        {
            builder.OutTradeNo(param.OutTradeNo).Remove(WechatpayConst.SpbillCreateIp);//.Remove(WechatpayConst.NotifyUrl);
        }

       

        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetOrderCloseUrl();
        }
    }
}
