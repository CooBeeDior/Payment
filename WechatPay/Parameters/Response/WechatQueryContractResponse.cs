using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 查询签约关系服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatQueryContractResponse : WechatPayResponse
    {
        /// <summary>
        /// 委托代扣协议id
        /// </summary>
        [XmlElement("contract_id")]
        public virtual string ContractId { get; set; }

        /// <summary>
        /// 模板id
        /// </summary>
        [XmlElement("plan_id")]
        public virtual string PlanId { get; set; }
        /// <summary>
        /// 商户请求签约时的序列号，商户侧须唯一。
        /// 序列号主要用于排序，不作为查询条件，纯数字,范围不能超过Int64的范围（9223372036854775807）。
        /// </summary>
        [XmlElement("request_serial")]
        public virtual Int64 RequestSerial { get; set; }

        /// <summary>
        /// 签约协议号
        /// </summary>
        [XmlElement("contract_code")]
        public virtual string ContractCode { get; set; }

        /// <summary>
        /// 用户账户展示名称
        /// </summary>
        [XmlElement("contract_display_account")]
        public virtual string ContractDisplayAccount { get; set; }

        /// <summary>
        /// 协议状态
        /// 0-已签约  1-未签约
        /// </summary>
        [XmlElement("contract_state")]
        public virtual int ContractState { get; set; }

        /// <summary>
        /// 协议签署时间
        /// </summary>
        [XmlElement("contract_signed_time")]
        public virtual string ContractSignedTime { get; set; }

        /// <summary>
        /// 协议到期时间
        /// </summary>
        [XmlElement("contract_expired_time")]
        public virtual string ContractExpiredTime { get; set; }

        /// <summary>
        /// 协议解约时间
        /// 当contract_state=1时，该值有效
        /// </summary>
        [XmlElement("contract_terminated_time")]
        public virtual string ContractTerminatedTime { get; set; }

        /// <summary>
        /// 协议解约方式
        /// 当contract_state=1时，该值有效 
        /// 0-未解约 
        /// 1-有效期过自动解约 
        /// 2-用户主动解约 
        /// 3-商户API解约 
        /// 4-商户平台解约 
        /// 5-注销
        /// </summary>
        [XmlElement("contract_termination_mode")]
        public virtual int ContractTerminationMode { get; set; }

        /// <summary>
        /// 解约备注
        /// 当contract_state=1时，该值有效
        /// </summary>
        [XmlElement("contract_termination_remark")]
        public virtual int ContractTrminationRemark { get; set; }


        /// <summary>
        /// 用户标识
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }


    }
}
