using Microsoft.Extensions.Logging;
using Payments.Extensions;
using Payments.Util;
using Payments.Util.Signatures;
using System.Net.Http;
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
    /// <summary>
    /// 企业付款到银行卡
    /// </summary>
    public class WechatPayBankService : WechatPayServiceBase<WechatPayBankRequest>, IWechatPayBankService
    {
        private readonly IWechatPublicKeyService _wechatPublicKeyService = null;
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPayBankService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory, IWechatPublicKeyService wechatPublicKeyService) : base(httpClientFactory, loggerFactory)
        {
            _wechatPublicKeyService = wechatPublicKeyService;
        }

        public Task<WechatPayResult<WechatPayBankResponse>> Pay(WechatPayBankRequest request)
        {
            return Request<WechatPayBankResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetPayBankUrl();
        }

        public override void SetConfig(WechatPayConfig config)
        {
            base.SetConfig(config);
            _wechatPublicKeyService.SetConfig(Config);
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatPayBankRequest param)
        {
            var wechatPublicKeyResponse = _wechatPublicKeyService.GetPublicKey(new WechatPublicKeyRequest() { }).GetAwaiter().GetResult();
            string publicKey = null;
            if (wechatPublicKeyResponse.GetResultCode() == WechatPayConst.Success && wechatPublicKeyResponse.GetReturnCode() == WechatPayConst.Success)
            {
                publicKey = wechatPublicKeyResponse?.Data?.PubKey;
            }
            publicKey.CheckNull($"获取公钥失败,错误原因:{wechatPublicKeyResponse.GetReturnMessage()}");

            param.EncBankNo = Encrypt.Rsa2Sign(param.EncBankNo, publicKey);
            param.EncTrueName = Encrypt.Rsa2Sign(param.EncTrueName, publicKey);


            builder.Add(WechatPayConst.PartnerTradeNo, param.PartnerTradeNo)                
                .Add(WechatPayConst.EncBankNo, param.EncBankNo)
                .Add(WechatPayConst.EncTrueName, param.EncTrueName)
                .Add(WechatPayConst.BankCode, param.BankCode).Add(WechatPayConst.Desc, param.Desc);
        }
    }
}
