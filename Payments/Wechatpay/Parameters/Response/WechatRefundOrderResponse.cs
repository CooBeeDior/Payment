 using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// 订单退款服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatRefundOrderResponse : WechatpayResponse
    {
        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public virtual string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public virtual string OutTradeNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [XmlElement("refund_id")]
        public virtual string RefundId { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [XmlElement("out_refund_no")]
        public virtual string OutRefundNo { get; set; }

        /// <summary>
        /// 退款总金额,单位为分
        /// </summary>
        [XmlElement("refund_fee")]
        public virtual int RefundFee { get; set; }

        /// <summary>
        /// 退款金额
        /// 退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        [XmlElement("settlement_refund_fee")]
        public virtual int SettlementRefundFee { get; set; }

        /// <summary>      
        /// 订单总金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        [XmlElement("total_fee")]
        public virtual int TotalFee { get; set; }

        /// <summary>
        /// 应结订单金额
        /// 应结订单金额
        /// 当该订单有使用非充值券时，返回此字段。应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public virtual int SettlementTotalFee { get; set; }

        /// <summary>
        /// 标价币种
        /// 订单金额货币类型，符合ISO 4217标准的三位字母代码，
        /// 默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("fee_type")]
        public virtual string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// 现金支付金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        [XmlElement("cash_fee")]
        public virtual int CashFee { get; set; }

        /// <summary>
        /// 现金支付币种
        /// 货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("cash_fee_type")]
        public virtual string CashFeeType { get; set; }

        /// <summary>
        /// 现金退款金额
        /// 现金退款金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        [XmlElement("cash_refund_fee")]
        public virtual int CashRefundFee { get; set; }
        /// <summary>
        /// 代金券退款总金额
        /// 代金券退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见代金券或立减优惠
        /// </summary>
        [XmlElement("coupon_refund_fee")]
        public virtual int CouponRefundFee { get; set; }

        /// <summary>
        /// 单个代金券退款金额
        /// 代金券退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见代金券或立减优惠
        /// </summary>
        [XmlElement("coupon_refund_fee_0")]
        public virtual int CouponRefundFee0 { get; set; }
        /// <summary>
        /// 单个代金券退款金额
        /// 代金券退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见代金券或立减优惠
        /// </summary>
        [XmlElement("coupon_refund_fee_1")]
        public virtual int CouponRefundFee1 { get; set; }
        /// <summary>
        /// 单个代金券退款金额
        /// 代金券退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见代金券或立减优惠
        /// </summary>
        [XmlElement("coupon_refund_fee_2")]
        public virtual int CouponRefundFee2 { get; set; }

        /// <summary>
        /// 退款代金券使用数量
        /// </summary>
        [XmlElement("coupon_refund_count")]
        public virtual int CouponRefundCount { get; set; }
        /// <summary>
        /// 退款代金券ID
        /// 退款代金券ID, $n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_refund_id")]
        public virtual int CouponRefundId { get; set; }
        /// <summary>
        /// 退款代金券ID
        /// 退款代金券ID, $n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_refund_id_0")]
        public virtual int CouponRefundId0 { get; set; }
        /// <summary>
        /// 退款代金券ID
        /// 退款代金券ID, $n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_refund_id_1")]
        public virtual int CouponRefundId1 { get; set; }
        /// <summary>
        /// 退款代金券ID
        /// 退款代金券ID, $n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_refund_id_2")]
        public virtual int CouponRefundId2 { get; set; }


    }
}

