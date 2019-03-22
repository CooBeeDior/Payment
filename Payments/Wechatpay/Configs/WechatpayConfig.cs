using Payments.Exceptions;
using Payments.Util;
using Payments.Util.Validations;
using Payments.Wechatpay.Enums;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Payments.Wechatpay.Configs
{
    /// <summary>
    /// 微信支付配置
    /// </summary>
    public class WechatpayConfig
    {
        /// <summary>
        /// 支付网关地址,默认为正式地址： https://api.mch.weixin.qq.com
        /// </summary>
        [Required(ErrorMessage = "支付网关地址[GatewayUrl]不能为空")]
        public string GatewayUrl { get; set; } = "https://api.mch.weixin.qq.com";

        /// <summary>
        /// 应用标识
        /// </summary>
        [Required(ErrorMessage = "应用标识[AppId]不能为空")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [Required(ErrorMessage = "商户号[MerchantId]不能为空")]
        public string MerchantId { get; set; }

        /// <summary>
        /// 应用私钥
        /// </summary>
        [Required(ErrorMessage = "应用私钥[PrivateKey]不能为空")]
        public string PrivateKey { get; set; }

        /// <summary>
        /// 证书密钥 退款，发红包等接口使用        
        /// key设置路径：微信商户平台(pay.weixin.qq.com)-->账户设置-->API安全-->密钥设置
        /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=4_3
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 签名类型，默认Md5
        /// </summary>
        public WechatpaySignType SignType { get; set; } = WechatpaySignType.Md5;

        /// <summary>
        /// 回调通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        public void Validate()
        {
            var result = DataAnnotationValidation.Validate(this);
            if (result.IsValid == false)
                throw new Warning(result.First().ErrorMessage);
        }

        /// <summary>
        /// 获取统一下单地址
        /// </summary>
        public string GetOrderUrl()
        {
            return Url.Combine(GatewayUrl, "pay/unifiedorder");
        }

        /// <summary>
        /// 付款码支付
        /// </summary>
        /// <returns></returns>
        public string GetMicroPayUrl()
        {
            return Url.Combine(GatewayUrl, "pay/micropay");
        }

        /// <summary>
        /// 撤销订单
        /// </summary>
        /// <returns></returns>
        public string GetReverseUrl()
        {
            return Url.Combine(GatewayUrl, "secapi/pay/reverse");
        }

        /// <summary>
        /// 查询订单地址
        /// </summary>
        /// <returns></returns>
        public string GetOrderQueryUrl()
        {
            return Url.Combine(GatewayUrl, "pay/orderquery");
        }
        /// <summary>
        /// 关闭订单地址
        /// </summary>
        /// <returns></returns>
        public string GetOrderCloseUrl()
        {
            return Url.Combine(GatewayUrl, "pay/closeorder");
        }
        /// <summary>
        /// 申请退款地址
        /// </summary>
        /// <returns></returns>
        public string GetOrderRefundUrl()
        {
            return Url.Combine(GatewayUrl, "secapi/pay/refund");
        }

        /// <summary>
        /// 查询退款地址
        /// </summary>
        /// <returns></returns>
        public string GetRefundQueryUrl()
        {
            return Url.Combine(GatewayUrl, "pay/refundquery");
        }
        /// <summary>
        /// 下载对账单地址
        /// </summary>
        /// <returns></returns>
        public string GetDownloadBillUrl()
        {
            return Url.Combine(GatewayUrl, "pay/downloadbill");
        }

        /// <summary>
        /// 下载资金账单
        /// </summary>
        /// <returns></returns>
        public string GetDownloadFundFlowUrl()
        {
            return Url.Combine(GatewayUrl, "pay/downloadfundflow");
        }

        /// <summary>
        /// 交易保障
        /// </summary>
        /// <returns></returns>
        public string GetReportUrl()
        {
            return Url.Combine(GatewayUrl, "payitil/report");
        }

        /// <summary>
        /// 授权码查询openid
        /// </summary>
        /// <returns></returns>
        public string GetAuthcodeToOpenidUrl()
        {
            return Url.Combine(GatewayUrl, "tools/authcodetoopenid");
        }

        /// <summary>
        /// 拉取订单评价数据
        /// </summary>
        /// <returns></returns>
        public string GetBatchQueryCommentUrl()
        {
            return Url.Combine(GatewayUrl, "billcommentsp/batchquerycomment");
        }

        /// <summary>
        /// 发放代金券
        /// </summary>
        /// <returns></returns>
        public string GetSendCouponUrl()
        {
            return Url.Combine(GatewayUrl, "mmpaymkttransfers/send_coupon");
        }

        /// <summary>
        /// 查询代金券批次
        /// </summary>
        /// <returns></returns>
        public string GetQueryCouponStockUrl()
        {
            return Url.Combine(GatewayUrl, "mmpaymkttransfers/query_coupon_stock");
        }

        /// <summary>
        /// 查询代金券信息
        /// </summary>
        /// <returns></returns>
        public string GetQueryCouponsinfoUrl()
        {
            return Url.Combine(GatewayUrl, "mmpaymkttransfers/querycouponsinfo");
        }

        /// <summary>
        /// 发放普通红包
        /// </summary>
        /// <returns></returns>
        public string GetSendRedPackUrl()
        {
            return Url.Combine(GatewayUrl, "mmpaymkttransfers/sendredpack");
        }

        /// <summary>
        /// 发放裂变红包
        /// </summary>
        /// <returns></returns>
        public string GetSendGroupredPackUrl()
        {
            return Url.Combine(GatewayUrl, "mmpaymkttransfers/sendgroupredpack");
        }

        /// <summary>
        /// 查询红包记录
        /// </summary>
        /// <returns></returns>
        public string GetGethbinfoUrl()
        {
            return Url.Combine(GatewayUrl, "mmpaymkttransfers/gethbinfo");
        }

        /// <summary>
        /// 企业付款
        /// </summary>
        /// <returns></returns>
        public string GetTransfersUrl()
        {
            return Url.Combine(GatewayUrl, "mmpaymkttransfers/promotion/transfers");
        }

        /// <summary>
        /// 查询企业付款
        /// </summary>
        /// <returns></returns>
        public string GetTransferInfoUrl()
        {
            return Url.Combine(GatewayUrl, "mmpaymkttransfers/gettransferinfo");
        }

        /// <summary>
        /// 付款码支付
        /// </summary>
        /// <returns></returns>
        public string GetBizPayUrl()
        {
            return "weixin://wxpay/bizpayurl";
        }

        /// <summary>
        /// 授权Url
        /// </summary>
        /// <returns></returns>
        public string GetAuthorizeUrl()
        {
            return "https://open.weixin.qq.com/connect/oauth2/authorize";
        }

        /// <summary>
        /// 授权access_token的Url
        /// </summary>
        /// <returns></returns>
        public string GetAccessTokenUrl()
        {
            return "https://api.weixin.qq.com/sns/oauth2/access_token";
        }

        /// <summary>
        /// 申请签约Url
        /// </summary>
        /// <returns></returns>
        public string GetEntrustWebUrl()
        {
            return "https://api.mch.weixin.qq.com/papay/entrustweb";
        }


        /// <summary>
        /// 申请签约Url
        /// </summary>
        /// <returns></returns>
        public string GetH5EntrustWebUrl()
        {
            return "https://api.mch.weixin.qq.com/papay/h5entrustweb";
        }

        /// <summary>
        /// 支付中签约api
        /// </summary>
        /// <returns></returns>
        public string GetContractOrderUrl()
        {
            return "https://api.mch.weixin.qq.com/pay/contractorder";
        }

        /// <summary>
        /// 查询签约关系
        /// </summary>
        /// <returns></returns>
        public string GetQueryContractUrl()
        {
            return "https://api.mch.weixin.qq.com/papay/querycontract";
        }

        /// <summary>
        /// 申请扣款
        /// </summary>
        /// <returns></returns>
        public string GetPapPayApplyUrl()
        {
            return "https://api.mch.weixin.qq.com/pay/pappayapply";
        }

        /// <summary>
        /// 申请解约
        /// </summary>
        /// <returns></returns>
        public string GetDeleteContractUrl()
        {
            return "https://api.mch.weixin.qq.com/papay/deletecontract";
        }


    }
}
