using Payments.Wechatpay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// 微信扫码支付异步回调
    /// </summary>
    [XmlRoot("xml")]
    public class WechatpayNativePayOneNotifyResponse : WechatpayResponse
    {
    }
}
