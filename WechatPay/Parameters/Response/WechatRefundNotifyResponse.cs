using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 订单退款通知服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatRefundNotifyResponse : WechatPayResponse
    {
        /// <summary>
        /// 加密信息
        /// </summary>
        [XmlElement("req_info")]
        public virtual string ReqInfoStr { get; set; }
        [XmlIgnore]
        public ReqInfo ReqInfo { get; set; }
    }
    [XmlRoot("root")]
    public class ReqInfo
    {

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
        /// 退款状态
        /// SUCCESS-退款成功
        /// CHANGE-退款异常
        /// REFUNDCLOSE—退款关闭
        /// </summary>
        [XmlElement("refund_status")]
        public virtual string RefundStatus { get; set; }

        /// <summary>
        /// 退款成功时间
        /// 资金退款至用户帐号的时间，格式2017-12-15 09:46:01
        /// </summary>
        [XmlElement("success_time")]
        public virtual string SuccessTime { get; set; }

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
        /// 退款资金来源
        /// EFUND_SOURCE_RECHARGE_FUNDS 可用余额退款/基本账户
        /// REFUND_SOURCE_UNSETTLED_FUNDS 未结算资金退款
        /// </summary>
        [XmlElement("refund_account")]
        public virtual string RefundAccount { get; set; }

        /// <summary>
        /// 退款发起来源
        /// API接口
        /// VENDOR_PLATFORM商户平台
        /// </summary>
        [XmlElement("refund_request_source")]
        public virtual string RefundRequestSource { get; set; }
    }


}
