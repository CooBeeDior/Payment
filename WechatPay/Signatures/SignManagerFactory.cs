using Microsoft.AspNetCore.Http;
using Payments.Extensions;
using Payments.Util.Http;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Util.Signatures;
using WechatPay.Configs;
using WechatPay.Enums;
using System;
using Payments.Core.Enum;

namespace WechatPay.Signatures
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
        public static ISignManager Create(WechatPayConfig config, HttpRequest httpRequest, ParameterBuilder builder, PaySignType? signType = null)
        {
            if (signType != null && signType == PaySignType.Md5)
            {
                return new Md5SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (signType != null && signType == PaySignType.HmacSha256)
            {
                return new HmacSha256SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (builder.GetValue(WechatPayConst.SignType)?.ToString() == PaySignType.Md5.Description())
            {
                return new Md5SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (builder.GetValue(WechatPayConst.SignType)?.ToString() == PaySignType.HmacSha256.Description())
            {
                return new HmacSha256SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            }
            if (config.SignType == PaySignType.Md5)
                return new Md5SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            if (config.SignType == PaySignType.HmacSha256)
                return new HmacSha256SignManager(new SignKey(config.PrivateKey), httpRequest, builder);
            throw new NotImplementedException($"未实现签名算法:{config.SignType.Description()}");
        }
    }
}
