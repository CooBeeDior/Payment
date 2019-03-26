 using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// ��ҵת�˷���
    /// </summary>
    [XmlRoot("xml")]
    public class WechatTransfersResponse : WechatpayResponse
    {
        /// <summary>
        /// �̻������ţ��豣����ʷȫ��Ψһ��(ֻ������ĸ�������֣����ܰ����������ַ�)
        /// </summary>
        [XmlElement("partner_trade_no")]
        public virtual string PartnerTradeNo { get; set; }

        /// <summary>
        /// ΢�Ÿ����
        /// ��ҵ����ɹ������ص�΢�Ÿ����
        /// </summary>
        [XmlElement("payment_no")]
        public virtual string PaymentNo { get; set; }

        /// <summary>
        /// ����ɹ�ʱ��
        /// </summary>
        [XmlElement("payment_time")]
        public virtual string PaymenTime { get; set; }

    }
}

