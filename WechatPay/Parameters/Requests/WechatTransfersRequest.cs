using Payments.Exceptions;
using Payments.Util.Validations;
using Payments.Util.Validations.Attribbutes;
using WechatPay.Enums;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 企业转账
    /// </summary>
    public class WechatTransfersRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [MaxLength(32)]
        [Required]
        public virtual string PartnerTradeNo { get; set; }

        /// <summary>
        /// 微信支付分配的终端设备号
        /// </summary>
        public virtual string DeviceInfo { get; set; }

        /// <summary>
        /// 商户appid下，某用户的openid
        /// </summary>
        [MaxLength(32)]
        [Required]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// 校验用户姓名选项
        /// </summary>
        [MaxLength(16)]
        [Required]
        public virtual CheckNameType? CheckName { get; set; }

        /// <summary>
        /// 收款用户真实姓名。如果check_name设置为FORCE_CHECK，则必填用户真实姓名
        /// </summary>
        [MaxLength(16)]
        public virtual string ReUserName { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [MinValue(0)]
        public virtual decimal Amount { get; set; }

        /// <summary>
        /// 企业付款备注
        /// </summary>
        [MaxLength(100)]
        [Required]
        public virtual string Desc { get; set; }

 
    }
}
