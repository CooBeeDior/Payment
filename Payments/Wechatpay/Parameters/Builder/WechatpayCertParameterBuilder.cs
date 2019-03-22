﻿using Microsoft.AspNetCore.Http;
using Payments.Extensions;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Enums;
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

        /// <summary>
        /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=4_3
        /// </summary>
        /// <param name="isSign"></param>
        /// <returns></returns>
        protected override ParameterBuilder GetSignBuilder(bool isSign = true, WechatpaySignType? signType = null)
        { 
            Config.Key.CheckNull(nameof(Config.Key));
            var builder = new ParameterBuilder(Builder);
            string url = $"{ builder.ToUrl()}&key={Config.Key}";
            if (isSign)
            {
                builder.Add(WechatpayConst.Sign, GetSign(signType).ToUpper());
            }         
            return builder;
        }
    }
}
