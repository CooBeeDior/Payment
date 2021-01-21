using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AliPay.Abstractions;
using AliPay.Configs;
using AliPay.Parameters;
using AliPay.Parameters.Requests;
using AliPay.Services.Base;
using Payments.Core;

namespace AliPay.Services
{
    /// <summary>
    /// 支付宝App支付服务
    /// </summary>
    public class AlipayAppPayService : AlipayServiceBase<AlipayAppPayRequest>, IAlipayAppPayService
    {
        /// <summary>
        /// 初始化支付宝App支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayAppPayService(IAliPayConfigProvider provider, ILoggerFactory loggerFactory) : base(provider, loggerFactory)
        {
        }



        /// <summary>
        /// 请求结果
        /// </summary>
        protected override Task<PayResult> RequstResult(AliPayConfig config, AlipayParameterBuilder builder)
        {
            var result = builder.Result(true);
            WriteLog(config, builder, result);
            return Task.FromResult(new PayResult { Result = result });
        }

        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected override string GetMethod()
        {
            return "alipay.trade.app.pay";
        }
        protected override void InitContentBuilder(AlipayContentBuilder builder, AlipayAppPayRequest param)
        {
            builder.OutTradeNo(param.OrderId).TotalAmount(param.Money).Subject(param.Subject)
           .Body(param.Body).PassbackParams(param.Attach).TimeoutExpress(param.Timeout).NotifyUrl(param.NotifyUrl);

        }

    }
}