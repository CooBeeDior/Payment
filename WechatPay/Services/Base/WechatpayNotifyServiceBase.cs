using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Payments.Extensions;
using Payments.Util;
using Payments.Util.Validations;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System.Threading.Tasks;


namespace WechatPay.Services.Base
{
    /// <summary>
    /// 异步回调通知
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class WechatPayNotifyServiceBase<TResponse> : IWechatConfigSetter, IWechatNotifyService<TResponse> where TResponse : WechatPayResponse
    {
      
        /// <summary>
        /// 请求
        /// </summary>
        protected HttpRequest Request { get; }
        /// <summary>
        /// 配置
        /// </summary>   
        protected WechatPayConfig Config { get; private set; }

        /// <summary>
        /// 微信支付结果
        /// </summary>
        public WechatPayResult<TResponse> Result { get; protected set; }


        /// <summary>
        /// 初始化微信支付通知服务
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        public WechatPayNotifyServiceBase( IHttpContextAccessor httpContextAccessor)
        {           
            
            Request = httpContextAccessor?.HttpContext?.Request;
            InitResult();
        }

 
        public void SetConfig(WechatPayConfig config)
        {
            Config = config;
        }
        /// <summary>
        /// 初始化结果
        /// </summary>
        protected virtual void InitResult()
        {
            Request?.EnableRewind();
            var sm = Request?.Body; ;
            var response = sm?.ToContent();
            Result = new WechatPayResult<TResponse>(Config, response, Request);

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
            return Return(WechatPayConst.Success, WechatPayConst.Ok);
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        public virtual string Fail()
        {
            return Return(WechatPayConst.Fail, WechatPayConst.Fail);
        }

        /// <summary>
        /// 返回消息
        /// </summary>
        private string Return(string code, string message)
        {
            var xml = new Xml();
            xml.AddCDataNode(code, WechatPayConst.ReturnCode);
            xml.AddCDataNode(message, WechatPayConst.ReturnMessage);
            return xml.ToString();
        }


    }
}
