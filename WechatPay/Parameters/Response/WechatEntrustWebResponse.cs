using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 公众号APP申请签约
    /// </summary>
    [XmlRoot("xml")]
    public class WechatEntrustWebResponse : WechatPayResponse
    {

        /// <summary>
        /// 签约协议号
        /// </summary>
        [XmlElement("contract_code")]
        public virtual string ContractCode { get; set; }

        /// <summary>
        /// 模板id
        /// </summary>
        [XmlElement("plan_id")]
        public virtual string PlanId { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        [XmlElement("openid")]
        public virtual string OpenId { get; set; }


        /// <summary>
        /// 有两个变更类型取值:
        /// ADD--签约
        /// DELETE--解约
        /// </summary>
        [XmlElement("change_type")]
        public virtual string ChangeType { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [XmlElement("operate_time")]
        public virtual string OperateTime { get; set; }
        /// <summary>
        /// 委托代扣协议id
        /// </summary>
        [XmlElement("contract_id")]
        public virtual string ContractId { get; set; }

        /// <summary>
        /// 当change_type为DELETE时有返回 
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
        /// 商户请求签约时的序列号，商户侧须唯一。
        /// 序列号主要用于排序，不作为查询条件，纯数字,范围不能超过Int64的范围（9223372036854775807）。
        /// </summary>
        [XmlElement("request_serial")]
        public virtual Int64 RequestSerial { get; set; }




    }
}

