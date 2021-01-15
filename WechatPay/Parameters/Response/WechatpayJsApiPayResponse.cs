 using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// ΢��JsAPi֧��
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayJsApiPayResponse : WechatPayPayResponseBase
    {
        /// <summary>
        /// �û���ʶ
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }
    }
}

