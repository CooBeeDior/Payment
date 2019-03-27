using Microsoft.Extensions.Logging;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
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

        public Task<WechatpayResult<WechatpayAppPayResponse>> PayAsync(WechatpayAppPayRequest request) 
        {
            return base.PayAsync<WechatpayAppPayResponse>(request);
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

   
    }
}
