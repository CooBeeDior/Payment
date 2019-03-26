 using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// 发放普通红包服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatSendRedPackResponse : WechatpayResponse
    {

        /// <summary>
        /// 商户订单号
        /// 商户使用查询API填写的商户单号的原路返回
        /// </summary>
        [XmlElement("mch_billno")]
        public virtual string MhBillNo { get; set; }

        /// <summary>
        /// 调用接口提交的公众账号ID
        /// </summary>
        [XmlElement("wxappid")]
        public override string AppId { get; set; }

        /// <summary>
        /// 用户openid
        /// </summary>
        [XmlElement("re_openid")]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// 付款总金额，单位分
        /// </summary>
        [XmlElement("total_amount")]
        public virtual string TotalAmount { get; set; }

        /// <summary>
        /// 微信单号
        /// </summary>
        [XmlElement("send_listid")]
        public virtual string SendListId { get; set; }
    }
}

