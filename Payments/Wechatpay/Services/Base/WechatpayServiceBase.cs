using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Services.Base
{
    /// <summary>
    /// 微信支付服务
    /// </summary>
    public abstract class WechatpayServiceBase : WechatpayServiceBase<WechatpayPayRequestBase>, IPayService
    {

        /// <summary>
        /// 初始化微信支付服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        protected WechatpayServiceBase(IWechatpayConfigProvider configProvider, IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(configProvider, httpClientFactory, loggerFactory)
        {

        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public Task<WechatpayResult<TResponse>> PayAsync<TResponse>(WechatpayPayRequestBase request) where TResponse : WechatpayResponse
        {
            return Request<TResponse>(request);
        }

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatpayPayRequestBase param)
        {
            builder.Body(param.Body).OutTradeNo(param.OutTradeNo).DeviceInfo(param.DeviceInfo).TradeType(GetTradeType())
                .TotalFee(param.TotalFee).NotifyUrl(param.NotifyUrl).Attach(param.Attach)
                .Detail(param.Detail).FeeType(param.FeeType).TimeStart(param.TimeStart)
                .TimeExpire(param.TimeExpire).GoodsTag(param.GoodsTag).ProductId(param.ProductId)
                .LimitPay(param.LimitPay).Receipt(param.Receipt).SceneInfo(param.SceneInfo)
                .OpenId(param.OpenId);

        }


        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetOrderUrl();
        }

        /// <summary>
        /// 获取支付类型
        /// </summary>
        /// <returns></returns>
        protected abstract string GetTradeType();

    }
}
