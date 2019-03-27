using Payments.Core;
using Payments.Exceptions;
using Payments.Properties;
using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 申请解约
    /// </summary>
    public class WechatDeleteContractRequest : Validation, IWechatpayRequest, IValidation
    {

        /// <summary>
        /// 协议模板id，设置路径见 https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=17_3
        /// </summary>
        [Required]
        public string PlanId { get; set; }

        /// <summary>
        /// 商户侧的签约协议号，由商户生成
        /// </summary>
        [Required]
        public string ContractCode { get; set; }

        /// <summary>
        /// 委托代扣协议id
        /// 委托代扣签约成功后由微信返回的委托代扣协议id，选择contract_id查询，则此参数必填
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string ContractId { get; set; }


        /// <summary>
        /// 解约备注
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string ContractTerminationRemark { get; set; }
    }
}
