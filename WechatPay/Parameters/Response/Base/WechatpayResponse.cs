using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 返回值
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayResponse
    {
        /// <summary>
        /// SUCCESS/FAIL
        /// 此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// </summary>
        [XmlElement("return_code")]
        public virtual string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息，如非空，为错误原因     
        /// 签名失败       
        /// 参数格式校验错误
        /// </summary>
        [XmlElement("return_msg")]
        public virtual string ReturnMsg { get; set; }

        /// <summary>
        /// 业务结果 SUCCESS/FAIL
        /// </summary>
        [XmlElement("result_code")]
        public virtual string ResultCode { get; set; }


        /// <summary>
        /// 调用接口提交的公众账号ID
        /// </summary>
        [XmlElement("appid")]
        public virtual string AppId { get; set; }

        /// <summary>
        /// 调用接口提交的商户号
        /// </summary>
        [XmlElement("mch_id")]
        public virtual string MchId { get; set; }

        /// <summary>
        /// 微信返回的随机字符串
        /// </summary>
        [XmlElement("nonce_str")]
        public virtual string NonceStr { get; set; }

        /// <summary>
        /// 微信返回的签名值，详见签名算法
        /// </summary>
        [XmlElement("sign")]
        public virtual string Sign { get; set; }


        /// <summary>
        /// 附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用。
        /// </summary>
        [XmlElement("attach")]
        public virtual string Attach { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 当result_code为FAIL时返回错误描述，详细参见下文错误列表
        /// </summary>
        [XmlElement("err_code_des")]
        public string ErrCodeDes { get; set; }
    }
}
