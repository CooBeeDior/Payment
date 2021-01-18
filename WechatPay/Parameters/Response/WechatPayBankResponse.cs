using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 企业付款到银行卡API
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayBankResponse : WechatPayResponse
    {
        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        [XmlElement("partner_trade_no")]
        public virtual string PartnerTradeNo { get; set; }
        /// <summary>
        /// 代付金额
        /// </summary>
        [XmlElement("amount")]
        public virtual int Amount { get; set; }

        /// <summary>
        /// 微信企业付款单号
        /// </summary>
        [XmlElement("payment_no")]
        public virtual string PaymentNo { get; set; }
        /// <summary>
        /// 手续费金额
        /// </summary>
        [XmlElement("cmms_amt")]
        public virtual int CmmsAmt { get; set; }

        
    }
}
