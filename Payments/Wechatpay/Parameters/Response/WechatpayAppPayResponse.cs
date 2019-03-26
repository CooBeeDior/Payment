 using Newtonsoft.Json;
using Payments.Wechatpay.Parameters.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// 微信App支付服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatpayAppPayResponse : WechatpayPayResponseBase
    {

    }
}

