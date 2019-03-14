using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util.Http;
using Payments.Util.Logger;
using Payments.Util.Validations;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Results;
using System;
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

        protected async Task<PayResult> Request(TPayParam param)
        {
            //var config = await ConfigProvider.GetConfigAsync();
            Validate(Config, param);
            var builder = CreateParameterBuilder();
            BuildConfig(builder, param);
            return await RequstResult(Config, builder);
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
        /// 配置
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected void BuildConfig(WechatpayParameterBuilder builder, TPayParam param)
        {
            builder.Init();
            InitBuilder(builder, param);
        }



        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected abstract void InitBuilder(WechatpayParameterBuilder builder, TPayParam param);


        /// <summary>
        /// 请求结果
        /// </summary>
        protected async Task<PayResult> RequstResult(WechatpayConfig config, WechatpayParameterBuilder builder)
        {
            var result = new WechatpayResult(Config, await Request(config, builder));
            WriteLog(config, builder, result);
            return await CreateResult(config, builder, result);
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        protected virtual async Task<string> Request(WechatpayConfig config, WechatpayParameterBuilder builder)
        {
            var resonse = await Web.Client()
                .Post(GetRequestUrl(config))
                .XmlData(builder.ToXml())
                .ResultAsync();
            return await resonse.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected abstract string GetRequestUrl(WechatpayConfig config);




        /// <summary>
        /// 写日志
        /// </summary>
        protected virtual void WriteLog(WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result)
        {
            var logContent = LogContentBuilder.CreateLogContentBuilder()
                .SetEventId(Guid.NewGuid()).SetMoudle(GetType().FullName).SetTitle("微信支付")
                .AddContent($"支付方式 : {GetType()}")
                .AddContent($"支付网关 : {config.GetOrderUrl()}")
                .AddContent($"请求参数:{builder?.ToXml()}")
                .AddContent($"返回结果:{result?.GetParams()}")
                .AddContent($"原始响应:{result?.Raw}")
                .Build();
            Logger.LogInfo(logContent);

        }


        /// <summary>
        /// 创建支付结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected virtual async Task<PayResult> CreateResult(WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result)
        {
            var success = (await result.ValidateAsync()).IsValid;
            return new PayResult(success, result.GetPrepayId(), result.Raw)
            {
                Parameter = builder.ToString(),
                Message = result.GetReturnMessage(),
                Result = success ? GetResult(config, builder, result) : null
            };
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected virtual string GetResult(WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result)
        {
            return result.GetPrepayId();
        }





    }
}
