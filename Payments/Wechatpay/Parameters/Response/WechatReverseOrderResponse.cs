 using Newtonsoft.Json;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// 撤销订单服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatReverseOrderResponse : WechatPayResponse
    {
        /// <summary>
        /// 是否重调
        /// 是否需要继续调用撤销，Y-需要，N-不需要
        /// </summary>
        [XmlElement("recall")]
        public virtual string Recall { get; set; }

        
    }
}

