using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AliPay.Abstractions;
using AliPay.Configs;
using AliPay.Parameters;
using AliPay.Parameters.Requests;
using AliPay.Services.Base;
using Payments.Core.Response;
using System.Threading.Tasks;

namespace AliPay.Services
{
    /// <summary>
    /// 支付宝手机网站支付服务
    /// </summary>
    public class AlipayWapPayService : AlipayServiceBase<AlipayWapPayRequest>, IAlipayWapPayService {
        /// <summary>
        /// 初始化支付宝手机网站支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayWapPayService( IAliPayConfigProvider provider, ILoggerFactory loggerFactory) : base( provider, loggerFactory) {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        public override async Task<PayResult> PayAsync( AlipayWapPayRequest param ) {
            var config = await ConfigProvider.GetConfigAsync();
            Validate( config, param );
            var builder = new AlipayParameterBuilder( config );
            Config( builder, param );
            var form = GetForm( builder );
            WriteLog( config, builder, form );
            return new PayResult { Result = form };
        }

        /// <summary>
        /// 获取表单
        /// </summary>
        private string GetForm( AlipayParameterBuilder builder ) {
            FormBuilder formBuilder = new FormBuilder();
            formBuilder.AddParam( builder );
            return formBuilder.ToString();
        }

    
        /// <summary>
        /// 跳转到支付宝收银台
        /// </summary>
        /// <param name="request">手机网站支付参数</param>
        public async Task RedirectAsync( AlipayWapPayRequest request ) {
            var result = await PayAsync( request );
            var response = Web.Response;
            response.ContentType = "text/html;charset=utf-8";
            await response.WriteAsync( result.Result );
        }

    
        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected override string GetMethod() {
            return "alipay.trade.wap.pay";
        }

        protected override void InitContentBuilder(AlipayContentBuilder builder, AlipayWapPayRequest param)
        {
         
        }
    }
}