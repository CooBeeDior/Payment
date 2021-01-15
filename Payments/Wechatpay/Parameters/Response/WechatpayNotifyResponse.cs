﻿using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// 微信支付通知服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayNotifyResponse : WechatPayResponse
    {
        /// <summary>
        /// 签名类型
        /// 签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        [XmlElement("sign_type")]
        public virtual string SignType { get; set; }

        /// <summary>
        /// 用户标识
        /// 用户在商户appid下的唯一标识
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// 是否关注公众账号
        /// 用户是否关注公众账号，Y-关注，N-未关注
        /// </summary>
        [XmlElement("is_subscribe")]
        public virtual string IsSubscribe { get; set; }

        /// <summary>
        /// 付款银行
        /// 银行类型，采用字符串类型的银行标识，银行类型见银行列表
        /// </summary>
        [XmlElement("bank_type")]
        public virtual string BankType { get; set; }

        /// <summary>
        /// 订单金额
        /// 订单总金额，单位为分
        /// </summary>
        [XmlElement("total_fee")]
        public virtual int TotalFee { get; set; }

        /// <summary>
        /// 应结订单金额
        /// 应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public virtual int SettlementTotalFee { get; set; }

        /// <summary>
        /// 货币种类
        /// 货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("fee_type")]
        public virtual string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// 现金支付金额订单现金支付金额，详见支付金额
        /// </summary>
        [XmlElement("cash_fee")]
        public virtual int CashFee { get; set; }
        /// <summary>
        /// 现金支付货币类型
        /// 货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("cash_fee_type")]
        public virtual string CashFeeType { get; set; }
      
   
        /// <summary>
        /// 代金券使用数量        
        /// </summary>
        [XmlElement("coupon_count")]
        public virtual int CouponCount { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。n为下标,从0开始编号，举例：coupon_type_0
        /// </summary>
        [XmlElement("coupon_type")]
        public virtual string CouponType { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。n为下标,从0开始编号，举例：coupon_type_0
        /// </summary>
        [XmlElement("coupon_type_0")]
        public virtual string CouponType0 { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。n为下标,从0开始编号，举例：coupon_type_0
        /// </summary>
        [XmlElement("coupon_type_1")]
        public virtual string CouponType1 { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// 开通免充值券功能，并且订单使用了优惠券后有返回（取值：CASH、NO_CASH）。n为下标,从0开始编号，举例：coupon_type_0
        /// </summary>
        [XmlElement("coupon_type_2")]
        public virtual string CouponType2 { get; set; }

        /// <summary>
        /// 代金券ID
        /// 单个代金券支付金额, n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_id")]
        public virtual int CouponId { get; set; }

        /// <summary>
        /// 代金券ID
        /// 单个代金券支付金额, n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_id_0")]
        public virtual int CouponId0 { get; set; }

        /// <summary>
        /// 代金券ID
        /// 单个代金券支付金额, n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_id_1")]
        public virtual int CouponId1 { get; set; }

        /// <summary>
        /// 代金券ID
        /// 单个代金券支付金额, n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_id_2")]
        public virtual int CouponId2 { get; set; }


        /// <summary>
        /// 单个代金券支付金额
        /// 单个代金券支付金额, n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_fee")]
        public virtual int CouponFee { get; set; }
        /// <summary>
        /// 单个代金券支付金额
        /// 单个代金券支付金额, n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_fee_0")]
        public virtual int CouponFee0 { get; set; }
        /// <summary>
        /// 单个代金券支付金额
        /// 单个代金券支付金额, n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_fee_1")]
        public virtual int CouponFee1 { get; set; }
        /// <summary>
        /// 单个代金券支付金额
        /// 单个代金券支付金额, n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_fee_2")]
        public virtual int CouponFee2 { get; set; }

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
        /// 订单支付时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        [XmlElement("time_end")]
        public virtual string TimeEnd { get; set; }
        /// <summary>
        /// 交易状态描述
        /// 对当前查询订单状态的描述和下一步操作的指引
        /// </summary>
        [XmlElement("trade_state_desc")]
        public virtual string Trade_StateDesc { get; set; }
    }
}
