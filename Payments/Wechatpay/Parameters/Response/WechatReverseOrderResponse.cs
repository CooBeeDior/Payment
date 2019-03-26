 using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// 撤销订单服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatReverseOrderResponse : WechatpayResponse
    {
        /// <summary>
        /// 是否重调
        /// 是否需要继续调用撤销，Y-需要，N-不需要
        /// </summary>
        [XmlElement("recall")]
        public virtual string Recall { get; set; }

        
    }
}

