 using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// �����˿����
    /// </summary>
    [XmlRoot("xml")]
    public class WechatRefundOrderResponse : WechatpayResponse
    {
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
        /// ΢���˿��
        /// </summary>
        [XmlElement("refund_id")]
        public virtual string RefundId { get; set; }

        /// <summary>
        /// �̻��˿��
        /// </summary>
        [XmlElement("out_refund_no")]
        public virtual string OutRefundNo { get; set; }

        /// <summary>
        /// �˿��ܽ��,��λΪ��
        /// </summary>
        [XmlElement("refund_fee")]
        public virtual int RefundFee { get; set; }

        /// <summary>
        /// �˿���
        /// �˿���=�����˿���-�ǳ�ֵ����ȯ�˿���˿���<=�����˿���
        /// </summary>
        [XmlElement("settlement_refund_fee")]
        public virtual int SettlementRefundFee { get; set; }

        /// <summary>      
        /// �����ܽ���λΪ�֣�ֻ��Ϊ���������֧�����
        /// </summary>
        [XmlElement("total_fee")]
        public virtual int TotalFee { get; set; }

        /// <summary>
        /// Ӧ�ᶩ�����
        /// Ӧ�ᶩ�����
        /// ���ö�����ʹ�÷ǳ�ֵȯʱ�����ش��ֶΡ�Ӧ�ᶩ�����=�������-�ǳ�ֵ����ȯ��Ӧ�ᶩ�����<=������
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public virtual int SettlementTotalFee { get; set; }

        /// <summary>
        /// ��۱���
        /// �������������ͣ�����ISO 4217��׼����λ��ĸ���룬
        /// Ĭ������ң�CNY������ֵ�б������������
        /// </summary>
        [XmlElement("fee_type")]
        public virtual string FeeType { get; set; }

        /// <summary>
        /// �ֽ�֧�����
        /// �ֽ�֧������λΪ�֣�ֻ��Ϊ���������֧�����
        /// </summary>
        [XmlElement("cash_fee")]
        public virtual int CashFee { get; set; }

        /// <summary>
        /// �ֽ�֧������
        /// �������ͣ�����ISO 4217��׼����λ��ĸ���룬Ĭ������ң�CNY������ֵ�б������������
        /// </summary>
        [XmlElement("cash_fee_type")]
        public virtual string CashFeeType { get; set; }

        /// <summary>
        /// �ֽ��˿���
        /// �ֽ��˿����λΪ�֣�ֻ��Ϊ���������֧�����
        /// </summary>
        [XmlElement("cash_refund_fee")]
        public virtual int CashRefundFee { get; set; }
        /// <summary>
        /// ����ȯ�˿��ܽ��
        /// ����ȯ�˿���<=�˿���˿���-����ȯ�������Ż��˿���Ϊ�ֽ�˵���������ȯ�������Ż�
        /// </summary>
        [XmlElement("coupon_refund_fee")]
        public virtual int CouponRefundFee { get; set; }

        /// <summary>
        /// ��������ȯ�˿���
        /// ����ȯ�˿���<=�˿���˿���-����ȯ�������Ż��˿���Ϊ�ֽ�˵���������ȯ�������Ż�
        /// </summary>
        [XmlElement("coupon_refund_fee_0")]
        public virtual int CouponRefundFee0 { get; set; }
        /// <summary>
        /// ��������ȯ�˿���
        /// ����ȯ�˿���<=�˿���˿���-����ȯ�������Ż��˿���Ϊ�ֽ�˵���������ȯ�������Ż�
        /// </summary>
        [XmlElement("coupon_refund_fee_1")]
        public virtual int CouponRefundFee1 { get; set; }
        /// <summary>
        /// ��������ȯ�˿���
        /// ����ȯ�˿���<=�˿���˿���-����ȯ�������Ż��˿���Ϊ�ֽ�˵���������ȯ�������Ż�
        /// </summary>
        [XmlElement("coupon_refund_fee_2")]
        public virtual int CouponRefundFee2 { get; set; }

        /// <summary>
        /// �˿����ȯʹ������
        /// </summary>
        [XmlElement("coupon_refund_count")]
        public virtual int CouponRefundCount { get; set; }
        /// <summary>
        /// �˿����ȯID
        /// �˿����ȯID, $nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_refund_id")]
        public virtual int CouponRefundId { get; set; }
        /// <summary>
        /// �˿����ȯID
        /// �˿����ȯID, $nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_refund_id_0")]
        public virtual int CouponRefundId0 { get; set; }
        /// <summary>
        /// �˿����ȯID
        /// �˿����ȯID, $nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_refund_id_1")]
        public virtual int CouponRefundId1 { get; set; }
        /// <summary>
        /// �˿����ȯID
        /// �˿����ȯID, $nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_refund_id_2")]
        public virtual int CouponRefundId2 { get; set; }


    }
}

