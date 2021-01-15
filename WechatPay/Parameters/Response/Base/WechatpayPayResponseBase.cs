using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 支付基类
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayPayResponseBase : WechatPayResponse
    {
  

        /// <summary>
        /// 调用接口提交的终端设备号，
        /// </summary>
        [XmlElement("device_info")]
        public virtual string DeviceInfo { get; set; }
        

  
        /// <summary>
        /// 微信生成的预支付会话标识，用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        [XmlElement("prepay_id")]
        public virtual string PrepayId { get; set; }

        /// <summary>
        /// JSAPI -JSAPI支付
        /// NATIVE -Native支付
        /// APP -APP支付
        /// 说明详见参数规定
        /// </summary>
        [XmlElement("trade_type")]
        public virtual string TradeType { get; set; }


     


    }
}
