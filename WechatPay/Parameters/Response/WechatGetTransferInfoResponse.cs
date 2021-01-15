 using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 查询企业付款服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatGetTransferInfoResponse : WechatPayResponse
    {
        /// <summary>
        /// 商户使用查询API填写的单号的原路返回. 
        /// </summary>
        [XmlElement("partner_trade_no")]
        public virtual string PartnerTradeNo { get; set; }

        /// <summary>
        /// 调用企业付款API时，微信系统内部产生的单号
        /// </summary>
        [XmlElement("detail_id")]
        public virtual string DetailId { get; set; }

        /// <summary>
        /// 转账状态
        /// SUCCESS:转账成功
        /// FAILED:转账失败
        /// PROCESSING:处理中
        /// </summary>
        [XmlElement("status")]
        public virtual string Status { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        [XmlElement("reason")]
        public virtual string Reason { get; set; }

        /// <summary>
        /// 收款用户openid
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// 收款用户姓名
        /// </summary>
        [XmlElement("transfer_name")]
        public virtual string TransferName { get; set; }

        /// <summary>
        /// 付款金额 付款金额单位分）
        /// </summary>
        [XmlElement("payment_amount")]
        public virtual int PaymentAmount { get; set; }

        /// <summary>
        /// 发起转账的时间
        /// </summary>
        [XmlElement("transfer_time")]
        public virtual string TransferTime { get; set; }

        /// <summary>
        /// 企业付款成功时间
        /// </summary>
        [XmlElement("payment_time")]
        public virtual string PaymentTime { get; set; }

        /// <summary>
        /// 企业付款备注
        /// </summary>
        [XmlElement("desc")]
        public virtual string Desc { get; set; }
       

    }
}

