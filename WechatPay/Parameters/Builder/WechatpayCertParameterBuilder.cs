//using Microsoft.AspNetCore.Http;
//using Payments.Extensions;
//using Payments.Util.ParameterBuilders.Impl;
//using WechatPay.Configs;
//using WechatPay.Enums;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace WechatPay.Parameters
//{
//    /// <summary>
//    /// 证书 微信支付参数生成器
//    /// </summary>
//    public class WechatPayCertParameterBuilder : WechatPayParameterBuilder
//    {
//        public WechatPayCertParameterBuilder(WechatPayConfig config, HttpRequest httpRequest = null) : base(config, httpRequest)
//        {

//        }

//        /// <summary>
//        /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=4_3
//        /// </summary>
//        /// <param name="isSign"></param>
//        /// <returns></returns>
//        protected override ParameterBuilder GetSignBuilder(bool isSign = true, WechatPaySignType? signType = null)
//        {
//            return base.GetSignBuilder(isSign, signType);
//            //var builder = new ParameterBuilder(Builder);
//            ////string url = $"{ builder.ToUrl()}&key={Config.PrivateKey}";
//            //if (isSign)
//            //{
//            //    builder.Add(WechatPayConst.Sign, GetSign(signType).ToUpper());
//            //}         
//            //return builder;
//        }
//    }
//}
