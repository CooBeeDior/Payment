using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util.Http;
using Payments.Util.Logger;
using Payments.Util.Validations;
using WechatPay;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Enums;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Security.Authentication;
using Payments.Core.Enum;

namespace WechatPay.Services.Base
{
    /// <summary>
    /// 支付基类
    /// </summary>
    /// <typeparam name="TPayParam"></typeparam>
    public abstract class WechatPayServiceBase<TPayParam> : IWechatConfigSetter, IWechatPayExtendParam where TPayParam : class, IWechatPayRequest, IValidation, new()
    {
        protected ILogger Logger { get; }
        /// <summary>
        /// 配置提供器
        /// </summary>
        protected WechatPayConfig Config { get; private set; }

        protected IHttpClientFactory HttpClientFactory;

        protected TPayParam PayParam { get; private set; }

        /// <summary>
        /// 初始化微信支付服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        protected WechatPayServiceBase(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory)
        {
            HttpClientFactory = httpClientFactory;
            Logger = loggerFactory.CreateLogger(this.GetType().Name);

        }

        public virtual void SetConfig(WechatPayConfig config)
        {
            Config = config;
        }

        /// <summary>
        /// 验证
        /// </summary>
        protected void Validate(WechatPayConfig config, TPayParam param)
        {
            config.CheckNull(nameof(config));
            param.CheckNull(nameof(param));
            config.Validate();
            param.Validate();
            ValidateParam(param);
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        protected async Task<WechatPayResult<TResponse>> Request<TResponse>(TPayParam param) where TResponse : WechatPayResponse
        {
            Validate(Config, param);
            PayParam = param;
            var builder = CreateParameterBuilder();
            BuildConfig(builder, param);
            return await RequstResult<TResponse>(Config, builder);
        }

        protected virtual WechatPayParameterBuilder CreateParameterBuilder()
        {
            var builder = new WechatPayParameterBuilder(Config);
            return builder;
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected virtual void ValidateParam(TPayParam param)
        {
        }

        /// <summary>
        /// 初始化请求参数配置
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected void BuildConfig(WechatPayParameterBuilder builder, TPayParam param)
        {
            builder.Init();
            InitBuilder(builder, param);
        }


        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected abstract string GetRequestUrl(WechatPayConfig config);
        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected abstract void InitBuilder(WechatPayParameterBuilder builder, TPayParam param);

        /// <summary>
        /// 请求类型
        /// </summary>
        /// <returns></returns>
        protected virtual RequestType RequestDataType()
        {
            return RequestType.Xml;
        }

        /// <summary>
        /// 是否使用证书
        /// </summary>
        /// <returns></returns>
        protected virtual bool UseCertificate()
        {
            return false;
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        protected async Task<string> Request(WechatPayConfig config, WechatPayParameterBuilder builder)
        {
            //先这样处理把,看看有什么好的优化方案，实在不行通过反射把数据绑定上去，
            //暂时不用IHttpClientFactory
            //var client = HttpClientFactory.CreateClient("wechat");

            var handler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                SslProtocols = SslProtocols.Tls12,
            };
            if (UseCertificate())
            {
                if (config.CertificateData != null)
                {
                    var certificate = new X509Certificate2(config.CertificateData, config.CertificatePwd, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

                    handler.ClientCertificates.Add(certificate);
                    handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                }
                else
                {
                    throw new Exception($"请求{GetRequestUrl(config)}需要证书");
                }
            }
          
            var client = new HttpClient(handler);

            if (_extParam != null && _extParam.Any())
            {
                foreach (var item in _extParam)
                {
                    builder.Add(item.Key, item.Value);
                }
            }
            HttpResponseMessage response = null;
            var requestType = RequestDataType();
            switch (requestType)
            {
                case RequestType.Json:
                    response = await Web.Client(client)
                      .Post(GetRequestUrl(config))
                      .JsonData(builder.ToJson(true, builder.Get(WechatPayConst.SignType).ToPaySignType()))
                      .ResultAsync();
                    break;
                case RequestType.Xml:
                default:
                    response = await Web.Client(client)
                      .Post(GetRequestUrl(config))
                      .JsonData(builder.ToJson(true, builder.Get(WechatPayConst.SignType).ToPaySignType()))
                      .ResultAsync();

                    break;
            }
            return await response?.Content?.ReadAsStringAsync();

        }

        private IDictionary<string, object> _extParam = null;
        public void SetExtensionParameter(IDictionary<string, object> extParam)
        {
            _extParam = extParam;
        }

        /// <summary>
        /// 请求结果
        /// </summary>
        protected async Task<WechatPayResult<TResponse>> RequstResult<TResponse>(WechatPayConfig config, WechatPayParameterBuilder builder) where TResponse : WechatPayResponse
        {
            var result = new WechatPayResult<TResponse>(Config, await Request(config, builder));
            WriteLog(config, builder, result);
            await ValidateResult(result);
            return result;
        }



        /// <summary>
        /// 写日志
        /// </summary>
        protected virtual void WriteLog<TResponse>(WechatPayConfig config, WechatPayParameterBuilder builder, WechatPayResult<TResponse> result) where TResponse : WechatPayResponse
        {
            var logContent = LogContentBuilder.CreateLogContentBuilder()
                .SetEventId(Guid.NewGuid()).SetMoudle(GetType().FullName).SetTitle("微信支付")
                .AddContent($"支付方式 : {GetType()}")
                .AddContent($"支付网关 : {config.GetOrderUrl()}")
                .AddContent($"原始响应:{result?.Raw}")
                .Build();
            Logger.LogInfo(logContent);

        }


        /// <summary>
        /// 验证返回结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected virtual async Task ValidateResult<TResponse>(WechatPayResult<TResponse> result) where TResponse : WechatPayResponse
        {
            var validationResult = await result.ValidateAsync();
        }






    }
}
