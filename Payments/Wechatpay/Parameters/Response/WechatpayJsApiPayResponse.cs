 using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// 微信JsAPi支付
    /// </summary>
    [XmlRoot("xml")]
    public class WechatpayJsApiPayResponse : WechatpayPayResponseBase
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }
    }
}

