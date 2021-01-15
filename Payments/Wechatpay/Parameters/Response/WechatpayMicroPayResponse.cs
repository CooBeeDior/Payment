 using Newtonsoft.Json;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// �ύ������֧��
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayMicroPayResponse : WechatPayPayResponseBase
    {
        /// <summary>
        /// �û���ʶ
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }
        /// <summary>
        /// �Ƿ��ע�����˺�
        /// �û��Ƿ��ע�����˺ţ����ڹ����˺�����֧����Ч��ȡֵ��Χ��Y��N;Y-��ע;N-δ��ע
        /// </summary>
        [XmlElement("is_subscribe")]
        public virtual string IsSubscribe { get; set; }

        /// <summary>
        /// ��������
        /// �������ͣ������ַ������͵����б�ʶ�������������
        /// </summary>
        [XmlElement("bank_type")]
        public virtual string BankType { get; set; }
        /// <summary>
        /// ��������
        /// ����ISO 4217��׼����λ��ĸ���룬Ĭ������ң�CNY�������������
        /// </summary>
        [XmlElement("fee_type")]
        public virtual string FeeType { get; set; }

        /// <summary>
        /// �������
        /// �����ܽ���λΪ�֣�ֻ��Ϊ���������֧�����
        /// </summary>
        [XmlElement("TotalFee")]
        public virtual int TotalFee { get; set; }

        /// <summary>
        /// Ӧ�ᶩ�����
        /// ������ʹ�������ֵ���Ż�ȯ�󷵻ظò�����Ӧ�ᶩ�����=�������-���ֵ�Ż�ȯ��
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public virtual int SettlementTotalFee { get; set; }

        /// <summary>
        /// ����ȯ���
        /// ������ȯ�����<=�������������-������ȯ�����=�ֽ�֧�������֧�����
        /// </summary>
        [XmlElement("coupon_fee")]
        public virtual int CouponFee { get; set; }

        /// <summary>
        /// �ֽ�֧����������
        /// ����ISO 4217��׼����λ��ĸ���룬Ĭ������ң�CNY������ֵ�б������������
        /// </summary>
        [XmlElement("cash_fee_type")]
        public virtual string CashFeeType { get; set; }

        /// <summary>
        /// �ֽ�֧�����
        /// </summary>
        [XmlElement("cash_fee")]
        public virtual int CashFee { get; set; }

        /// <summary>
        /// ΢��֧��������
        /// </summary>
        [XmlElement("transaction_id")]
        public virtual string TransactionId { get; set; }

        /// <summary>
        /// �̻�������
        /// </summary>
        [XmlElement("out_trade_no")]
        public virtual string OutTradeNo { get; set; }

        /// <summary>
        /// ֧�����ʱ��
        /// ��������ʱ�䣬��ʽΪyyyyMMddHHmmss����2009��12��25��9��10��10���ʾΪ20091225091010�����ʱ�����
        /// </summary>
        [XmlElement("time_end")]
        public virtual string TimeEnd { get; set; }

        /// <summary>
        /// Ӫ������
        /// </summary>
        [XmlElement("promotion_detail")]
        public virtual string PromotionDetail { get; set; }

    }
}

