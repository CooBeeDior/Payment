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
    /// 支付中签约服务
    /// </summary>
    public class WechatContractOrderRequest : WechatpayPayRequestBase, IWechatpayRequest
    {


        /// <summary>
        /// 用户标识
        /// </summary>
        [Required]
        [MaxLength(128)]
        public override string OpenId { get; set; }

        /// <summary>
        /// 交易类型 取值如下：JSAPI,NATIVE,APP,MWEB
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string TradeType { get; set; }



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
        /// 商户请求签约时的序列号，要求唯一性。序列号主要用于排序，不作为查询条件，纯数字,范围不能超过Int64的范围（9223372036854775807）。
        /// </summary>
        [Required]    
        public Int64 RequestSerial { get; set; }

        /// <summary>
        /// 签约用户的名称，用于页面展示，，参数值不支持UTF8非3字节编码的字符，例如表情符号，所以请勿传微信昵称到该字段
        /// </summary>
        [Required] 
        public string ContractDisplayAccount { get; set; }

        /// <summary>
        /// 签约信息通知url
        /// </summary>
        [Required] 
        public string ContractNotifyUrl { get; set; }

    
    }
}
