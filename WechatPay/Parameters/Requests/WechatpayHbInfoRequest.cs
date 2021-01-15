using Payments.Util.Validations;
using System.ComponentModel.DataAnnotations;

namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 查询红包记录服务
    /// </summary>
    public class WechatPayHbInfoRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 商户订单号 
        /// </summary>
        [Required]
        [MaxLength(28)]
        public virtual string MchBillNo { get; set; }


    }
}
