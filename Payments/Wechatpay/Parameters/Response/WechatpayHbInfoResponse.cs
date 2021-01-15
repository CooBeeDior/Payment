using Newtonsoft.Json;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// 查询红包记录服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayHbInfoResponse : WechatPayResponse
    {

        /// <summary>
        /// 商户订单号
        /// 商户使用查询API填写的商户单号的原路返回
        /// </summary>
        [XmlElement("mch_billno")]
        public virtual string MhBillNo { get; set; }

        /// <summary>
        /// 红包单号
        /// 使用API发放现金红包时返回的红包单号
        /// </summary>
        [XmlElement("detail_id")]
        public virtual string DetailId { get; set; }

        /// <summary>
        /// 红包状态
        /// SENDING:发放中 
        /// SENT:已发放待领取
        /// FAILED：发放失败
        /// RECEIVED:已领取
        /// RFUND_ING:退款中
        /// REFUND:已退款
        /// </summary>
        [XmlElement("status")]
        public virtual string Status { get; set; }

        /// <summary>
        /// 发放类型
        /// API:通过API接口发放 
        /// UPLOAD:通过上传文件方式发放
        /// ACTIVITY:通过活动方式发放
        /// </summary>
        [XmlElement("send_type")]
        public virtual string SendType { get; set; }

        /// <summary>
        /// 红包类型
        /// GROUP:裂变红包   NORMAL:普通红包
        /// </summary>
        [XmlElement("hb_type")]
        public virtual string HbType { get; set; }

        /// <summary>
        /// 红包个数
        /// </summary>
        [XmlElement("total_num")]
        public virtual int TotalNum { get; set; }

        /// <summary>
        /// 红包总金额（单位分）
        /// </summary>
        [XmlElement("total_amount")]
        public virtual int TotalAmount { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        [XmlElement("reason")]
        public virtual string Reason { get; set; }

        /// <summary>
        /// 红包发送时间
        /// 例如：2015-04-21 20:00:00
        /// </summary>
        [XmlElement("send_time")]
        public virtual string SendTime { get; set; }

        /// <summary>
        /// 红包退款时间
        /// 例如：2015-04-21 20:00:00
        /// </summary>
        [XmlElement("refund_time")]
        public virtual string RefundTime { get; set; }

        /// <summary>
        /// 红包退款金额
        /// </summary>
        [XmlElement("refund_amount")]
        public virtual int RefundAmount { get; set; }

        /// <summary>
        /// 祝福语
        /// </summary>
        [XmlElement("wishing")]
        public virtual string Wishing { get; set; }

        /// <summary>
        /// 活动描述
        /// </summary>
        [XmlElement("remark")]
        public virtual string Remark { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [XmlElement("act_name")]
        public virtual string ActName { get; set; }

        /// <summary>
        /// 裂变红包的领取列表
        /// <hblist>
        /// <hbinfo>
        /// <openid><![CDATA[oHkLxtzmyHXX6FW_cAWo_orTSRXs]]></openid>
        /// <amount>100</amount>
        /// <rcv_time><![CDATA[2016-08-08 21:49:46]]></rcv_time>
        /// </hbinfo>
        /// </hblist>
        /// </summary> 
        [XmlArray("hblist"), XmlArrayItem("hbinfo")]
        public virtual HbInfo[] HbList { get; set; }

      
    }
    [XmlRoot("hbinfo")]
    public class HbInfo
    {
        /// <summary>
        /// 领取红包的Openid
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }
        /// <summary>
        /// 金额 单位分
        /// </summary>
        [XmlElement("amount")]
        public virtual int amount { get; set; }
        /// <summary>
        /// 领取红包的时间
        /// </summary>
        [XmlElement("rcv_time")]
        public virtual string rcv_time { get; set; }
    }
}

