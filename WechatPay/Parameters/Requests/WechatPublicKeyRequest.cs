using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 获取RSA加密公钥API
    /// </summary>
    public class WechatPublicKeyRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 是否采用新的公钥
        /// </summary>
        public bool IsNew { get; set; }
    }
}
