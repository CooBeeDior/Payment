 using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 微信Native场景一支付
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayNativePayOneResponse : WechatPayPayResponseBase
    {

    }
}

