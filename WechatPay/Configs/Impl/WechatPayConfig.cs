using Payments.Exceptions;
using Payments.Util;
using Payments.Util.Validations;
using WechatPay.Enums;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WechatPay.Configs
{
    /// <summary>
    /// 微信支付配置
    /// </summary>
    public class WechatPayConfig: Validation
    {
        /// <summary>
        /// 支付网关地址,默认为正式地址： https://api.mch.weixin.qq.com
        /// </summary>
        [Required(ErrorMessage = "支付网关地址[GatewayUrl]不能为空")]
        public virtual string GatewayUrl { get; set; } = "https://api.mch.weixin.qq.com";

        /// <summary>
        /// 应用标识
        /// </summary>
        [Required(ErrorMessage = "应用标识[AppId]不能为空")]
        public virtual string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [Required(ErrorMessage = "商户号[MerchantId]不能为空")]
        public virtual string MerchantId { get; set; }

        /// <summary>
        /// 应用私钥
        /// </summary>
        [Required(ErrorMessage = "应用私钥[PrivateKey]不能为空")]
        public virtual string PrivateKey { get; set; }

        /// <summary>
        /// 证书数据
        /// </summary>
        public virtual byte[] CertificateData { get; set; }

        /// <summary>
        /// 证书密码
        /// </summary>
        public virtual string CertificatePwd { get; set; }


        /// <summary>
        /// 签名类型，默认Md5
        /// </summary>
        public virtual WechatPaySignType SignType { get; set; } = WechatPaySignType.Md5;

        /// <summary>
        /// 回调通知地址
        /// </summary>
        public virtual string NotifyUrl { get; set; }

      



    }
}
