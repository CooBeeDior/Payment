using AliPay.Configs;
using AliPay.Parameters.Response.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Payments.Extensions;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Util.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliPay.Results
{



    /// <summary>
    /// 微信支付结果
    /// </summary>
    public class AlipayResult<TAliPayResponse> where TAliPayResponse : AliPayResponse
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
        private readonly AliPayConfig _aliPayConfig;

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
                return GetResultCode() == "10000";
            }
        }

        public HttpRequest Request { get; }

        public AliPayResponseBase<TAliPayResponse> Data { get; set; }
        /// <summary>
        /// 初始化微信支付结果
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        /// <param name="response">xml响应消息</param>
        public AlipayResult(AliPayConfig aliPayConfig, string response, HttpRequest httpRequest = null)
        {
            aliPayConfig.CheckNull(nameof(aliPayConfig));
            _aliPayConfig = aliPayConfig;
            Raw = response;
            Resolve(response);
            Request = httpRequest;
        }
        public AlipayResult()
        {
        }

        /// <summary>
        /// 解析响应
        /// </summary>
        protected virtual void Resolve(string response)
        {
            Data = JsonConvert.DeserializeObject<AliPayResponseBase<TAliPayResponse>>(response);
        } 

        /// <summary>
        /// 获取返回状态码
        /// </summary>
        public string GetReturnCode()
        {
            return Data?.Data?.Code;
        }

        /// <summary>
        /// 获取业务结果代码
        /// </summary>
        public string GetResultCode()
        {
            return Data?.Data?.Code;
        }

        /// <summary>
        /// 获取返回消息
        /// </summary>
        public string GetReturnMessage()
        {
            return Data?.Data?.Msg;
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
            builder.Add(AliPayConst.Sign, _sign);
            return builder.GetDictionary().ToDictionary(t => t.Key, t => t.Value.SafeString());
        }

        /// <summary>
        /// 验证
        /// </summary>
        public Task<ValidationResultCollection> ValidateAsync()
        {
            if (GetReturnCode() != "10000" || GetResultCode() != "10000")
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
            return SignManagerFactory.Create(_aliPayConfig, Request, _builder).Verify(GetSign());
        }


    }








    /// <summary>
    /// 支付宝结果
    /// </summary>
    public class AlipayResult
    {
        /// <summary>
        /// 结果
        /// </summary>
        private readonly IDictionary<string, string> _result;

        /// <summary>
        /// 初始化支付宝结果
        /// </summary>
        /// <param name="response">json响应消息</param>
        public AlipayResult(string response)
        {
            Raw = response;
            _result = new Dictionary<string, string>();
            LoadJson(response);
        }

        /// <summary>
        /// 支付宝原始响应
        /// </summary>
        public string Raw { get; }

        /// <summary>
        /// 加载json
        /// </summary>
        private void LoadJson(string json)
        {
            if (json.IsEmpty())
                return;
            var jObject = JObject.Parse(json);
            foreach (var token in jObject.Children())
                AddNodes(token);
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        private void AddNodes(JToken token)
        {
            if (!(token is JProperty item))
                return;
            foreach (var value in item.Value)
                AddNodes(value);
            if (GetIgnoreItems().Contains(item.Name))
                return;
            _result.Add(item.Name, item.Value.SafeString());
        }

        /// <summary>
        /// 获取忽略项
        /// </summary>
        private List<string> GetIgnoreItems()
        {
            return new List<string> {
                "alipay_trade_pay_response"
            };
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        public IDictionary<string, string> GetDictionary()
        {
            return _result;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">键</param>
        public string GetValue(string key)
        {
            if (key.IsEmpty())
                return string.Empty;
            return _result.ContainsKey(key) ? _result[key].SafeString() : string.Empty;
        }

        /// <summary>
        /// 是否包含指定键
        /// </summary>
        /// <param name="key">键</param>
        public bool HasKey(string key)
        {
            if (key.IsEmpty())
                return false;
            return _result.ContainsKey(key);
        }

        /// <summary>
        /// 获取状态码
        /// </summary>
        public string GetCode()
        {
            return GetValue("code");
        }

        /// <summary>
        /// 获取消息
        /// </summary>
        public string GetMessage()
        {
            return GetValue("msg");
        }

        /// <summary>
        /// 获取支付订单号
        /// </summary>
        public string GetTradeNo()
        {
            return GetValue(AlipayConst.TradeNo);
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success => GetCode() == "10000";
    }
}
