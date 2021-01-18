using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 用于对商户企业付款到银行卡操作进行结果查询，返回付款操作详细结果。
    /// </summary>
    [XmlRoot("xml")]
    public class WechatQueryPayBankResponse : WechatPayPayResponseBase
    {
        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        [XmlElement("partner_trade_no")]
        public virtual string PartnerTradeNo { get; set; }

        /// <summary>
        /// 微信企业付款单号
        /// </summary>
        [XmlElement("payment_no")]
        public virtual string PaymentNo { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        [XmlElement("bank_no_md5")]
        public virtual string BankNoMd5 { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [XmlElement("true_name_md5")]
        public virtual string TrueNameMd5 { get; set; }

        /// <summary>
        /// 代付金额
        /// </summary>
        [XmlElement("amount")]
        public virtual int Amount { get; set; }
        /// <summary>
        /// 代付单状态
        /// 代付订单状态：
        /// PROCESSING（处理中，如有明确失败，则返回额外失败原因；否则没有错误原因）
        /// SUCCESS（付款成功）
        /// FAILED（付款失败,需要替换付款单号重新发起付款）
        /// BANK_FAIL（银行退票，订单状态由付款成功流转至退票,退票时付款金额和手续费会自动退还）
        /// </summary>
        [XmlElement("status")]
        public virtual string Status { get; set; }
        /// <summary>
        /// 手续费金额
        /// </summary>
        [XmlElement("cmms_amt")]
        public virtual string CmmsAmt { get; set; }
        /// <summary>
        /// 商户下单时间
        /// </summary>
        [XmlElement("create_time")]
        public virtual string CreateTime { get; set; }
        /// <summary>
        /// 微信侧付款成功时间（依赖银行的处理进度，可能出现延迟返回，甚至被银行退票的情况）
        /// </summary>
        [XmlElement("pay_succ_time")]
        public virtual string PaySuccTime { get; set; }
        /// <summary>
        /// 成功付款时间
        /// </summary>
        [XmlElement("reason")]
        public virtual string Reason { get; set; }
 

    }
}