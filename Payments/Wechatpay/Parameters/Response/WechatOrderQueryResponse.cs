using Newtonsoft.Json;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// ������ѯ����
    /// </summary>
    [XmlRoot("xml")]
    public class WechatOrderQueryResponse : WechatPayResponse
    {
        /// <summary>
        /// ΢��֧��������ն��豸��
        /// </summary>
        [XmlElement("device_info")]
        public virtual string DeviceInfo { get; set; }

        /// <summary>
        /// �û����̻�appid�µ�Ψһ��ʶ
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// �Ƿ��ע�����˺�
        /// �û��Ƿ��ע�����˺ţ�Y-��ע��N-δ��ע
        /// </summary>
        [XmlElement("is_subscribe")]
        public virtual string IsSubscribe { get; set; }

        /// <summary>
        /// ���ýӿ��ύ�Ľ������ͣ�
        /// ȡֵ���£�JSAPI��NATIVE��APP��MICROPAY����ϸ˵���������涨
        /// </summary>
        [XmlElement("trade_type")]
        public virtual string TradeType { get; set; }
        /// <summary>
        /// ����״̬
        /// SUCCESS��֧���ɹ�
        /// REFUND��ת���˿�
        /// NOTPAY��δ֧��
        /// CLOSED���ѹر�
        /// REVOKED���ѳ�����������֧����
        /// USERPAYING--�û�֧���У�������֧����
        /// PAYERROR--֧��ʧ��(����ԭ�������з���ʧ��)
        /// ֧��״̬������µ�APIҳ��
        /// </summary>
        [XmlElement("trade_state")]
        public virtual string TradeState { get; set; }

        /// <summary>
        /// ��������
        /// �������ͣ������ַ������͵����б�ʶ
        /// </summary>
        [XmlElement("bank_type")]
        public virtual string BankType { get; set; }

        /// <summary>
        /// ��۽�� 	�����ܽ���λΪ��
        /// </summary>
        [XmlElement("total_fee")]
        public virtual int TotalFee { get; set; }

        /// <summary>
        /// Ӧ�ᶩ�����
        /// ������ʹ�������ֵ���Ż�ȯ�󷵻ظò�����Ӧ�ᶩ�����=�������-���ֵ�Ż�ȯ��
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public virtual int SettlementTotalFee { get; set; }
        /// <summary>
        /// ��۱���
        /// �������ͣ�����ISO 4217��׼����λ��ĸ���룬Ĭ������ң�CNY������ֵ�б������������
        /// </summary>
        [XmlElement("fee_type")]
        public virtual string FeeType { get; set; }

        /// <summary>
        /// �ֽ�֧����� 	
        /// �ֽ�֧�������ֽ�֧�������֧�����
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
        /// ����ȯʹ������        
        /// </summary>
        [XmlElement("coupon_count")]
        public virtual int CouponCount { get; set; }

        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����nΪ�±�,��0��ʼ��ţ�������coupon_type_0
        /// </summary>
        [XmlElement("coupon_type")]
        public virtual string CouponType { get; set; }
        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����nΪ�±�,��0��ʼ��ţ�������coupon_type_0
        /// </summary>
        [XmlElement("coupon_type_0")]
        public virtual string CouponType0{ get; set; }
        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����nΪ�±�,��0��ʼ��ţ�������coupon_type_0
        /// </summary>
        [XmlElement("coupon_type_1")]
        public virtual string CouponType1 { get; set; }
        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����nΪ�±�,��0��ʼ��ţ�������coupon_type_0
        /// </summary>
        [XmlElement("coupon_type_2")]
        public virtual string CouponType2 { get; set; }

        /// <summary>
        /// ����ȯID
        /// ��������ȯ֧�����, nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_id")]
        public virtual int CouponId { get; set; }

        /// <summary>
        /// ����ȯID
        /// ��������ȯ֧�����, nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_id_0")]
        public virtual int CouponId0 { get; set; }

        /// <summary>
        /// ����ȯID
        /// ��������ȯ֧�����, nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_id_1")]
        public virtual int CouponId1 { get; set; }

        /// <summary>
        /// ����ȯID
        /// ��������ȯ֧�����, nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_id_2")]
        public virtual int CouponId2 { get; set; }
       
        /// <summary>
        /// ��������ȯ֧�����
        /// ��������ȯ֧�����, nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_fee")]
        public virtual int CouponFee { get; set; }
        /// <summary>
        /// ��������ȯ֧�����
        /// ��������ȯ֧�����, nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_fee_0")]
        public virtual int CouponFee0 { get; set; }
        /// <summary>
        /// ��������ȯ֧�����
        /// ��������ȯ֧�����, nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_fee_1")]
        public virtual int CouponFee1 { get; set; }
        /// <summary>
        /// ��������ȯ֧�����
        /// ��������ȯ֧�����, nΪ�±꣬��0��ʼ���
        /// </summary>
        [XmlElement("coupon_fee_2")]
        public virtual int CouponFee2 { get; set; }

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
        /// ����֧��ʱ�䣬��ʽΪyyyyMMddHHmmss����2009��12��25��9��10��10���ʾΪ20091225091010���������ʱ�����
        /// </summary>
        [XmlElement("time_end")]
        public virtual string TimeEnd { get; set; }
        /// <summary>
        /// ����״̬����
        /// �Ե�ǰ��ѯ����״̬����������һ��������ָ��
        /// </summary>
        [XmlElement("trade_state_desc")]
        public virtual string Trade_StateDesc { get; set; }
 
    }
}

