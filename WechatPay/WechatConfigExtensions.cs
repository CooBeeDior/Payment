using Payments.Util;
using WechatPay.Configs;
using System;
using System.Collections.Generic;
using System.Text;
using WechatPay.Enums;
using Payments.Extensions;

namespace WechatPay
{
    public static class WechatConfigExtensions
    {
        #region WechatPaySignType
        public static WechatPaySignType? ToWechatPaySignType(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            else if (string.Compare(WechatPaySignType.HmacSha256.Description(), obj?.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
            {
                return WechatPaySignType.HmacSha256;
            }
            else if (string.Compare(WechatPaySignType.Md5.Description(), obj?.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
            {
                return WechatPaySignType.Md5;
            }
            return null;
        }
        #endregion
        /// <summary>
        /// 获取统一下单地址
        /// </summary>
        public static string GetOrderUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "pay/unifiedorder");
        }

        /// <summary>
        /// 付款码支付
        /// </summary>
        /// <returns></returns>
        public static string GetMicroPayUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "pay/micropay");
        }

        /// <summary>
        /// 撤销订单
        /// </summary>
        /// <returns></returns>
        public static string GetReverseUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "secapi/pay/reverse");
        }

        /// <summary>
        /// 查询订单地址
        /// </summary>
        /// <returns></returns>
        public static string GetOrderQueryUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "pay/orderquery");
        }
        /// <summary>
        /// 关闭订单地址
        /// </summary>
        /// <returns></returns>
        public static string GetOrderCloseUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "pay/closeorder");
        }
        /// <summary>
        /// 申请退款地址
        /// </summary>
        /// <returns></returns>
        public static string GetOrderRefundUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "secapi/pay/refund");
        }

        /// <summary>
        /// 查询退款地址
        /// </summary>
        /// <returns></returns>
        public static string GetRefundQueryUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "pay/refundquery");
        }
        /// <summary>
        /// 下载对账单地址
        /// </summary>
        /// <returns></returns>
        public static string GetDownloadBillUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "pay/downloadbill");
        }

        /// <summary>
        /// 下载资金账单
        /// </summary>
        /// <returns></returns>
        public static string GetDownloadFundFlowUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "pay/downloadfundflow");
        }

        /// <summary>
        /// 交易保障
        /// </summary>
        /// <returns></returns>
        public static string GetReportUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "payitil/report");
        }

        /// <summary>
        /// 授权码查询openid
        /// </summary>
        /// <returns></returns>
        public static string GetAuthcodeToOpenidUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "tools/authcodetoopenid");
        }

        /// <summary>
        /// 拉取订单评价数据
        /// </summary>
        /// <returns></returns>
        public static string GetBatchQueryCommentUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "billcommentsp/batchquerycomment");
        }

        /// <summary>
        /// 发放代金券
        /// </summary>
        /// <returns></returns>
        public static string GetSendCouponUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "mmpaymkttransfers/send_coupon");
        }

        /// <summary>
        /// 查询代金券批次
        /// </summary>
        /// <returns></returns>
        public static string GetQueryCouponStockUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "mmpaymkttransfers/query_coupon_stock");
        }

        /// <summary>
        /// 查询代金券信息
        /// </summary>
        /// <returns></returns>
        public static string GetQueryCouponsinfoUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "mmpaymkttransfers/querycouponsinfo");
        }

        /// <summary>
        /// 发放普通红包
        /// </summary>
        /// <returns></returns>
        public static string GetSendRedPackUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "mmpaymkttransfers/sendredpack");
        }

        /// <summary>
        /// 发放裂变红包
        /// </summary>
        /// <returns></returns>
        public static string GetSendGroupredPackUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "mmpaymkttransfers/sendgroupredpack");
        }

        /// <summary>
        /// 查询红包记录
        /// </summary>
        /// <returns></returns>
        public static string GetGethbinfoUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "mmpaymkttransfers/gethbinfo");
        }

        /// <summary>
        /// 企业付款
        /// </summary>
        /// <returns></returns>
        public static string GetTransfersUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "mmpaymkttransfers/promotion/transfers");
        }

        /// <summary>
        /// 查询企业付款
        /// </summary>
        /// <returns></returns>
        public static string GetTransferInfoUrl(this WechatPayConfig WechatPayConfig)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, "mmpaymkttransfers/gettransferinfo");
        }

        /// <summary>
        /// 付款码支付
        /// </summary>
        /// <returns></returns>
        public static string GetBizPayUrl(this WechatPayConfig WechatPayConfig)
        {
            return "weixin://wxpay/bizpayurl";
        }

        /// <summary>
        /// 授权Url
        /// </summary>
        /// <returns></returns>
        public static string GetAuthorizeUrl(this WechatPayConfig WechatPayConfig)
        {
            return "https://open.weixin.qq.com/connect/oauth2/authorize";
        }

        /// <summary>
        /// 授权access_token的Url
        /// </summary>
        /// <returns></returns>
        public static string GetAccessTokenUrl(this WechatPayConfig WechatPayConfig)
        {
            return "https://api.weixin.qq.com/sns/oauth2/access_token";
        }

        /// <summary>
        /// 申请签约Url
        /// </summary>
        /// <returns></returns>
        public static string GetEntrustWebUrl(this WechatPayConfig WechatPayConfig)
        {
            return "https://api.mch.weixin.qq.com/papay/entrustweb";
        }


        /// <summary>
        /// 申请签约Url
        /// </summary>
        /// <returns></returns>
        public static string GetH5EntrustWebUrl(this WechatPayConfig WechatPayConfig)
        {
            return "https://api.mch.weixin.qq.com/papay/h5entrustweb";
        }

        /// <summary>
        /// 支付中签约api
        /// </summary>
        /// <returns></returns>
        public static string GetContractOrderUrl(this WechatPayConfig WechatPayConfig)
        {
            return "https://api.mch.weixin.qq.com/pay/contractorder";
        }

        /// <summary>
        /// 查询签约关系
        /// </summary>
        /// <returns></returns>
        public static string GetQueryContractUrl(this WechatPayConfig WechatPayConfig)
        {
            return "https://api.mch.weixin.qq.com/papay/querycontract";
        }

        /// <summary>
        /// 申请扣款
        /// </summary>
        /// <returns></returns>
        public static string GetPapPayApplyUrl(this WechatPayConfig WechatPayConfig)
        {
            return "https://api.mch.weixin.qq.com/pay/pappayapply";
        }

        /// <summary>
        /// 查询扣款订单
        /// </summary>
        /// <returns></returns>
        public static string GetPapOrderQueryUrl(this WechatPayConfig WechatPayConfig)
        {
            return "https://api.mch.weixin.qq.com/pay/paporderquery";
        }

        /// <summary>
        /// 申请解约
        /// </summary>
        /// <returns></returns>
        public static string GetDeleteContractUrl(this WechatPayConfig WechatPayConfig)
        {
            return "https://api.mch.weixin.qq.com/papay/deletecontract";
        }


        public static string GetUrl(this WechatPayConfig WechatPayConfig, string url)
        {
            return Url.Combine(WechatPayConfig.GatewayUrl, url);
        }
    }
}
