using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Util;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Payments.Extensions;

namespace WechatPay.Services
{
    /// <summary>
    /// 获取RSA加密公钥
    /// </summary>
    public class WechatPublicKeyService : WechatPayServiceBase<WechatPublicKeyRequest>, IWechatPublicKeyService
    {
        private readonly string file_path = "public.pem";
        /// <summary>
        /// 初始化微信小程序支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPublicKeyService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base(httpClientFactory, loggerFactory)
        {
        }

        public async Task<WechatPayResult<WechatPublicKeyResponse>> GetPublicKey(WechatPublicKeyRequest request)
        {
            if (!request.IsNew)
            {
                if (File.Exists(file_path))
                {
                    var publicKey = File.ReadAllText(file_path);
                    if (!publicKey.IsEmpty())
                    {
                        var result = new WechatPayResult<WechatPublicKeyResponse>();
                        var response = new WechatPublicKeyResponse();
                        response.ResultCode = WechatPayConst.Success;
                        response.ReturnCode = WechatPayConst.Success;
                        response.PubKey = publicKey;
                        return result;
                    }
                }
            }
            var resp = await Request<WechatPublicKeyResponse>(request);
            if (resp.GetResultCode() == WechatPayConst.Success && resp.GetReturnCode() == WechatPayConst.Success)
            {
                File.WriteAllText(file_path, resp.Data.PubKey);
            }
            return resp;
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetPublicKeyUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatPublicKeyRequest param)
        {

        }
    }
}
