using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// NWeb支付
    /// </summary>
    public class WechatpayMWebPayRequest : WechatpayPayRequestBase
    {
        /// <summary>
        /// IOS移动应用{"h5_info": {"type":"IOS","app_name": "王者荣耀","bundle_id": "com.tencent.wzryIOS"}}
        /// 安卓移动应用{"h5_info": {"type":"Android","app_name": "王者荣耀","package_name": "com.tencent.tmgp.sgame"}}
        /// WAP网站应用 {"h5_info": {"type":"Wap","wap_url": "https://pay.qq.com","wap_name": "腾讯充值"}} 
        /// </summary>
        //[Required]
        [MaxLength(256)]
        public override string SceneInfo { get; set; }


        //public class 
    }
}
