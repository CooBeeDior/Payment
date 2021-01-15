using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util.Http;
using Payments.Util.Logger;
using Payments.Util.Validations;
using Payments.WechatPay;
using Payments.WechatPay.Abstractions;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Enums;
using Payments.WechatPay.Parameters;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
namespace Payments.WechatPay.Services.Base
{


    /// <summary>
    /// 支付基类
    /// </summary>
    /// <typeparam name="TPayParam"></typeparam>
    public abstract class WechatPayServiceBase<TPayParam> : IWechatConfigSetter where TPayParam : class, IWechatPayRequest, IValidation, new()
    {
        protected ILogger Logger { get; }
        /// <summary>
        /// 配置提供器
        /// </summary>
        protected WechatPayConfig Config { get; private set; }

        protected IHttpClientFactory HttpClientFactory;

        /// <summary>
        /// 初始化微信支付服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        protected WechatPayServiceBase(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory)
        {
            HttpClientFactory = httpClientFactory;
            Logger = loggerFactory.CreateLogger(this.GetType().Name);

        }




        public void SetConfig(WechatPayConfig config)
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
            //var config = await ConfigProvider.GetConfigAsync();
            Validate(Config, param);
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
        /// 发送请求
        /// </summary>
        protected async Task<string> Request(WechatPayConfig config, WechatPayParameterBuilder builder)
        {
            var client = HttpClientFactory.CreateClient("wechat");
            if (_extParam != null && _extParam.Any())
            {
                foreach (var item in _extParam)
                {
                    builder.Add(item.Key, item.Value);
                }
            }
            var resonse = await Web.Client(client)
                .Post(GetRequestUrl(config))
                .XmlData(builder.ToXml(true, builder.Get(WechatPayConst.SignType).ToWechatPaySignType()))
                .ResultAsync();
            return await resonse.Content.ReadAsStringAsync();
        }

        private IDictionary<string, object> _extParam = null;
        public void ExtensionParameter(IDictionary<string, object> extParam)
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
