using Payments.Util.Validations;
using System;
using System.ComponentModel.DataAnnotations;
namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// H5纯签约
    /// </summary>
    public class WechatH5EntrustWebRequest : Validation, IWechatpayRequest, IValidation
    {
        // <summary>
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
        /// 用于接收签约成功消息的回调通知地址，以http或https开头。请对notify_url参数值进行encode处理。当签约场景为APP时，且系统为ios时，需要对参数值做两次encode。
        /// </summary>
        [Required]
        public string NotifyUrl { get; set; }
 

        /// <summary>
        /// 当指定该字段时，且商户模版标注商户具有指定返回app的权限时，
        /// 签约成功将返回return_appid指定的app应用，
        /// 如果不填且签约发起时的浏览器UA可被微信识别，则跳转到浏览器，否则留在微信
        /// </summary>
        public string ReturnAppId { get; set; }
    }
}
