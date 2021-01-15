using Microsoft.AspNetCore.Http;
using Payments.Extensions;
using Payments.Util.Http;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Util.Signatures;
using Payments.WechatPay.Configs;
using Payments.WechatPay.Enums;
using System;

namespace Payments.WechatPay.Signatures
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
        public static ISignManager Create(WechatPayConfig config, HttpRequest httpRequest, ParameterBuilder builder, WechatPaySignType? signType = null)
        {
            if (signType != null && signType == WechatPaySignType.Md5)
            {
                return new Md5SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (signType != null && signType == WechatPaySignType.HmacSha256)
            {
                return new HmacSha256SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (builder.GetValue(WechatPayConst.SignType)?.ToString() == WechatPaySignType.Md5.Description())
            {
                return new Md5SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (builder.GetValue(WechatPayConst.SignType)?.ToString() == WechatPaySignType.HmacSha256.Description())
            {
                return new HmacSha256SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (config.SignType == WechatPaySignType.Md5)
                return new Md5SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            if (config.SignType == WechatPaySignType.HmacSha256)
                return new HmacSha256SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            throw new NotImplementedException($"未实现签名算法:{config.SignType.Description()}");
        }
    }
}
