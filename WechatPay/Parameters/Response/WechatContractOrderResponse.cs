using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// 支付中签约服务
    /// </summary>
    [XmlRoot("xml")]
    public class WechatContractOrderResponse : WechatPayResponse
    {
        /// <summary>
        /// 预签约结果
        /// SUCCESS
        /// </summary>
        [XmlElement("contract_result_code")]
        public virtual string ContractResultCode { get; set; }

        /// <summary>
        /// 预签约错误代码
        /// Fail
        /// </summary>
        [XmlElement("contract_err_code")]
        public virtual string ContractErrCode { get; set; }

        /// <summary>
        /// 预签约错误描述
        /// 已签约
        /// </summary>
        [XmlElement("contract_err_code_des")]
        public virtual string ContractErrCodeDes { get; set; }

        /// <summary>
        /// 预支付交易会话标识
        /// 微信生成的预支付回话标识,用于后续接口调用中使用,该值有效期为2小时.
        /// </summary>
        [XmlElement("prepay_id")]
        public virtual string PrepayId { get; set; }

        /// <summary>
        /// 交易类型
        /// 调用接口提交的交易类型，取值如下：JSAPI,NATIVE,APP
        /// </summary>
        [XmlElement("trade_type")]
        public virtual string TradeType { get; set; }

        /// <summary>
        /// 二维码链接
        /// trade_type为NATIVE是有返回,可将该参数值生成二维码展示出来进行扫码支付
        /// </summary>
        [XmlElement("code_url")]
        public virtual string CodeUrl { get; set; }

        /// <summary>
        /// 模板id
        /// 商户在微信商户平台设置的代扣协议模板id
        /// </summary>
        [XmlElement("plan_id")]
        public virtual string PlanId { get; set; }

        /// <summary>
        /// 请求序列号 
        /// 商户请求签约时的序列号,商户侧须唯一
        /// </summary>
        [XmlElement("request_serial")]
        public virtual Int64 RequestSerial { get; set; }



        /// <summary>
        /// 签约协议号
        /// 商户请求签约时传入的签约协议号,商户侧须唯一
        /// </summary>
        [XmlElement("contract_code")]
        public virtual string ContractCode { get; set; }

        /// <summary>
        /// 用户账户展示名称         
        /// </summary>
        [XmlElement("contract_display_account")]
        public virtual string ContractDisplayAccount { get; set; }

        /// <summary>
        /// 支付跳转链接
        /// mweb_url为拉起微信支付收银台的中间页面，可通过访问该url来拉起微信客户端，完成支付,mweb_url的有效期为5分钟。
        /// </summary>
        [XmlElement("mweb_url")]
        public virtual string MWebUrl { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public virtual string OutTradeNo { get; set; }
    }
}
