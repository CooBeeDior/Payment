 using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 微信MWeb支付
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayMWebPayResponse : WechatPayPayResponseBase
    {
        /// <summary>
        /// 支付跳转链接
        /// mweb_url为拉起微信支付收银台的中间页面，可通过访问该url来拉起微信客户端，完成支付,mweb_url的有效期为5分钟
        /// </summary>
        [XmlElement("mweb_url")]
        public virtual string MwebUrl { get; set; }
    }
}

