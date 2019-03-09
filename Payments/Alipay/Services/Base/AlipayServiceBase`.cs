using System.Threading.Tasks;
using Payments.Alipay.Configs;
using Payments.Alipay.Parameters;
using Payments.Alipay.Results;
using Payments.Core;
using Util;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Validations;

namespace Payments.Alipay.Services.Base
{
    public abstract class AlipayServiceBase<TPayParam> where TPayParam : class, IValidation, new()
    {
        /// <summary>
        /// 配置提供器
        /// </summary>
        protected readonly IAlipayConfigProvider ConfigProvider;

        /// <summary>
        /// 是否写日志
        /// </summary>
        protected bool IsWriteLog { get; set; } = true;

        /// <summary>
        /// 是否发送请求
        /// </summary>
        public bool IsSend { get; set; } = true;

        /// <summary>
        /// 初始化支付宝支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        protected AlipayServiceBase(IAlipayConfigProvider provider)
        {
            provider.CheckNull(nameof(provider));
            ConfigProvider = provider;
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        public virtual async Task<PayResult> PayAsync(TPayParam param)
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
        protected void Validate(AlipayConfig config, TPayParam param)
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
        protected virtual async Task<PayResult> RequstResult(AlipayConfig config, AlipayParameterBuilder builder)
        {
            var result = new AlipayResult(await Request(config, builder));
            if (IsWriteLog)
            {
                WriteLog(config, builder, result);
            }
            return CreateResult(builder, result);
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        protected virtual async Task<string> Request(AlipayConfig config, AlipayParameterBuilder builder)
        {
            if (IsSend == false)
                return string.Empty;
            return await Web.Client()
                .Post(config.GetGatewayUrl())
                .Data(builder.GetDictionary())
                .ResultAsync();
        }



        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog(AlipayConfig config, AlipayParameterBuilder builder, AlipayResult result)
        {
            var log = GetLog();
            if (log.IsTraceEnabled == false)
                return;
            log.Class(GetType().FullName)
                .Caption("支付宝支付")
                .Content($"支付方式 :  {GetType()}")
                .Content($"支付网关 : {config.GetGatewayUrl()}")
                .Content("请求参数:")
                .Content(builder.GetDictionary())
                .Content()
                .Content("返回结果:")
                .Content(result.GetDictionary())
                .Content()
                .Content("原始请求:")
                .Content(builder.ToString())
                .Content()
                .Content("原始响应: ")
                .Content(result.Raw)
                .Trace();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog(AlipayConfig config, AlipayParameterBuilder builder, string content)
        {
            var log = GetLog();
            if (log.IsTraceEnabled == false)
                return;
            log.Class(GetType().FullName)
                .Caption("支付宝支付")
                .Content($"支付方式 :  {GetType()}")
                .Content($"支付网关 : {config.GetGatewayUrl()}")
                .Content("请求参数:")
                .Content(builder.GetDictionary())
                .Content()
                .Content("原始请求:")
                .Content(builder.ToString())
                .Content()
                .Content("内容: ")
                .Content(content)
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog()
        {
            try
            {
                return Log.GetLog(AlipayConst.TraceLogName);
            }
            catch
            {
                return Log.Null;
            }
        }



        /// <summary>
        /// 创建结果
        /// </summary>
        protected virtual PayResult CreateResult(AlipayParameterBuilder builder, AlipayResult result)
        {
            return new PayResult(result.Success, result.GetTradeNo(), result.Raw)
            {
                Parameter = builder.ToString(),
                Message = result.GetMessage()
            };
        }
    }
}
