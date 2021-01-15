using Payments.Util.Validations;
using Payments.Util.Validations.Attribbutes;
using Payments.WechatPay.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payments.WechatPay.Parameters.Requests
{
    /// <summary>
    /// 发放裂变红包
    /// </summary>
    public class WechatSendGroupRedPackRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [MaxLength(28)]
        public virtual string MchBillNo { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string SendName { get; set; }

        /// <summary>
        /// 用户openid
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string ReOpenId { get; set; }


        /// <summary>
        /// 付款金额
        /// </summary>
        [Required]
        [MinValue(0)]
        public virtual decimal TotalAmount { get; set; }

        [Required]
        [MinValue(0)]
        public virtual int TotalNum { get; set; }

        /// <summary>
        /// 红包金额设置方式  
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string AmtType { get; set; } = "ALL_RAND";

        /// <summary>
        /// 红包祝福语
        /// </summary>
        [Required]
        [MaxLength(128)]
        public virtual string Wishing { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string ActName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Required]
        [MaxLength(256)]
        public virtual string Remark { get; set; }

        /// <summary>
        /// 场景id
        /// </summary>
        public virtual RedPackSenceType? SceneId { get; set; }

        /// <summary>
        /// 活动信息
        /// </summary>
        [MaxLength(128)]
        public virtual string RiskInfo { get; set; }
    }
}
