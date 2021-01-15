 using Newtonsoft.Json;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// 提交付款码支付
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayMicroPayResponse : WechatPayPayResponseBase
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }
        /// <summary>
        /// 是否关注公众账号
        /// 用户是否关注公众账号，仅在公众账号类型支付有效，取值范围：Y或N;Y-关注;N-未关注
        /// </summary>
        [XmlElement("is_subscribe")]
        public virtual string IsSubscribe { get; set; }

        /// <summary>
        /// 付款银行
        /// 银行类型，采用字符串类型的银行标识，详见银行类型
        /// </summary>
        [XmlElement("bank_type")]
        public virtual string BankType { get; set; }
        /// <summary>
        /// 货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，详见货币类型
        /// </summary>
        [XmlElement("fee_type")]
        public virtual string FeeType { get; set; }

        /// <summary>
        /// 订单金额
        /// 订单总金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        [XmlElement("TotalFee")]
        public virtual int TotalFee { get; set; }

        /// <summary>
        /// 应结订单金额
        /// 当订单使用了免充值型优惠券后返回该参数，应结订单金额=订单金额-免充值优惠券金额。
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public virtual int SettlementTotalFee { get; set; }

        /// <summary>
        /// 代金券金额
        /// “代金券”金额<=订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额
        /// </summary>
        [XmlElement("coupon_fee")]
        public virtual int CouponFee { get; set; }

        /// <summary>
        /// 现金支付货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("cash_fee_type")]
        public virtual string CashFeeType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// </summary>
        [XmlElement("cash_fee")]
        public virtual int CashFee { get; set; }

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
        /// 支付完成时间
        /// 订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。详见时间规则
        /// </summary>
        [XmlElement("time_end")]
        public virtual string TimeEnd { get; set; }

        /// <summary>
        /// 营销详情
        /// </summary>
        [XmlElement("promotion_detail")]
        public virtual string PromotionDetail { get; set; }

    }
}

