using Microsoft.Extensions.Logging;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Parameters;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using Payments.WechatPay.Services.Base;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.WechatPay.Services
{
    /// <summary>
    /// 微信App支付服务
    /// </summary>
    public class WechatPayAppPayService : WechatPayServiceBase, IWechatPayAppPayService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPayAppPayService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
        }

        public Task<WechatPayResult<WechatPayAppPayResponse>> PayAsync(WechatPayAppPayRequest request) 
        {
            return base.PayAsync<WechatPayAppPayResponse>(request);
        }
      


        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatPayPayRequestBase param)
        {
            base.InitBuilder(builder, param);
            builder.Remove(WechatPayConst.SceneInfo);

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
