using Payments.Core;
using Payments.Exceptions;
using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 用于对商户企业付款到银行卡操作进行结果查询，返回付款操作详细结果。
    /// 注意事项
    /// 如果查询单号对应的数据不存在，那么数据不存在的原因可能是：
    /// （1）付款还在处理中；
    /// （2）付款处理失败导致付款订单没有落地。
    /// 在上述情况下，商户首先需要检查该商户订单号是否确实是自己发起的，如果商户确认是自己发起的，
    /// 则请商户不要直接当做付款失败处理，请商户隔几分钟再尝试查询（请勿付款和查询并发处理），
    /// 或者商户可以通过相同的商户订单号再次发起付款。如果商户误把还在付款处理中的订单直接当付款失败处理，
    /// 商户应当自行承担因此产生的所有损失和责任。
    /// </summary>
    public class WechatQueryPayBankRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 商户企业付款单号
        /// 商户订单号，需保持唯一（只允许数字[0~9]或字母[A~Z]和[a~z]，最短8位，最长32位）
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string PartnerTradeNo { get; set; }
    }
}
