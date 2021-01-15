using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 提交付款码支付
    /// </summary>
    public class WechatPayMicroPayRequest : WechatPayPayRequestBase
    {
        /// <summary>
        /// 扫码支付授权码，设备读取用户微信中的条码或者二维码信息
        ///（注：用户付款码条形码规则：18位纯数字，以10、11、12、13、14、15开头）
        /// </summary>
        [Required]
        [MaxLength(128)]
        public virtual string AuthCode { get; set; }
    }
}
