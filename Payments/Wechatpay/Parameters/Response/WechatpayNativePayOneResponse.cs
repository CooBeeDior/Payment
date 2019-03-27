 using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// 微信Native场景一支付
    /// </summary>
    [XmlRoot("xml")]
    public class WechatpayNativePayOneResponse : WechatpayPayResponseBase
    {

    }
}

