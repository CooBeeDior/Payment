using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AliPay.Parameters.Response.Base
{
    /// <summary>
    /// 支付宝支付返回
    /// </summary>
    public class AliPayResponse
    {
        /// <summary>
        /// 网关返回码,详见文档
        /// https://opendocs.alipay.com/open/common/105806
        /// </summary>
        [JsonProperty("code")]
        [XmlElement("code")]
        public virtual string Code { get; set; }
        /// <summary>
        /// 网关返回码描述,详见文档
        /// https://opendocs.alipay.com/open/common/105806
        /// </summary>
        [JsonProperty("msg")]
        [XmlElement("msg")]
        public virtual string Msg { get; set; }
        /// <summary>
        /// 业务返回码，参见具体的API接口文档
        /// </summary>
        [JsonProperty("sub_code")]
        [XmlElement("sub_code")]
        public virtual string SubCode { get; set; }
        /// <summary>
        /// 业务返回码描述，参见具体的API接口文档
        /// </summary>
        [JsonProperty("sub_msg")]
        [XmlElement("sub_msg")]
        public virtual string SubMsg { get; set; }
 
    }
}
