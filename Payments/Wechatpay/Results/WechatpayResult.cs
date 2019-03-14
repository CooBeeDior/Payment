using Microsoft.AspNetCore.Http;
using Payments.Extensions;
using Payments.Util;
using Payments.Util.Http;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Util.Validations;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Signatures;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Results
{
    /// <summary>
    /// 微信支付结果
    /// </summary>
    public class WechatpayResult
    {
        /// <summary>
        /// 配置提供器
        /// </summary>
        //private readonly IWechatpayConfigProvider _configProvider;

        private readonly WechatpayConfig _wechatpayConfig;
        /// <summary>
        /// 响应结果
        /// </summary>
        private readonly ParameterBuilder _builder;
        /// <summary>
        /// 签名
        /// </summary>
        private string _sign;
        /// <summary>
        /// 微信支付原始响应
        /// </summary>
        public string Raw { get; }

        public HttpRequest Request { get; }

        /// <summary>
        /// 初始化微信支付结果
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        /// <param name="response">xml响应消息</param>
        public WechatpayResult(WechatpayConfig wechatpayConfig, string response, HttpRequest httpRequest = null)
        {
            wechatpayConfig.CheckNull(nameof(wechatpayConfig));
            _wechatpayConfig = wechatpayConfig;
            Raw = response;
            _builder = new ParameterBuilder();
            Resolve(response);
            Request = httpRequest;
        }

        /// <summary>
        /// 解析响应
        /// </summary>
        private void Resolve(string response)
        {
            if (response.IsEmpty())
                return;
            var elements = Xml.ToElements(response);
            elements.ForEach(node =>
            {
                if (node.Name == WechatpayConst.Sign)
                {
                    _sign = node.Value;
                    return;
                }
                _builder.Add(node.Name.LocalName, node.Value);
            });
            WriteLog();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog()
        {
            //var log = GetLog();
            //if( log.IsTraceEnabled == false )
            //    return;
            //log.Class( GetType().FullName )
            //    .Caption( "微信支付返回" )
            //    .Content( "参数:" )
            //    .Content( GetParams() )
            //    .Content()
            //    .Content( "原始响应:" )
            //    .Content( Raw )
            //    .Trace();
        }



        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">xml节点名称</param>
        public string GetParam(string name)
        {
            return _builder.GetValue(name).SafeString();
        }

        /// <summary>
        /// 获取返回状态码
        /// </summary>
        public string GetReturnCode()
        {
            return GetParam(WechatpayConst.ReturnCode);
        }

        /// <summary>
        /// 获取业务结果代码
        /// </summary>
        public string GetResultCode()
        {
            return GetParam(WechatpayConst.ResultCode);
        }

        /// <summary>
        /// 获取返回消息
        /// </summary>
        public string GetReturnMessage()
        {
            return GetParam(WechatpayConst.ReturnMessage);
        }

        /// <summary>
        /// 获取应用标识
        /// </summary>
        public string GetAppId()
        {
            return GetParam(WechatpayConst.AppId);
        }

        /// <summary>
        /// 获取商户号
        /// </summary>
        public string GetMerchantId()
        {
            return GetParam(WechatpayConst.MerchantId);
        }

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        public string GetNonce()
        {
            return GetParam(WechatpayConst.NonceStr);
        }

        /// <summary>
        /// 获取预支付标识
        /// </summary>
        public string GetPrepayId()
        {
            return GetParam(WechatpayConst.PrepayId);
        }

        /// <summary>
        /// 获取交易类型
        /// </summary>
        public string GetTradeType()
        {
            return GetParam(WechatpayConst.TradeType);
        }
        /// <summary>
        /// 获取订单号Id
        /// </summary>
        /// <returns></returns>
        public string GetTransactionId()
        {
            return GetParam(WechatpayConst.TransactionId);
        }

        /// <summary>
        /// 获取错误码
        /// </summary>
        public string GetErrorCode()
        {
            return GetParam(WechatpayConst.ErrorCode);
        }

        /// <summary>
        /// 获取错误码和描述
        /// </summary>
        public string GetErrorCodeDescription()
        {
            return GetParam(WechatpayConst.ErrorCodeDescription);
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        public string GetSign()
        {
            return _sign;
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        public IDictionary<string, string> GetParams()
        {
            var builder = new ParameterBuilder(_builder);
            builder.Add(WechatpayConst.Sign, _sign);
            return builder.GetDictionary().ToDictionary(t => t.Key, t => t.Value.SafeString());
        }

        /// <summary>
        /// 验证
        /// </summary>
        public async Task<ValidationResultCollection> ValidateAsync()
        {
            if (GetReturnCode() != WechatpayConst.Success || GetResultCode() != WechatpayConst.Success)
                return new ValidationResultCollection(GetErrorCodeDescription());
            var isValid = VerifySign();
            if (isValid == false)
                return new ValidationResultCollection("签名失败");
            return ValidationResultCollection.Success;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        public bool VerifySign()
        {
            return SignManagerFactory.Create(_wechatpayConfig, Request, _builder).Verify(GetSign());
        }
    }
}
