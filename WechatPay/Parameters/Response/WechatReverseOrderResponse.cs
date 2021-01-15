 using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// ������������
    /// </summary>
    [XmlRoot("xml")]
    public class WechatReverseOrderResponse : WechatPayResponse
    {
        /// <summary>
        /// �Ƿ��ص�
        /// �Ƿ���Ҫ�������ó�����Y-��Ҫ��N-����Ҫ
        /// </summary>
        [XmlElement("recall")]
        public virtual string Recall { get; set; }

        
    }
}

