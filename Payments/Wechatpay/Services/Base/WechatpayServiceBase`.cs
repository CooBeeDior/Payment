using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util.Http;
using Payments.Util.Logger;
using Payments.Util.Validations;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Enums;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
namespace Payments.Wechatpay.Services.Base
{
    /// <summary>
    /// 支付基类
    /// </summary>
    /// <typeparam name="TPayParam"></typeparam>
    public abstract class WechatpayServiceBase<TPayParam> where TPayParam : class, IWechatpayRequest, IValidation, new()
    {
        protected ILogger<WechatpayServiceBase> Logger { get; }
        /// <summary>
        /// 配置提供器
        /// </summary>
        protected readonly WechatpayConfig Config;

        //protected readonly IWechatpayConfigProvider ConfigProvider;

        /// <summary>
        /// 初始化微信支付服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        protected WechatpayServiceBase(IWechatpayConfigProvider configProvider, ILoggerFactory loggerFactory)
        {
            configProvider.CheckNull(nameof(configProvider));
            //ConfigProvider = configProvider;
            Config = configProvider.GetConfig();
            Logger = loggerFactory.CreateLogger<WechatpayServiceBase>();
        }




        /// <summary>
        /// 验证
        /// </summary>
        protected void Validate(WechatpayConfig config, TPayParam param)
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
        protected async Task<WechatpayResult<TResponse>> Request<TResponse>(TPayParam param) where TResponse : WechatpayResponse
        {
            //var config = await ConfigProvider.GetConfigAsync();
            Validate(Config, param);
            var builder = CreateParameterBuilder();
            BuildConfig(builder, param);
            return await RequstResult<TResponse>(Config, builder);
        }

        protected virtual WechatpayParameterBuilder CreateParameterBuilder()
        {
            var builder = new WechatpayParameterBuilder(Config);
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
        protected void BuildConfig(WechatpayParameterBuilder builder, TPayParam param)
        {
            builder.Init();
            InitBuilder(builder, param);
        }


        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected abstract string GetRequestUrl(WechatpayConfig config);
        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected abstract void InitBuilder(WechatpayParameterBuilder builder, TPayParam param);

        /// <summary>
        /// 发送请求
        /// </summary>
        protected async Task<string> Request(WechatpayConfig config, WechatpayParameterBuilder builder)
        {
            var webClient = Web.Client();
            webClient.SetClientHandler(await SetCertificate());
            var resonse = await webClient
                .Post(GetRequestUrl(config))
                .XmlData(builder.ToXml(true, builder.Get(WechatpayConst.SignType).ToWechatpaySignType()))
                .ResultAsync();
            return await resonse.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 设置证书
        /// </summary>
        /// <returns></returns>
        protected virtual Task<HttpClientHandler> SetCertificate()
        {
            HttpClientHandler handler = new HttpClientHandler();
            return Task.FromResult(handler);
        }

        /// <summary>
        /// 请求结果
        /// </summary>
        protected async Task<WechatpayResult<TResponse>> RequstResult<TResponse>(WechatpayConfig config, WechatpayParameterBuilder builder) where TResponse : WechatpayResponse
        {
            var result = new WechatpayResult<TResponse>(Config, await Request(config, builder));
            WriteLog(config, builder, result);
            await ValidateResult(result);
            return result;
        }



        /// <summary>
        /// 写日志
        /// </summary>
        protected virtual void WriteLog<TResponse>(WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult<TResponse> result) where TResponse : WechatpayResponse
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
        protected virtual async Task ValidateResult<TResponse>(WechatpayResult<TResponse> result) where TResponse : WechatpayResponse
        {
            var validationResult = await result.ValidateAsync();
        }






    }
}
