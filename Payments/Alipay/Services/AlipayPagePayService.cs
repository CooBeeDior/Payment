using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Payments.Alipay.Abstractions;
using Payments.Alipay.Configs;
using Payments.Alipay.Parameters;
using Payments.Alipay.Parameters.Requests;
using Payments.Alipay.Services.Base;
using Payments.Core;
using Util.Helpers;

namespace Payments.Alipay.Services
{
    /// <summary>
    /// 支付宝电脑网站支付服务
    /// </summary>
    public class AlipayPagePayService : AlipayServiceBase<AlipayPagePayRequest>, IAlipayPagePayService
    {
        /// <summary>
        /// 初始化支付宝电脑网站支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayPagePayService(IAlipayConfigProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        public override async Task<PayResult> PayAsync(AlipayPagePayRequest param)
        {
            var config = await ConfigProvider.GetConfigAsync();
            Validate(config, param);
            var builder = new AlipayParameterBuilder(config);
            Config(builder, param);
            var form = GetForm(builder);
            if (IsWriteLog)
            {
                WriteLog(config, builder, form);
            }
            return new PayResult { Result = form };
        }

        /// <summary>
        /// 获取表单
        /// </summary>
        private string GetForm(AlipayParameterBuilder builder)
        {
            FormBuilder formBuilder = new FormBuilder();
            formBuilder.AddParam(builder);
            return formBuilder.ToString();
        }

        /// <summary>
        /// 跳转到支付宝收银台
        /// </summary>
        /// <param name="request">电脑网站支付参数</param>
        public async Task RedirectAsync(AlipayPagePayRequest request)
        {
            var result = await PayAsync(request);
            var response = Web.Response;
            response.ContentType = "text/html; charset=utf-8";
            await response.WriteAsync(result.Result);
        }
        protected override void InitContentBuilder(AlipayParameterBuilder builder, AlipayPagePayRequest param)
        {
            builder.ReturnUrl(param.ReturnUrl);
        }
        protected override void InitContentBuilder(AlipayContentBuilder builder, AlipayPagePayRequest param)
        {
            builder.OutTradeNo(param.OrderId).TotalAmount(param.Money).Subject(param.Subject)
                .Body(param.Body).PassbackParams(param.Attach).TimeoutExpress(param.Timeout)
                .ReturnUrl(param.ReturnUrl).NotifyUrl(param.NotifyUrl);
        }
        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected override string GetMethod()
        {
            return "alipay.trade.page.pay";
        }


    }
}