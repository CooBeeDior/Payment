 using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// ��ѯ��ҵ�������
    /// </summary>
    [XmlRoot("xml")]
    public class WechatGetTransferInfoResponse : WechatPayResponse
    {
        /// <summary>
        /// �̻�ʹ�ò�ѯAPI��д�ĵ��ŵ�ԭ·����. 
        /// </summary>
        [XmlElement("partner_trade_no")]
        public virtual string PartnerTradeNo { get; set; }

        /// <summary>
        /// ������ҵ����APIʱ��΢��ϵͳ�ڲ������ĵ���
        /// </summary>
        [XmlElement("detail_id")]
        public virtual string DetailId { get; set; }

        /// <summary>
        /// ת��״̬
        /// SUCCESS:ת�˳ɹ�
        /// FAILED:ת��ʧ��
        /// PROCESSING:������
        /// </summary>
        [XmlElement("status")]
        public virtual string Status { get; set; }

        /// <summary>
        /// ʧ��ԭ��
        /// </summary>
        [XmlElement("reason")]
        public virtual string Reason { get; set; }

        /// <summary>
        /// �տ��û�openid
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// �տ��û�����
        /// </summary>
        [XmlElement("transfer_name")]
        public virtual string TransferName { get; set; }

        /// <summary>
        /// ������ �����λ�֣�
        /// </summary>
        [XmlElement("payment_amount")]
        public virtual int PaymentAmount { get; set; }

        /// <summary>
        /// ����ת�˵�ʱ��
        /// </summary>
        [XmlElement("transfer_time")]
        public virtual string TransferTime { get; set; }

        /// <summary>
        /// ��ҵ����ɹ�ʱ��
        /// </summary>
        [XmlElement("payment_time")]
        public virtual string PaymentTime { get; set; }

        /// <summary>
        /// ��ҵ���ע
        /// </summary>
        [XmlElement("desc")]
        public virtual string Desc { get; set; }
       

    }
}

