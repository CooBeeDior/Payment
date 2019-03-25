using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// 统一下单
    /// </summary>
    public class WechatpayNativePayResponse : WechatpayResponse
    {
        /// <summary>
        /// 调用接口提交的公众账号ID
        /// </summary>
        [JsonProperty("appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 调用接口提交的商户号
        /// </summary>
        [JsonProperty("mch_id")]
        public string MchId { get; set; }

        /// <summary>
        /// 自定义参数，可以为请求支付的终端设备号等
        /// </summary>
        [JsonProperty("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 微信返回的随机字符串
        /// </summary>
        [JsonProperty("nonce_str")]
        public string Nonce_Str { get; set; }

        /// <summary>
        /// 微信返回的签名值
        /// </summary>
        [JsonProperty("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonProperty("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 当result_code为FAIL时返回错误描述，详细参见下文错误列表
        /// </summary>
        [JsonProperty("err_code_des")]
        public string ErrCodeDes { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        [JsonProperty("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        /// 微信生成的预支付会话标识，用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        [JsonProperty("prepay_id")]
        public string PrepayId { get; set; }

        /// <summary>
        /// trade_type=NATIVE时有返回，此url用于生成支付二维码，然后提供给用户进行扫码支付。
        /// 注意：code_url的值并非固定，使用时按照URL格式转成二维码即可
        /// </summary>
        [JsonProperty("code_url")]
        public string CodeUrl { get; set; }
   

    }
}
