using Microsoft.Extensions.Logging;
using Payments.Extensions;
using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;

namespace WechatPay.Services
{
   
    public class CustomeWehcatPayService : WechatPayServiceBase<WechatPayCustomeRequest>, ICustomeWehcatPayService
    {
        private string _url = null;
        public CustomeWehcatPayService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(httpClientFactory, loggerFactory)
        {

        }

        public IWechatPayExtendParam SetUrl(string url)
        {
            _url = url;
            return this;
        }


        public Task<WechatPayResult<WechatPayResponse>> Request()
        {
            WechatPayCustomeRequest request = new WechatPayCustomeRequest();
            return base.Request<WechatPayResponse>(request);
        }


        protected override string GetRequestUrl(WechatPayConfig config)
        {
            _url.CheckNull(nameof(config));
            if (_url.StartsWith("http"))
            {
                return _url;
            }
            else
            {
                return config.GetUrl(_url);
            }
            
        }


        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatPayCustomeRequest param)
        {

        }
    }


}
