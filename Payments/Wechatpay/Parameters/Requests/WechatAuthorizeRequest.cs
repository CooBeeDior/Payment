using Payments.Util.Validations;
using System.ComponentModel.DataAnnotations;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 授权
    /// </summary>
    public class WechatAuthorizeRequest : Validation, IWechatpayRequest, IValidation
    { 
        /// <summary>
        /// 授权后重定向的回调链接地址， 请使用 urlEncode 对链接进行处理
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string RedirectUri { get; set; }

        /// <summary>
        /// 重定向后会带上state参数，开发者可以填写a-zA-Z0-9的参数值，最多128字节
        /// </summary>
        [MaxLength(128)]
        public string State { get; set; }

        /// <summary>
        /// 应用授权作用域，
        /// snsapi_base （不弹出授权页面，直接跳转，只能获取用户openid），
        /// snsapi_userinfo （弹出授权页面，可通过openid拿到昵称、性别、所在地。并且， 即使在未关注的情况下，只要用户授权，也能获取其信息 ）
        /// </summary>
        public string Scope { get; set; } = "snsapi_base";
    }
}
