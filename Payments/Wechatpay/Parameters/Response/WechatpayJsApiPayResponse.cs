 using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// ΢��JsAPi֧��
    /// </summary>
    [XmlRoot("xml")]
    public class WechatpayJsApiPayResponse : WechatpayPayResponseBase
    {
        /// <summary>
        /// �û���ʶ
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }
    }
}

