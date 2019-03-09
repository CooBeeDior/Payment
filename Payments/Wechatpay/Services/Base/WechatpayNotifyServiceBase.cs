using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Payments.Core;
using Payments.Extensions;
using Payments.Properties;
using Payments.Util;
using Payments.Util.Http;
using Payments.Util.Validations;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Results;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Payments.Wechatpay.Services.Base
{
    public abstract class WechatpayNotifyServiceBase : INotifyService
    {
        protected HttpRequest Request { get; }
        /// <summary>
        /// 配置提供器
        /// </summary>
        protected readonly IWechatpayConfigProvider ConfigProvider;
        /// <summary>
        /// 微信支付结果
        /// </summary>
        protected WechatpayResult Result;
        /// <summary>
        /// 是否已加载
        /// </summary>
        protected bool IsLoad;

        /// <summary>
        /// 初始化微信支付通知服务
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        public WechatpayNotifyServiceBase(IWechatpayConfigProvider configProvider, IHttpContextAccessor httpContextAccessor)
        {
            configProvider.CheckNull(nameof(configProvider));
            ConfigProvider = configProvider;
            IsLoad = false;
            Request = httpContextAccessor?.HttpContext?.Request;
        }

        /// <summary>
        /// 获取参数集合
        /// </summary>
        public IDictionary<string, string> GetParams()
        {
            Init();
            return Result.GetParams();
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        public T GetParam<T>(string name)
        {
            return GetParam(name).To<T>();
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        public string GetParam(string name)
        {
            Init();
            return Result.GetParam(name);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected void Init()
        {
            if (IsLoad)
                return;
            InitResult();
            IsLoad = true;
        }

        /// <summary>
        /// 初始化支付结果
        /// </summary>
        protected virtual void InitResult()
        {
            Request?.EnableRewind();
            string body = Request?.Body?.ToString();
            Result = new WechatpayResult(ConfigProvider, body, Request);
        }

        /// <summary>
        /// 验证
        /// </summary>
        public virtual async Task<ValidationResultCollection> ValidateAsync()
        {
            Init();
            if (Money <= 0)
                return new ValidationResultCollection(PayResource.InvalidMoney);
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
        /// 返回消息
        /// </summary>
        private string Return(string code, string message)
        {
            var xml = new Xml();
            xml.AddCDataNode(code, WechatpayConst.ReturnCode);
            xml.AddCDataNode(message, WechatpayConst.ReturnMessage);
            return xml.ToString();
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        public virtual string Fail()
        {
            return Return(WechatpayConst.Fail, WechatpayConst.Fail);
        }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId => GetParam(WechatpayConst.OutTradeNo);

        /// <summary>
        /// 支付订单号
        /// </summary>
        public string TradeNo => GetParam(WechatpayConst.TransactionId);

        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal Money => GetParam(WechatpayConst.TotalFee).ToDecimal() / 100M;
    }
}
