using Microsoft.AspNetCore.Http;
using Payments.Extensions;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Wechatpay.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Wechatpay.Parameters
{
    /// <summary>
    /// 证书 微信支付参数生成器
    /// </summary>
    public class WechatpayCertParameterBuilder : WechatpayParameterBuilder
    {
        public WechatpayCertParameterBuilder(WechatpayConfig config, HttpRequest httpRequest = null) : base(config, httpRequest)
        {

        }

        protected override ParameterBuilder GetSignBuilder()
        {
            //https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=4_3
            Config.Key.CheckNull(nameof(Config.Key));
            var builder = new ParameterBuilder(Builder);
            string url = $"{ builder.ToUrl()}&key={Config.Key}";
            builder.Add(WechatpayConst.Sign, GetSign().ToUpper());
            return builder;
        }
    }
}
