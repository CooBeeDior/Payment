using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.WechatPay;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Parameters;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.WechatPay.Services.Base
{
    /// <summary>
    /// 微信支付服务
    /// </summary>
    public abstract class WechatPayServiceBase : WechatPayServiceBase<WechatPayPayRequestBase>
    {

        /// <summary>
        /// 初始化微信支付服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        protected WechatPayServiceBase( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {

        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public Task<WechatPayResult<TResponse>> PayAsync<TResponse>(WechatPayPayRequestBase request) where TResponse : WechatPayResponse
        {
            return Request<TResponse>(request);
        }

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatPayPayRequestBase param)
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
        protected override string GetRequestUrl(WechatPayConfig config)
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
