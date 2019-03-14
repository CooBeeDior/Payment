using Microsoft.AspNetCore.Http;
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
            //TODO https://docs.open.alipay.com/203/107090/
            var builder = new ParameterBuilder(Builder);
            builder.Add(WechatpayConst.Sign, GetSign());
            return builder;
        }
    }
}
