using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Extensions;
using Payments.Properties;
using Payments.Util;
using Payments.Util.Http;
using Payments.Util.Validations;
using Payments.Wechatpay.Abstractions.Base;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters.Response;
using Payments.Wechatpay.Results;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Payments.Wechatpay.Services.Base
{
    /// <summary>
    /// 异步回调通知
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class WechatpayNotifyServiceBase<TResponse> : IWechatNotifyService<TResponse> where TResponse : WechatpayResponse
    {
        /// <summary>
        /// 请求
        /// </summary>
        protected HttpRequest Request { get; }
        /// <summary>
        /// 配置提供器
        /// </summary>
        //protected readonly IWechatpayConfigProvider ConfigProvider;
        protected WechatpayConfig Config { get; }

        /// <summary>
        /// 微信支付结果
        /// </summary>
        public WechatpayResult<TResponse> Result { get; protected set; }


        /// <summary>
        /// 初始化微信支付通知服务
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        public WechatpayNotifyServiceBase(IWechatpayConfigProvider configProvider, IHttpContextAccessor httpContextAccessor)
        {
            configProvider.CheckNull(nameof(configProvider));
            Config = configProvider.GetConfig();
            Request = httpContextAccessor?.HttpContext?.Request;
            InitResult();
        }




        /// <summary>
        /// 初始化结果
        /// </summary>
        protected virtual void InitResult()
        {
            Request?.EnableRewind();
            var sm = Request?.Body; ;
            var response = sm?.ToContent();
            Result = new WechatpayResult<TResponse>(Config, response, Request);

        }




        /// <summary>
        /// 验证
        /// </summary>
        public virtual async Task<ValidationResultCollection> ValidateAsync()
        {
            return await Result.ValidateAsync();
        }


        /// <summary>
        /// 返回成功消息
        /// </summary>
        public virtual string Success()
        {
            return Return(WechatpayConst.Success, WechatpayConst.Ok);
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        public virtual string Fail()
        {
            return Return(WechatpayConst.Fail, WechatpayConst.Fail);
        }

        /// <summary>
        /// 返回消息
        /// </summary>
        private string Return(string code, string message)
        {
            var xml = new Xml();
            xml.AddCDataNode(code, WechatpayConst.ReturnCode);
            xml.AddCDataNode(message, WechatpayConst.ReturnMessage);
            return xml.ToString();
        }


    }
}
