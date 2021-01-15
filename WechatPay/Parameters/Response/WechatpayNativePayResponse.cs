using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 微信Native支付服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayNativePayResponse : WechatPayPayResponseBase
    {
        /// <summary>
        /// 二维码链接
        /// trade_type=NATIVE时有返回，此url用于生成支付二维码，然后提供给用户进行扫码支付。
        /// 注意：code_url的值并非固定，使用时按照URL格式转成二维码即可
        /// </summary>
        [XmlElement("code_url")]
        public virtual string CodeUrl { get; set; }


    }
}
 

