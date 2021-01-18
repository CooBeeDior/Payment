using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 企业付款到银行卡API
    /// </summary>
    public class WechatPayBankRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 商户企业付款单号
        /// 商户订单号，需保持唯一（只允许数字[0~9]或字母[A~Z]和[a~z]，最短8位，最长32位）
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 收款方银行卡号
        /// 收款方银行卡号（采用标准RSA算法，公钥由微信侧提供）,详见获取RSA加密公钥API
        /// </summary>
        [Required]
        [MaxLength(1024)]
        public string EncBankNo { get; set; }
        /// <summary>
        /// 收款方用户名
        /// 收款方用户名（采用标准RSA算法，公钥由微信侧提供）详见获取RSA加密公钥API
        /// </summary>
        [Required]
        [MaxLength(1024)]
        public string EncTrueName { get; set; }
        /// <summary>
        /// 收款方开户行
        /// 银行卡所在开户行编号,详见银行编号列表
        /// https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=24_4
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string BankCode { get; set; }

        /// <summary>
        /// 付款金额
        /// 付款金额：RMB分（支付总额，不含手续费）
        /// 注：大于0的整数
        /// </summary>
        [Required]
        public int Amount { get; set; }
        /// <summary>
        /// 企业付款到银行卡付款说明,即订单备注（UTF8编码，允许100个字符以内）
        /// </summary>
        [MaxLength(512)]
        public string Desc { get; set; }
    }
}
