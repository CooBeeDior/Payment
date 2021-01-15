 using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// �����ѱ�������
    /// </summary>
    [XmlRoot("xml")]
    public class WechatSendGroupRedPackResponse : WechatPayResponse
    {

        /// <summary>
        /// �̻�������
        /// �̻�ʹ�ò�ѯAPI��д���̻����ŵ�ԭ·����
        /// </summary>
        [XmlElement("mch_billno")]
        public virtual string MhBillNo { get; set; }

        /// <summary>
        /// ���ýӿ��ύ�Ĺ����˺�ID
        /// </summary>
        [XmlElement("wxappid")]
        public override string AppId { get; set; }

        /// <summary>
        /// �û�openid
        /// </summary>
        [XmlElement("re_openid")]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// �����ܽ���λ��
        /// </summary>
        [XmlElement("total_amount")]
        public virtual string TotalAmount { get; set; }

        /// <summary>
        /// ΢�ŵ���
        /// </summary>
        [XmlElement("send_listid")]
        public virtual string SendListId { get; set; }
    }
}

