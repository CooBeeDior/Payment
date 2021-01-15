using Newtonsoft.Json;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// ��ѯ�����¼����
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayHbInfoResponse : WechatPayResponse
    {

        /// <summary>
        /// �̻�������
        /// �̻�ʹ�ò�ѯAPI��д���̻����ŵ�ԭ·����
        /// </summary>
        [XmlElement("mch_billno")]
        public virtual string MhBillNo { get; set; }

        /// <summary>
        /// �������
        /// ʹ��API�����ֽ���ʱ���صĺ������
        /// </summary>
        [XmlElement("detail_id")]
        public virtual string DetailId { get; set; }

        /// <summary>
        /// ���״̬
        /// SENDING:������ 
        /// SENT:�ѷ��Ŵ���ȡ
        /// FAILED������ʧ��
        /// RECEIVED:����ȡ
        /// RFUND_ING:�˿���
        /// REFUND:���˿�
        /// </summary>
        [XmlElement("status")]
        public virtual string Status { get; set; }

        /// <summary>
        /// ��������
        /// API:ͨ��API�ӿڷ��� 
        /// UPLOAD:ͨ���ϴ��ļ���ʽ����
        /// ACTIVITY:ͨ�����ʽ����
        /// </summary>
        [XmlElement("send_type")]
        public virtual string SendType { get; set; }

        /// <summary>
        /// �������
        /// GROUP:�ѱ���   NORMAL:��ͨ���
        /// </summary>
        [XmlElement("hb_type")]
        public virtual string HbType { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [XmlElement("total_num")]
        public virtual int TotalNum { get; set; }

        /// <summary>
        /// ����ܽ���λ�֣�
        /// </summary>
        [XmlElement("total_amount")]
        public virtual int TotalAmount { get; set; }

        /// <summary>
        /// ʧ��ԭ��
        /// </summary>
        [XmlElement("reason")]
        public virtual string Reason { get; set; }

        /// <summary>
        /// �������ʱ��
        /// ���磺2015-04-21 20:00:00
        /// </summary>
        [XmlElement("send_time")]
        public virtual string SendTime { get; set; }

        /// <summary>
        /// ����˿�ʱ��
        /// ���磺2015-04-21 20:00:00
        /// </summary>
        [XmlElement("refund_time")]
        public virtual string RefundTime { get; set; }

        /// <summary>
        /// ����˿���
        /// </summary>
        [XmlElement("refund_amount")]
        public virtual int RefundAmount { get; set; }

        /// <summary>
        /// ף����
        /// </summary>
        [XmlElement("wishing")]
        public virtual string Wishing { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        [XmlElement("remark")]
        public virtual string Remark { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        [XmlElement("act_name")]
        public virtual string ActName { get; set; }

        /// <summary>
        /// �ѱ�������ȡ�б�
        /// <hblist>
        /// <hbinfo>
        /// <openid><![CDATA[oHkLxtzmyHXX6FW_cAWo_orTSRXs]]></openid>
        /// <amount>100</amount>
        /// <rcv_time><![CDATA[2016-08-08 21:49:46]]></rcv_time>
        /// </hbinfo>
        /// </hblist>
        /// </summary> 
        [XmlArray("hblist"), XmlArrayItem("hbinfo")]
        public virtual HbInfo[] HbList { get; set; }

      
    }
    [XmlRoot("hbinfo")]
    public class HbInfo
    {
        /// <summary>
        /// ��ȡ�����Openid
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }
        /// <summary>
        /// ��� ��λ��
        /// </summary>
        [XmlElement("amount")]
        public virtual int amount { get; set; }
        /// <summary>
        /// ��ȡ�����ʱ��
        /// </summary>
        [XmlElement("rcv_time")]
        public virtual string rcv_time { get; set; }
    }
}

