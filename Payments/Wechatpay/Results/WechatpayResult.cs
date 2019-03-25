using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Payments.Extensions;
using Payments.Util;
using Payments.Util.Http;
using Payments.Util.Logger;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Util.Validations;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Enums;
using Payments.Wechatpay.Parameters.Response.Base;
using Payments.Wechatpay.Services.Base;
using Payments.Wechatpay.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Payments.Wechatpay.Results
{
    /// <summary>
    /// 微信支付结果
    /// </summary>
    public class WechatpayResult<T> where T : WechatpayResponse
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

        public T Data { get; set; }
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
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var reader = Xml.ToDocument(response).CreateReader();
            Data = serializer.Deserialize(reader) as T;

            //var elements = Xml.ToElements(response);
            //elements.ForEach(node =>
            //{
            //    if (node.Name == WechatpayConst.Sign)
            //    {
            //        _sign = node.Value;
            //        return;
            //    }
            //    _builder.Add(node.Name.LocalName, node.Value);
            //});

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
        public Task<ValidationResultCollection> ValidateAsync()
        {
            if (GetReturnCode() != WechatpayConst.Success || GetResultCode() != WechatpayConst.Success)
                return Task.FromResult(new ValidationResultCollection(GetErrorCodeDescription()));
            var isValid = VerifySign();
            if (isValid == false)
                return Task.FromResult(new ValidationResultCollection("签名失败"));
            return Task.FromResult(ValidationResultCollection.Success);
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
