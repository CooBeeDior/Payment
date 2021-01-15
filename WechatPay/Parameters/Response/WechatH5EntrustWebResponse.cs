 using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// H5纯签约
    /// </summary>
    [XmlRoot("xml")]
    public class WechatH5EntrustWebResponse : WechatPayResponse
    {
        /// <summary>
        /// 跳转签约页面url，用户通过跳转访问此URL即可进入微信签约页面，进行签约。
        /// 注意这里请求跳转url的页面地址必须在微信后台配置（申请H5签约权限时配置）。
        /// </summary>
        [XmlElement("redirect_url")]
        public virtual string RedirectUrl { get; set; }
        
    }
}

