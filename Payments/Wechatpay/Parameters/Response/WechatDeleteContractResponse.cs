using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Payments.Wechatpay.Parameters.Response
{
    /// <summary>
    /// 申请解约
    /// </summary> 
    [XmlRoot("xml")]
    public class WechatDeleteContractResponse : WechatpayResponse
    {
        /// <summary>
        /// 委托代扣协议id
        /// </summary>
        [XmlElement("contract_id")]
        public virtual string ContractId { get; set; }

        /// <summary>
        /// 模板id
        /// 商户在微信商户平台设置的代扣协议模板id
        /// </summary>
        [XmlElement("plan_id")]
        public virtual string PlanId { get; set; }

    }
}
