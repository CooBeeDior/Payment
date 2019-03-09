using System.Threading.Tasks;
using Payments.Alipay.Abstractions;
using Payments.Alipay.Configs;
using Payments.Alipay.Parameters;
using Payments.Alipay.Parameters.Requests;
using Payments.Alipay.Results;
using Payments.Alipay.Services.Base;
using Payments.Core;

namespace Payments.Alipay.Services
{
    /// <summary>
    /// 支付宝二维码支付服务
    /// </summary>
    public class AlipayQrCodePayService : AlipayServiceBase<AlipayPrecreateRequest>, IAlipayQrCodePayService
    {
        /// <summary>
        /// 初始化支付宝二维码支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayQrCodePayService(IAlipayConfigProvider provider) : base(provider)
        {
        }


        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected override string GetMethod()
        {
            return "alipay.trade.precreate";
        }



        /// <summary>
        /// 创建结果
        /// </summary>
        protected override PayResult CreateResult(AlipayParameterBuilder builder, AlipayResult result)
        {
            return new PayResult(result.Success, result.GetTradeNo(), result.Raw)
            {
                Parameter = builder.ToString(),
                Message = result.GetMessage(),
                Result = result.GetValue(AlipayConst.QrCode)
            };
        }

        protected override void InitContentBuilder(AlipayContentBuilder builder, AlipayPrecreateRequest param)
        {
            builder.OutTradeNo(param.OrderId).TotalAmount(param.Money).Subject(param.Subject)
                   .Body(param.Body).TimeoutExpress(param.Timeout)
                   .NotifyUrl(param.NotifyUrl);
        }
    }
}