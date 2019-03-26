using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// �˿����ѯ
    /// </summary>
    [XmlRoot("xml")]
    public class WechatRefundQueryResponse : WechatpayResponse
    {
        /// <summary>
        /// �������˿����
        /// �����ܹ��ѷ����Ĳ����˿�������������������offset���з���
        /// </summary>
        [XmlElement("total_refund_count")]
        public virtual int TotalRefundCount { get; set; }

        /// <summary>
        /// ΢�Ŷ�����
        /// </summary>
        [XmlElement("transaction_id")]
        public virtual string TransactionId { get; set; }
        /// <summary>
        /// �̻�������
        /// </summary>
        [XmlElement("out_trade_no")]
        public virtual string OutTradeNo { get; set; }



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
        /// �˿����
        /// </summary>
        [XmlElement("refund_count")]
        public virtual int RefundCount { get; set; }


        /// <summary>
        /// �̻��˿��
        /// </summary>
        [XmlElement("out_refund_no")]
        public virtual string OutRefundNo { get; set; }
        /// <summary>
        /// �̻��˿��
        /// </summary>
        [XmlElement("out_refund_no_0")]
        public virtual string OutRefundNo0 { get; set; }
        /// <summary>
        /// �̻��˿��
        /// </summary>
        [XmlElement("out_refund_no_1")]
        public virtual string OutRefundNo1 { get; set; }
        /// <summary>
        /// �̻��˿��
        /// </summary>
        [XmlElement("out_refund_no_2")]
        public virtual string OutRefundNo2 { get; set; }

        /// <summary>
        /// ΢���˿��
        /// </summary>
        [XmlElement("refund_id")]
        public virtual string RefundId { get; set; }
        /// <summary>
        /// ΢���˿��
        /// </summary>
        [XmlElement("refund_id_0")]
        public virtual string RefundId0 { get; set; }
        /// <summary>
        /// ΢���˿��
        /// </summary>
        [XmlElement("refund_id_1")]
        public virtual string RefundId1 { get; set; }
        /// <summary>
        /// ΢���˿��
        /// </summary>
        [XmlElement("refund_id_2")]
        public virtual string RefundId2 { get; set; }

        /// <summary>
        /// �˿�����
        /// ORIGINAL��ԭ·�˿�
        /// BALANCE���˻ص����
        /// OTHER_BALANCE��ԭ�˻��쳣�˵���������˻�
        /// OTHER_BANKCARD��ԭ���п��쳣�˵��������п�
        /// </summary>
        [XmlElement("refund_channel")]
        public virtual string RefundChannel { get; set; }


        /// <summary>
        /// �˿�����
        /// ORIGINAL��ԭ·�˿�
        /// BALANCE���˻ص����
        /// OTHER_BALANCE��ԭ�˻��쳣�˵���������˻�
        /// OTHER_BANKCARD��ԭ���п��쳣�˵��������п�
        /// </summary>
        [XmlElement("refund_channel_0")]
        public virtual string RefundChannel0 { get; set; }
        /// <summary>
        /// �˿�����
        /// ORIGINAL��ԭ·�˿�
        /// BALANCE���˻ص����
        /// OTHER_BALANCE��ԭ�˻��쳣�˵���������˻�
        /// OTHER_BANKCARD��ԭ���п��쳣�˵��������п�
        /// </summary>
        [XmlElement("refund_channel_1")]
        public virtual string RefundChannel1 { get; set; }
        /// <summary>
        /// �˿�����
        /// ORIGINAL��ԭ·�˿�
        /// BALANCE���˻ص����
        /// OTHER_BALANCE��ԭ�˻��쳣�˵���������˻�
        /// OTHER_BANKCARD��ԭ���п��쳣�˵��������п�
        /// </summary>
        [XmlElement("refund_channel_2")]
        public virtual string RefundChannel2 { get; set; }

        /// <summary>
        /// �˿���
        /// �˿���=�����˿���-�ǳ�ֵ����ȯ�˿���˿���<=�����˿���
        /// </summary>
        [XmlElement("settlement_refund_fee")]
        public virtual string SettlementRefundFee { get; set; }
        /// <summary>
        /// �˿���
        /// �˿���=�����˿���-�ǳ�ֵ����ȯ�˿���˿���<=�����˿���
        /// </summary>
        [XmlElement("settlement_refund_fee_0")]
        public virtual string SettlementRefundFee0 { get; set; }
        /// <summary>
        /// �˿���
        /// �˿���=�����˿���-�ǳ�ֵ����ȯ�˿���˿���<=�����˿���
        /// </summary>
        [XmlElement("settlement_refund_fee_1")]
        public virtual string SettlementRefundFee1 { get; set; }
        /// <summary>
        /// �˿���
        /// �˿���=�����˿���-�ǳ�ֵ����ȯ�˿���˿���<=�����˿���
        /// </summary>
        [XmlElement("settlement_refund_fee_2")]
        public virtual string SettlementRefundFee2 { get; set; }

        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����$nΪ�±�,$mΪ�±�,��0��ʼ��ţ�������coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type")]
        public virtual string CouponType { get; set; }
        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����$nΪ�±�,$mΪ�±�,��0��ʼ��ţ�������coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_0_0")]
        public virtual string CouponType00 { get; set; }
        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����$nΪ�±�,$mΪ�±�,��0��ʼ��ţ�������coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_0_1")]
        public virtual string CouponType01 { get; set; }
        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����$nΪ�±�,$mΪ�±�,��0��ʼ��ţ�������coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_0_2")]
        public virtual string CouponType02 { get; set; }
        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����$nΪ�±�,$mΪ�±�,��0��ʼ��ţ�������coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_1_0")]
        public virtual string CouponType10 { get; set; }
        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����$nΪ�±�,$mΪ�±�,��0��ʼ��ţ�������coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_1_1")]
        public virtual string CouponType11 { get; set; }

        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����$nΪ�±�,$mΪ�±�,��0��ʼ��ţ�������coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_1_2")]
        public virtual string CouponType12 { get; set; }

        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����$nΪ�±�,$mΪ�±�,��0��ʼ��ţ�������coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_2_0")]
        public virtual string CouponType20 { get; set; }


        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����$nΪ�±�,$mΪ�±�,��0��ʼ��ţ�������coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_2_1")]
        public virtual string CouponType21 { get; set; }
        /// <summary>
        /// ����ȯ����
        /// CASH--��ֵ����ȯ 
        /// NO_CASH---�ǳ�ֵ�Ż�ȯ
        /// ��ͨ���ֵȯ���ܣ����Ҷ���ʹ�����Ż�ȯ���з��أ�ȡֵ��CASH��NO_CASH����$nΪ�±�,$mΪ�±�,��0��ʼ��ţ�������coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_2_2")]
        public virtual string CouponType22 { get; set; }

        /// <summary>
        /// �ܴ���ȯ�˿���
        /// ����ȯ�˿���<=�˿���˿���-����ȯ�������Ż��˿���Ϊ�ֽ�˵���������ȯ�������Ż�
        /// </summary>
        [XmlElement("coupon_refund_fee")]
        public virtual int CouponRefundFee { get; set; }


        /// <summary>
        /// �ܴ���ȯ�˿���
        /// ����ȯ�˿���<=�˿���˿���-����ȯ�������Ż��˿���Ϊ�ֽ�˵���������ȯ�������Ż�
        /// </summary>
        [XmlElement("coupon_refund_fee_0")]
        public virtual int CouponRefundFee0 { get; set; }

        /// <summary>
        /// �ܴ���ȯ�˿���
        /// ����ȯ�˿���<=�˿���˿���-����ȯ�������Ż��˿���Ϊ�ֽ�˵���������ȯ�������Ż�
        /// </summary>
        [XmlElement("coupon_refund_fee_1")]
        public virtual int CouponRefundFee1 { get; set; }

        /// <summary>
        /// �ܴ���ȯ�˿���
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
        /// �˿����ȯʹ������
        /// </summary>
        [XmlElement("coupon_refund_count_0")]
        public virtual int CouponRefundCount0 { get; set; }
        /// <summary>
        /// �˿����ȯʹ������
        /// </summary>
        [XmlElement("coupon_refund_count_1")]
        public virtual int CouponRefundCount1 { get; set; }
        /// <summary>
        /// �˿����ȯʹ������
        /// </summary>
        [XmlElement("coupon_refund_count_2")]
        public virtual int CouponRefundCount2 { get; set; }

        /// <summary>
        /// �˿����ȯID
        /// </summary>
        [XmlElement("coupon_refund_id")]
        public virtual string CouponRefundId { get; set; }

        [XmlElement("coupon_refund_id_0_0")]
        public virtual string CouponRefundId00 { get; set; }

        /// <summary>
        /// ��������ȯ�˿���
        /// </summary>
        [XmlElement("coupon_refund_fee_0_0")]
        public virtual string CouponRefundFee00 { get; set; }

        /// <summary>     
        /// �˿�״̬��
        /// UCCESS���˿�ɹ�
        /// REFUNDCLOSE���˿�رա�
        /// PROCESSING���˿����
        /// CHANGE���˿��쳣���˿���з����û��Ŀ����ϻ��߶����ˣ�����ԭ·�˿����п�ʧ�ܣ���ǰ���̻�ƽ̨��pay.weixin.qq.com��-�������ģ��ֶ�����˱��˿$nΪ�±꣬��0��ʼ��š�
        /// </summary>
        [XmlElement("refund_status")]
        public virtual string RefundStatus { get; set; }
        /// <summary>     
        /// �˿�״̬��
        /// UCCESS���˿�ɹ�
        /// REFUNDCLOSE���˿�رա�
        /// PROCESSING���˿����
        /// CHANGE���˿��쳣���˿���з����û��Ŀ����ϻ��߶����ˣ�����ԭ·�˿����п�ʧ�ܣ���ǰ���̻�ƽ̨��pay.weixin.qq.com��-�������ģ��ֶ�����˱��˿$nΪ�±꣬��0��ʼ��š�
        /// </summary>
        [XmlElement("refund_status_0")]
        public virtual string RefundStatus0 { get; set; }

        /// <summary>
        /// �˿��ʽ���Դ
        /// REFUND_SOURCE_RECHARGE_FUNDS---��������˿�/�����˻�
        /// REFUND_SOURCE_UNSETTLED_FUNDS---δ�����ʽ��˿�
        /// $nΪ�±꣬��0��ʼ��š�
        /// </summary>
        [XmlElement("refund_account")]
        public virtual string RefundAccount { get; set; }
        /// <summary>
        /// �˿��ʽ���Դ
        /// REFUND_SOURCE_RECHARGE_FUNDS---��������˿�/�����˻�
        /// REFUND_SOURCE_UNSETTLED_FUNDS---δ�����ʽ��˿�
        /// $nΪ�±꣬��0��ʼ��š�
        /// </summary>
        [XmlElement("refund_account_0")]
        public virtual string RefundAccount0 { get; set; }

        /// <summary>
        /// �˿������˻�
        /// ȡ��ǰ�˿���˿����˷�
        /// 1���˻����п���{�������� }{������}{��β��}
        /// 2���˻�֧���û���Ǯ:֧���û���Ǯ
        /// 3���˻��̻�:�̻������˻� �̻����������˻�
        /// 4���˻�֧���û���Ǯͨ:֧���û���Ǯͨ
        /// </summary>
        [XmlElement("refund_recv_accout")]
        public virtual string RefundRecvAccout { get; set; }
        /// <summary>
        /// �˿������˻�
        /// ȡ��ǰ�˿���˿����˷�
        /// 1���˻����п���{�������� }{������}{��β��}
        /// 2���˻�֧���û���Ǯ:֧���û���Ǯ
        /// 3���˻��̻�:�̻������˻� �̻����������˻�
        /// 4���˻�֧���û���Ǯͨ:֧���û���Ǯͨ
        /// </summary>
        [XmlElement("refund_recv_accout_0")]
        public virtual string RefundRecvAccout0 { get; set; }
        /// <summary>
        /// �˿�ɹ�ʱ��
        /// </summary>
        [XmlElement("refund_success_time")]
        public virtual string RefundSuccessTime { get; set; }

        /// <summary>
        /// �˿�ɹ�ʱ��
        /// </summary>
        [XmlElement("refund_success_time_0")]
        public virtual string RefundSuccessTime0 { get; set; }



    }
}


