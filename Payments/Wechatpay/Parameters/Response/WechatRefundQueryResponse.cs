using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// 退款订单查询
    /// </summary>
    [XmlRoot("xml")]
    public class WechatRefundQueryResponse : WechatpayResponse
    {
        /// <summary>
        /// 订单总退款次数
        /// 订单总共已发生的部分退款次数，当请求参数传入offset后有返回
        /// </summary>
        [XmlElement("total_refund_count")]
        public virtual int TotalRefundCount { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public virtual string TransactionId { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public virtual string OutTradeNo { get; set; }



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
        /// 退款笔数
        /// </summary>
        [XmlElement("refund_count")]
        public virtual int RefundCount { get; set; }


        /// <summary>
        /// 商户退款单号
        /// </summary>
        [XmlElement("out_refund_no")]
        public virtual string OutRefundNo { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        [XmlElement("out_refund_no_0")]
        public virtual string OutRefundNo0 { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        [XmlElement("out_refund_no_1")]
        public virtual string OutRefundNo1 { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        [XmlElement("out_refund_no_2")]
        public virtual string OutRefundNo2 { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [XmlElement("refund_id")]
        public virtual string RefundId { get; set; }
        /// <summary>
        /// 微信退款单号
        /// </summary>
        [XmlElement("refund_id_0")]
        public virtual string RefundId0 { get; set; }
        /// <summary>
        /// 微信退款单号
        /// </summary>
        [XmlElement("refund_id_1")]
        public virtual string RefundId1 { get; set; }
        /// <summary>
        /// 微信退款单号
        /// </summary>
        [XmlElement("refund_id_2")]
        public virtual string RefundId2 { get; set; }

        /// <summary>
        /// 退款渠道
        /// ORIGINAL—原路退款
        /// BALANCE—退回到余额
        /// OTHER_BALANCE—原账户异常退到其他余额账户
        /// OTHER_BANKCARD—原银行卡异常退到其他银行卡
        /// </summary>
        [XmlElement("refund_channel")]
        public virtual string RefundChannel { get; set; }


        /// <summary>
        /// 退款渠道
        /// ORIGINAL—原路退款
        /// BALANCE—退回到余额
        /// OTHER_BALANCE—原账户异常退到其他余额账户
        /// OTHER_BANKCARD—原银行卡异常退到其他银行卡
        /// </summary>
        [XmlElement("refund_channel_0")]
        public virtual string RefundChannel0 { get; set; }
        /// <summary>
        /// 退款渠道
        /// ORIGINAL—原路退款
        /// BALANCE—退回到余额
        /// OTHER_BALANCE—原账户异常退到其他余额账户
        /// OTHER_BANKCARD—原银行卡异常退到其他银行卡
        /// </summary>
        [XmlElement("refund_channel_1")]
        public virtual string RefundChannel1 { get; set; }
        /// <summary>
        /// 退款渠道
        /// ORIGINAL—原路退款
        /// BALANCE—退回到余额
        /// OTHER_BALANCE—原账户异常退到其他余额账户
        /// OTHER_BANKCARD—原银行卡异常退到其他银行卡
        /// </summary>
        [XmlElement("refund_channel_2")]
        public virtual string RefundChannel2 { get; set; }

        /// <summary>
        /// 退款金额
        /// 退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        [XmlElement("settlement_refund_fee")]
        public virtual string SettlementRefundFee { get; set; }
        /// <summary>
        /// 退款金额
        /// 退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        [XmlElement("settlement_refund_fee_0")]
        public virtual string SettlementRefundFee0 { get; set; }
        /// <summary>
        /// 退款金额
        /// 退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        [XmlElement("settlement_refund_fee_1")]
        public virtual string SettlementRefundFee1 { get; set; }
        /// <summary>
        /// 退款金额
        /// 退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        [XmlElement("settlement_refund_fee_2")]
        public virtual string SettlementRefundFee2 { get; set; }

        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。$n为下标,$m为下标,从0开始编号，举例：coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type")]
        public virtual string CouponType { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。$n为下标,$m为下标,从0开始编号，举例：coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_0_0")]
        public virtual string CouponType00 { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。$n为下标,$m为下标,从0开始编号，举例：coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_0_1")]
        public virtual string CouponType01 { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。$n为下标,$m为下标,从0开始编号，举例：coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_0_2")]
        public virtual string CouponType02 { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。$n为下标,$m为下标,从0开始编号，举例：coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_1_0")]
        public virtual string CouponType10 { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。$n为下标,$m为下标,从0开始编号，举例：coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_1_1")]
        public virtual string CouponType11 { get; set; }

        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。$n为下标,$m为下标,从0开始编号，举例：coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_1_2")]
        public virtual string CouponType12 { get; set; }

        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。$n为下标,$m为下标,从0开始编号，举例：coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_2_0")]
        public virtual string CouponType20 { get; set; }


        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。$n为下标,$m为下标,从0开始编号，举例：coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_2_1")]
        public virtual string CouponType21 { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。$n为下标,$m为下标,从0开始编号，举例：coupon_type_$0_$1
        /// </summary>
        [XmlElement("coupon_type_2_2")]
        public virtual string CouponType22 { get; set; }

        /// <summary>
        /// 总代金券退款金额
        /// 代金券退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见代金券或立减优惠
        /// </summary>
        [XmlElement("coupon_refund_fee")]
        public virtual int CouponRefundFee { get; set; }


        /// <summary>
        /// 总代金券退款金额
        /// 代金券退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见代金券或立减优惠
        /// </summary>
        [XmlElement("coupon_refund_fee_0")]
        public virtual int CouponRefundFee0 { get; set; }

        /// <summary>
        /// 总代金券退款金额
        /// 代金券退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见代金券或立减优惠
        /// </summary>
        [XmlElement("coupon_refund_fee_1")]
        public virtual int CouponRefundFee1 { get; set; }

        /// <summary>
        /// 总代金券退款金额
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
        /// 退款代金券使用数量
        /// </summary>
        [XmlElement("coupon_refund_count_0")]
        public virtual int CouponRefundCount0 { get; set; }
        /// <summary>
        /// 退款代金券使用数量
        /// </summary>
        [XmlElement("coupon_refund_count_1")]
        public virtual int CouponRefundCount1 { get; set; }
        /// <summary>
        /// 退款代金券使用数量
        /// </summary>
        [XmlElement("coupon_refund_count_2")]
        public virtual int CouponRefundCount2 { get; set; }

        /// <summary>
        /// 退款代金券ID
        /// </summary>
        [XmlElement("coupon_refund_id")]
        public virtual string CouponRefundId { get; set; }

        [XmlElement("coupon_refund_id_0_0")]
        public virtual string CouponRefundId00 { get; set; }

        /// <summary>
        /// 单个代金券退款金额
        /// </summary>
        [XmlElement("coupon_refund_fee_0_0")]
        public virtual string CouponRefundFee00 { get; set; }

        /// <summary>     
        /// 退款状态：
        /// UCCESS—退款成功
        /// REFUNDCLOSE—退款关闭。
        /// PROCESSING—退款处理中
        /// CHANGE—退款异常，退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，可前往商户平台（pay.weixin.qq.com）-交易中心，手动处理此笔退款。$n为下标，从0开始编号。
        /// </summary>
        [XmlElement("refund_status")]
        public virtual string RefundStatus { get; set; }
        /// <summary>     
        /// 退款状态：
        /// UCCESS—退款成功
        /// REFUNDCLOSE—退款关闭。
        /// PROCESSING—退款处理中
        /// CHANGE—退款异常，退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，可前往商户平台（pay.weixin.qq.com）-交易中心，手动处理此笔退款。$n为下标，从0开始编号。
        /// </summary>
        [XmlElement("refund_status_0")]
        public virtual string RefundStatus0 { get; set; }

        /// <summary>
        /// 退款资金来源
        /// REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款/基本账户
        /// REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款
        /// $n为下标，从0开始编号。
        /// </summary>
        [XmlElement("refund_account")]
        public virtual string RefundAccount { get; set; }
        /// <summary>
        /// 退款资金来源
        /// REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款/基本账户
        /// REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款
        /// $n为下标，从0开始编号。
        /// </summary>
        [XmlElement("refund_account_0")]
        public virtual string RefundAccount0 { get; set; }

        /// <summary>
        /// 退款入账账户
        /// 取当前退款单的退款入账方
        /// 1）退回银行卡：{银行名称 }{卡类型}{卡尾号}
        /// 2）退回支付用户零钱:支付用户零钱
        /// 3）退还商户:商户基本账户 商户结算银行账户
        /// 4）退回支付用户零钱通:支付用户零钱通
        /// </summary>
        [XmlElement("refund_recv_accout")]
        public virtual string RefundRecvAccout { get; set; }
        /// <summary>
        /// 退款入账账户
        /// 取当前退款单的退款入账方
        /// 1）退回银行卡：{银行名称 }{卡类型}{卡尾号}
        /// 2）退回支付用户零钱:支付用户零钱
        /// 3）退还商户:商户基本账户 商户结算银行账户
        /// 4）退回支付用户零钱通:支付用户零钱通
        /// </summary>
        [XmlElement("refund_recv_accout_0")]
        public virtual string RefundRecvAccout0 { get; set; }
        /// <summary>
        /// 退款成功时间
        /// </summary>
        [XmlElement("refund_success_time")]
        public virtual string RefundSuccessTime { get; set; }

        /// <summary>
        /// 退款成功时间
        /// </summary>
        [XmlElement("refund_success_time_0")]
        public virtual string RefundSuccessTime0 { get; set; }



    }
}


