using Payments.Core;
using Payments.Exceptions;
using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 查询红包记录服务
    /// </summary>
    public class WechatpayHbInfoRequest : Validation, IWechatpayRequest, IValidation
    {
        /// <summary>
        /// 商户订单号 
        /// </summary>
        [Required]
        [MaxLength(28)]
        public virtual string MchBillNo { get; set; }


    }
}
