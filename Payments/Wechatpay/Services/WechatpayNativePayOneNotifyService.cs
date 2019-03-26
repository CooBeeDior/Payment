using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Payments.Exceptions;
using Payments.Extensions;
using Payments.Util.Validations;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Services.Base;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 微信扫码支付异步回调
    /// </summary>
    public class WechatpayNativePayOneNotifyService : WechatpayNotifyServiceBase<WechatpayNativePayOneNotifyResponse>, IWechatpayNativePayOneNotifyService
    {

        protected IWechatpayNativePayService NativePayService { get; }
        public WechatpayNativePayOneNotifyService(IWechatpayConfigProvider configProvider, IWechatpayNativePayService nativePayService, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor) : base(configProvider, httpContextAccessor)
        {
            NativePayService = nativePayService;
        }

        public async Task<HttpResponseMessage> ReturnMessage(WechatpayNativePayRequest param)
        {
            HttpResponseMessage response = null;
            var validationResultCollection = await ValidateAsync();
            if (validationResultCollection.IsValid)
            {
                var result = await NativePayService.PayAsync(param);

                WechatpayParameterBuilder paramBuilder = new WechatpayParameterBuilder(Config);
                paramBuilder.Init();
                paramBuilder.PrepayId(result.Data?.PrepayId);
                paramBuilder.ReturnCode(result.Data?.ReturnCode);
                paramBuilder.ResultCode(result.Data?.ResultCode);
                paramBuilder.Add(WechatpayConst.ErrorCodeDescription, result.Data?.ReturnMsg);
                string xmlContent = paramBuilder.ToXml();
                response = xmlContent.XmlToHttpResponseMessage();
            }
            else
            {
                throw new PayException(validationResultCollection);
            }
            return response;
        }
    }
}
