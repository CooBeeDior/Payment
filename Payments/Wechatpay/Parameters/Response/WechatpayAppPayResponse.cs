 using Newtonsoft.Json;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// 微信App支付服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayAppPayResponse : WechatPayPayResponseBase
    {

    }
}

