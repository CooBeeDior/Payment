﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Payments.Extensions;
using Payments.Util;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Util.Signatures;
using Payments.Util.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WechatPay.Configs;
using WechatPay.Parameters.Response;

namespace WechatPay.Results
{
    /// <summary>
    /// 微信支付结果
    /// </summary>
    public class WechatPayResult<TResponse> where TResponse : WechatPayResponse
    {

        /// <summary>
        /// 参数
        /// </summary>
        private readonly ParameterBuilder _builder = new ParameterBuilder();

        /// <summary>
        /// 签名
        /// </summary>
        private string _sign;

        /// <summary>
        /// 配置
        /// </summary>
        private readonly WechatPayConfig _wechatPayConfig;

        /// <summary>
        /// 微信支付原始响应
        /// </summary>
        public string Raw { get; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success
        {
            get
            {
                return GetResultCode() == WechatPayConst.Success && GetResultCode() == WechatPayConst.Success;
            }
        }

        public HttpRequest Request { get; }

        public TResponse Data { get; set; }
        /// <summary>
        /// 初始化微信支付结果
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        /// <param name="response">xml响应消息</param>
        public WechatPayResult(WechatPayConfig wechatPayConfig, string response, HttpRequest httpRequest = null)
        {
            wechatPayConfig.CheckNull(nameof(wechatPayConfig));
            _wechatPayConfig = wechatPayConfig;
            Raw = response;
            Request = httpRequest;
        }
        public WechatPayResult()
        {
        }

        /// <summary>
        /// 解析响应
        /// </summary>
        public virtual void Resolve(string response)
        {
            XmlResolve(response);

        }



        protected void XmlResolve(string response)
        {
            if (response.IsEmpty())
                return;
            XmlSerializer serializer = new XmlSerializer(typeof(TResponse));
            var reader = Xml.ToDocument(response).CreateReader();
            Data = serializer.Deserialize(reader) as TResponse;

            var elements = Xml.ToElements(response);
            elements.ForEach(node =>
            {
                if (node.Name == WechatPayConst.Sign)
                {
                    _sign = node.Value;
                    return;
                }
                _builder.Add(node.Name.LocalName, node.Value);
            });

        }


        protected void JsonResolve(string response)
        {
            if (response.IsEmpty())
                return;

            Data = JsonConvert.DeserializeObject<TResponse>(response);
            _sign = Data.Sign;
            var properties = typeof(TResponse).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in properties)
            {
                if (item.Name.ToLower() != WechatPayConst.Sign)
                {
                    var jsonIngoreAttribute = item.GetCustomAttribute<JsonIgnoreAttribute>();
                    if (jsonIngoreAttribute != null)
                    {
                        continue;
                    }
                    var jsonPropertyAttribute = item.GetCustomAttribute<JsonPropertyAttribute>();
                    _builder.Add(jsonPropertyAttribute.PropertyName ?? item.Name.ToLower(), item.GetValue(Data));
                }

            }


        }




        /// <summary>
        /// 获取返回状态码
        /// </summary>
        public string GetReturnCode()
        {
            return Data?.ReturnCode;
        }

        /// <summary>
        /// 获取业务结果代码
        /// </summary>
        public string GetResultCode()
        {
            return Data?.ResultCode;
        }

        /// <summary>
        /// 获取返回消息
        /// </summary>
        public string GetReturnMessage()
        {
            return Data?.ReturnMsg;
        }


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
            builder.Add(WechatPayConst.Sign, _sign);
            return builder.GetDictionary().ToDictionary(t => t.Key, t => t.Value.SafeString());
        }

        /// <summary>
        /// 验证
        /// </summary>
        public Task<ValidationResultCollection> ValidateAsync()
        {
            if (GetReturnCode() != WechatPayConst.Success || GetResultCode() != WechatPayConst.Success)
                return Task.FromResult(new ValidationResultCollection(GetReturnMessage()));
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
            return SignManagerFactory.Create(_wechatPayConfig, Request, _builder).Verify(GetSign());
        }


    }
}
