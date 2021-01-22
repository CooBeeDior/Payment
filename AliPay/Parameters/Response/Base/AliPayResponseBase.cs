using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AliPay.Parameters.Response.Base
{
    public class AliPayResponseBase<TAliPayResponse> where TAliPayResponse : AliPayResponse
    {
        /// <summary>
        /// 密钥验签
        /// https://opendocs.alipay.com/open/291/106074
        /// </summary>
        [JsonProperty("sign")]
        [XmlElement("sign")]
        public virtual string Sign { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public virtual TAliPayResponse Data { get; set; }
    }
}
