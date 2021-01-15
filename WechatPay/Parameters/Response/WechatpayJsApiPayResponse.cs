 using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 微信JsAPi支付
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayJsApiPayResponse : WechatPayPayResponseBase
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }
    }
}

