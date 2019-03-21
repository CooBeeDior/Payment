using Payments.Util.Validations;
using System.ComponentModel.DataAnnotations;

namespace Payments.Wechatpay.Parameters.Requests
{
  
    /// <summary>
    /// 授权access_token
    /// </summary>
    public class WechatAccessTokenRequest : Validation, IWechatpayRequest, IValidation
    {
        /// <summary>
        /// 填写第一步获取的code参数
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Code { get; set; }
    }
}
