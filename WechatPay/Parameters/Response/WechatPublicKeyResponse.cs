using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// RSA加密公钥API
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPublicKeyResponse: WechatPayPayResponseBase
    {
        /// <summary>
        /// RSA 公钥
        /// </summary>
        [XmlElement("pub_key")]
        public virtual string PubKey { get; set; }
    }
}
