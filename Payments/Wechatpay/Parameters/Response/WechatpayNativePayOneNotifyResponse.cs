﻿using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// 微信扫码支付异步回调
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayNativePayOneNotifyResponse : WechatPayResponse
    {
    }
}
