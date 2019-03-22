using Microsoft.AspNetCore.Http;
using Payments.Extensions;
using Payments.Util.Http;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Util.Signatures;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Enums;
using System;

namespace Payments.Wechatpay.Signatures
{
    /// <summary>
    /// 微信支付签名工厂
    /// </summary>
    public class SignManagerFactory
    {
        /// <summary>
        /// 创建签名服务
        /// </summary>
        /// <param name="config">微信支付配置</param>
        /// <param name="builder">参数生成器</param>
        public static ISignManager Create(WechatpayConfig config, HttpRequest httpRequest, ParameterBuilder builder, WechatpaySignType? signType = null)
        {
            if (signType != null && signType == WechatpaySignType.Md5)
            {
                return new Md5SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (signType != null && signType == WechatpaySignType.HmacSha256)
            {
                return new HmacSha256SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (builder.GetValue(WechatpayConst.SignType)?.ToString() == WechatpaySignType.Md5.Description())
            {
                return new Md5SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (builder.GetValue(WechatpayConst.SignType)?.ToString() == WechatpaySignType.HmacSha256.Description())
            {
                return new HmacSha256SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (config.SignType == WechatpaySignType.Md5)
                return new Md5SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            if (config.SignType == WechatpaySignType.HmacSha256)
                return new HmacSha256SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            throw new NotImplementedException($"未实现签名算法:{config.SignType.Description()}");
        }
    }
}
