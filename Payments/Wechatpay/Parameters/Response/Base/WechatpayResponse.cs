using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Payments.Wechatpay.Parameters.Response.Base
{
    /// <summary>
    /// 返回值
    /// </summary>
    [XmlRoot("xml")]
    public class WechatpayResponse
    {
        /// <summary>
        /// SUCCESS/FAIL
        /// 此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// </summary>
        [XmlElement("return_code")]
        public virtual string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息，如非空，为错误原因     
        /// 签名失败       
        /// 参数格式校验错误
        /// </summary>
        [XmlElement("return_msg")]
        public virtual string ReturnMsg { get; set; }

        /// <summary>
        /// 业务结果 SUCCESS/FAIL
        /// </summary>
        [XmlElement("result_code")]
        public virtual string ResultCode { get; set; }
    }
}
