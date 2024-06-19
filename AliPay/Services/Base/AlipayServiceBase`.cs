using Microsoft.Extensions.Logging;
using AliPay.Configs;
using AliPay.Parameters;
using AliPay.Parameters.Requests;
using AliPay.Results;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util.Http;
using Payments.Util.Logger;
using Payments.Util.Validations;
using System;
using System.Threading.Tasks;

namespace AliPay.Services.Base
{
    public abstract class AlipayServiceBase<TPayParam> where TPayParam : class, IAlipayRequest, IValidation, new()
    {
        /// <summary>
        /// 配置提供器
        /// </summary>
        protected readonly IAliPayConfigProvider ConfigProvider;

        protected ILogger<AlipayServiceBase> Logger { get; }

        /// <summary>
        /// 初始化支付宝支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        protected AlipayServiceBase(IAliPayConfigProvider provider, ILoggerFactory loggerFactory)
        {
            provider.CheckNull(nameof(provider));
            ConfigProvider = provider;
            Logger = loggerFactory.CreateLogger<AlipayServiceBase>();

        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        public virtual async Task<AlipayResult> PayAsync(TPayParam param)
        {
            var config = await ConfigProvider.GetConfigAsync();
            Validate(config, param);
            var builder = new AlipayParameterBuilder(config);
            Config(builder, param);
            return await RequstResult(config, builder);
        }

        /// <summary>
        /// 验证
        /// </summary>
        protected void Validate(AliPayConfig config, TPayParam param)
        {
            config.CheckNull(nameof(config));
            param.CheckNull(nameof(param));
            config.Validate();
            param.Validate();
            ValidateParam(param);
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
        /// <param name="builder">支付宝参数生成器</param>
        /// <param name="param">支付参数</param>
        protected void Config(AlipayParameterBuilder builder, TPayParam param)
        {
            builder.Init();
            builder.Method(GetMethod());
            builder.Content.Scene(GetScene());
            InitContentBuilder(builder, param);
            InitContentBuilder(builder.Content, param);
        }




        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected abstract string GetMethod();

        /// <summary>
        /// 获取场景
        /// </summary>
        protected virtual string GetScene()
        {
            return string.Empty;
        }
        protected virtual void InitContentBuilder(AlipayParameterBuilder builder, TPayParam param)
        {

        }

        /// <summary>
        /// 初始化内容生成器
        /// </summary>
        /// <param name="builder">内容参数生成器</param>
        /// <param name="param">支付参数</param>
        protected abstract void InitContentBuilder(AlipayContentBuilder builder, TPayParam param);



        /// <summary>
        /// 请求结果
        /// </summary>
        protected virtual async Task<AlipayResult> RequstResult(AliPayConfig config, AlipayParameterBuilder builder)
        {
            var result = new AlipayResult(await Request(config, builder));
            WriteLog(config, builder, result);
            return CreateResult(builder, result);
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        protected virtual async Task<string> Request(AliPayConfig config, AlipayParameterBuilder builder)
        {
            var resonse = await Web.Client()
                .Post(config.GetGatewayUrl())
                .JsonData(builder.GetDictionary())
                .ResultAsync();
            return await resonse.Content.ReadAsStringAsync();
        }



        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog(AliPayConfig config, AlipayParameterBuilder builder, AlipayResult result)
        {
            var logContent = LogContentBuilder.CreateLogContentBuilder()
                .SetEventId(Guid.NewGuid()).SetMoudle(GetType().FullName).SetTitle("支付宝支付")
                .AddContent($"支付宝支付 : {GetType()}")
                .AddContent($"支付网关 : {config?.GetGatewayUrl()}")
                .AddContent($"请求参数:{builder?.GetDictionary()?.ToXml()}")
                .AddContent($"返回结果:{result?.GetDictionary()}")
                .AddContent($"原始响应:{result?.Raw}")
                .Build();
            Logger.LogInfo(logContent);


        }






        /// <summary>
        /// 创建结果
        /// </summary>
        protected virtual AlipayResult CreateResult(AlipayParameterBuilder builder, AlipayResult result)
        {
            return new AlipayResult(result.Success, result.GetTradeNo(), result.Raw)
            {
                Parameter = builder.ToString(),
                Message = result.GetMessage()
            };
        }
    }
}
