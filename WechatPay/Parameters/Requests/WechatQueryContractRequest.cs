using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 查询签约关系服务
    /// </summary>
    public class WechatQueryContractRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 委托代扣协议id
        /// 委托代扣签约成功后由微信返回的委托代扣协议id，选择contract_id查询，则此参数必填
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string ContractId { get; set; }

        /// <summary>
        /// 模板id
        /// 商户在微信商户平台配置的代扣模版id，选择plan_id+contract_code查询，则此参数必填
        /// </summary>
        [Required]        
        public string PlanId { get; set; }


        /// <summary>
        /// 商户侧的签约协议号，由商户生成
        /// </summary>
        [Required]
        public string ContractCode { get; set; }

    }
}
