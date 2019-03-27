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
    /// 公众号APP申请签约
    /// </summary>
    public class WechatEntrustWebRequest : Validation, IWechatpayRequest, IValidation
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
        /// 3表示返回app, 不填则不返回 注：签约参数appid必须为发起签约的app所有，且在微信开放平台注册过。
        /// 1- 默认返回模式为关闭当前页面
        /// 2- 优先级: return_app>return_web
        /// 3- 下面参数不传或无效则默认关闭当前页面
        /// </summary>
        public int ReturnApp { get; set; }

        /// <summary>
        /// 1表示返回签约页面的referrer url, 不填或获取不到referrer则不返回; 跳转referrer url时会自动带上参数from_wxpay=1
        /// 1- 默认返回模式为关闭当前页面
        /// 2- 优先级: return_app>return_web
        /// 3- 下面参数不传或无效则默认关闭当前页面
        /// </summary>
        public int ReturnWeb { get; set; }
    }
}
