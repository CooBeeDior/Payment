 using Newtonsoft.Json;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// 企业转账服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatTransfersResponse : WechatPayResponse
    {
        /// <summary>
        /// 商户订单号，需保持历史全局唯一性(只能是字母或者数字，不能包含有其他字符)
        /// </summary>
        [XmlElement("partner_trade_no")]
        public virtual string PartnerTradeNo { get; set; }

        /// <summary>
        /// 微信付款单号
        /// 企业付款成功，返回的微信付款单号
        /// </summary>
        [XmlElement("payment_no")]
        public virtual string PaymentNo { get; set; }

        /// <summary>
        /// 付款成功时间
        /// </summary>
        [XmlElement("payment_time")]
        public virtual string PaymenTime { get; set; }

    }
}

