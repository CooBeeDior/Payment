 using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// ������������
    /// </summary>
    [XmlRoot("xml")]
    public class WechatReverseOrderResponse : WechatpayResponse
    {
        /// <summary>
        /// �Ƿ��ص�
        /// �Ƿ���Ҫ�������ó�����Y-��Ҫ��N-����Ҫ
        /// </summary>
        [XmlElement("recall")]
        public virtual string Recall { get; set; }

        
    }
}

