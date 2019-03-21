using Microsoft.AspNetCore.Http;
using Payments.Extensions;
using Payments.Util;
using Payments.Util.Http;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Enums;
using Payments.Wechatpay.Signatures;
using System;
using System.Xml;
using static Payments.Wechatpay.Parameters.Requests.WechatpayPayRequestBase;

namespace Payments.Wechatpay.Parameters
{
    /// <summary>
    /// 微信支付参数生成器
    /// </summary>
    public class WechatpayParameterBuilder
    {
        /// <summary>
        /// 参数生成器
        /// </summary>
        protected readonly ParameterBuilder Builder;

        /// <summary>
        /// 配置
        /// </summary>
        public WechatpayConfig Config { get; }
        public HttpRequest Request { get; }
        /// <summary>
        /// 初始化微信支付参数生成器
        /// </summary>
        /// <param name="config">配置</param>
        public WechatpayParameterBuilder(WechatpayConfig config, HttpRequest httpRequest = null)
        {
            config.CheckNull(nameof(config));
            Config = config;
            Builder = new ParameterBuilder();
            Request = httpRequest;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            AppId(Config.AppId).MerchantId(Config.MerchantId).SignType(Config.SignType.Description())
                .NonceStr(Id.GetId()).SpbillCreateIp(Server.GetLanIp());
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        public WechatpayParameterBuilder Add(string name, object value)
        {
            Builder.Add(name, value);
            return this;
        }
        /// <summary>
        /// 移除参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns></returns>
        public WechatpayParameterBuilder Remove(string name)
        {
            Builder.Remove(name);
            return this;
        }

        /// <summary>
        /// 设置应用标识
        /// </summary>
        /// <param name="appId">应用标识</param>
        public WechatpayParameterBuilder AppId(string appId)
        {
            Builder.Add(WechatpayConst.AppId, appId);
            return this;
        }

        /// <summary>
        /// 设置商户号
        /// </summary>
        /// <param name="merchantId">商户号</param>
        public WechatpayParameterBuilder MerchantId(string merchantId)
        {
            Builder.Add(WechatpayConst.MerchantId, merchantId);
            return this;
        }

        /// <summary>
        /// 添加随机数
        /// </summary>
        /// <param name="nonceStr"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder NonceStr(string nonceStr)
        {
            Builder.Add(WechatpayConst.NonceStr, nonceStr);
            return this;
        }

        /// <summary>
        /// 预支付Id
        /// </summary>
        /// <param name="prepayId"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder PrepayId(string prepayId)
        {
            Builder.Add(WechatpayConst.PrepayId, prepayId);
            return this;
        }
        /// <summary>
        /// 返回码
        /// </summary>
        /// <param name="returnCode"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder ReturnCode(string returnCode)
        {
            Builder.Add(WechatpayConst.ReturnCode, returnCode);
            return this;
        }
        /// <summary>
        /// 结果码
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder ResultCode(string resultCode)
        {
            Builder.Add(WechatpayConst.ResultCode, resultCode);
            return this;
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="body">标题</param>
        public WechatpayParameterBuilder Body(string body)
        {
            Builder.Add(WechatpayConst.Body, body);
            return this;
        }

        /// <summary>
        /// 设置商户订单号
        /// </summary>
        /// <param name="outTradeNo">商户订单号</param>
        public WechatpayParameterBuilder OutTradeNo(string outTradeNo)
        {
            Builder.Add(WechatpayConst.OutTradeNo, outTradeNo);
            return this;
        }
        /// <summary>
        /// 微信退款单号
        /// </summary>
        /// <param name="refundId"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder RefundId(string refundId)
        {
            Builder.Add(WechatpayConst.RefundId, refundId);
            return this;
        }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        /// <param name="outRefundNo"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder OutRefundNo(string outRefundNo)
        {
            Builder.Add(WechatpayConst.OutRefundNo, outRefundNo);
            return this;
        }
        /// <summary>
        /// 微信订单号
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder TransactionId(string transactionId)
        {
            Builder.Add(WechatpayConst.TransactionId, transactionId);
            return this;
        }

        /// <summary>
        /// 订单优惠标记
        /// </summary>
        /// <param name="goodsTag"> </param>
        public WechatpayParameterBuilder GoodsTag(string goodsTag)
        {
            Builder.Add(WechatpayConst.GoodsTag, goodsTag);
            return this;
        }
        /// <summary>
        /// 指定支付方式
        /// </summary>
        /// <param name="limitPay"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder LimitPay(string limitPay)
        {
            Builder.Add(WechatpayConst.LimitPay, limitPay);
            return this;
        }


        /// <summary>
        /// 商品ID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder ProductId(string productId)
        {
            Builder.Add(WechatpayConst.ProductId, productId);
            return this;
        }

        /// <summary>
        /// 退款货币种类     
        /// </summary>
        /// <param name="refundFeeType"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder RefundFeeType(FeeType? refundFeeType)
        {
            Builder.Add(WechatpayConst.RefundFeeType, refundFeeType?.ToString());
            return this;
        }
        /// <summary>
        /// 设置总金额
        /// </summary>
        /// <param name="totalFee">总金额，单位：分</param>
        public WechatpayParameterBuilder TotalFee(decimal totalFee)
        {
            Builder.Add(WechatpayConst.TotalFee, (totalFee * 100).ToInt());
            return this;
        }
        /// <summary>
        /// 商品详细描述
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder Detail(GoodsDetail detail)
        {
            Builder.Add(WechatpayConst.Detail, detail?.ToJson());
            return this;
        }
        public WechatpayParameterBuilder SceneInfo(string sceneInfo)
        {
            Builder.Add(WechatpayConst.SceneInfo, sceneInfo);
            return this;
        }
        /// <summary>
        /// 货币类型
        /// </summary>
        /// <param name="feeType"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder FeeType(FeeType? feeType)
        {
            Builder.Add(WechatpayConst.FeeType, feeType?.ToString());
            return this;
        }
        /// <summary>
        /// 交易起始时间
        /// </summary>
        /// <param name="timeStart"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder TimeStart(DateTime? timeStart)
        {
            Builder.Add(WechatpayConst.TimeStart, timeStart.HasValue ? timeStart.Value.ToString("yyyyMMddHHmmss") : null);
            return this;
        }
        /// <summary>
        /// 交易结束时间
        /// </summary>
        /// <param name="timeExpire"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder TimeExpire(DateTime? timeExpire)
        {
            Builder.Add(WechatpayConst.TimeExpire, timeExpire.HasValue ? timeExpire.Value.ToString("yyyyMMddHHmmss") : null);
            return this;
        }

        public WechatpayParameterBuilder RefundFee(decimal totalFee)
        {
            Builder.Add(WechatpayConst.RefundFee, (totalFee * 100).ToInt());
            return this;
        }

        /// <summary>
        /// 设置回调通知地址
        /// </summary>
        /// <param name="notifyUrl">回调通知地址</param>
        public WechatpayParameterBuilder NotifyUrl(string notifyUrl)
        {
            Builder.Add(WechatpayConst.NotifyUrl, GetNotifyUrl(notifyUrl));
            return this;
        }

        /// <summary>
        /// 退款资金来源
        /// </summary>
        /// <param name="refundAccount"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder RefundAccount(string refundAccount)
        {
            Builder.Add(WechatpayConst.RefundAccount, refundAccount);
            return this;
        }


        /// <summary>
        /// 获取回调通知地址
        /// </summary>
        private string GetNotifyUrl(string notifyUrl)
        {
            if (notifyUrl.IsEmpty())
                return Config.NotifyUrl;
            return notifyUrl;
        }

        /// <summary>
        /// 设置终端IP
        /// </summary>
        /// <param name="ip">终端IP</param>
        public WechatpayParameterBuilder SpbillCreateIp(string ip)
        {
            Builder.Add(WechatpayConst.SpbillCreateIp, ip);
            return this;
        }

        /// <summary>
        /// 设置交易类型
        /// </summary>
        /// <param name="type">交易类型</param>
        public WechatpayParameterBuilder TradeType(string type)
        {
            Builder.Add(WechatpayConst.TradeType, type);
            return this;
        }

        /// <summary>
        /// 设置签名类型
        /// </summary>
        /// <param name="type">签名类型</param>
        public WechatpayParameterBuilder SignType(string type)
        {
            Builder.Add(WechatpayConst.SignType, type);
            return this;
        }

        /// <summary>
        /// 设置伙伴标识
        /// </summary>
        /// <param name="partnerId">伙伴标识</param>
        public WechatpayParameterBuilder PartnerId(string partnerId)
        {
            Builder.Add(WechatpayConst.PartnerId, partnerId);
            return this;
        }

        /// <summary>
        /// 设置时间戳
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        public WechatpayParameterBuilder Timestamp(long timestamp = 0)
        {
            Builder.Add(WechatpayConst.Timestamp, timestamp == 0 ? DateTime.Now.GetUnixTimestamp() : timestamp);
            return this;
        }

        /// <summary>
        /// 设置包
        /// </summary>
        /// <param name="package">包，默认值: "Sign=WXPay"</param>
        public WechatpayParameterBuilder Package(string package = "Sign=WXPay")
        {
            Builder.Add(WechatpayConst.Package, package);
            return this;
        }

        /// <summary>
        /// 设置附加数据
        /// </summary>
        /// <param name="attach">附加数据</param>
        public WechatpayParameterBuilder Attach(string attach)
        {
            Builder.Add(WechatpayConst.Attach, attach);
            return this;
        }

        /// <summary>
        /// 设置用户标识
        /// </summary>
        /// <param name="openId">用户标识</param>
        public WechatpayParameterBuilder OpenId(string openId)
        {
            Builder.Add(WechatpayConst.OpenId, openId);
            return this;
        }

        /// <summary>
        /// 扫码支付授权码，设备读取用户微信中的条码或者二维码信息
        /// </summary>
        /// <param name="authCode"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder AuthCode(string authCode)
        {
            Builder.Add(WechatpayConst.AuthCode, authCode);
            return this;
        }
        /// <summary>
        /// 偏移量，当部分退款次数超过10次时可使用，表示返回的查询结果从这个偏移量开始取记录
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder Offset(int? offset)
        {
            Builder.Add(WechatpayConst.Offset, offset);
            return this;
        }
        /// <summary>
        /// 电子发票入口开放标识 Y，传入Y时，支付成功消息和支付详情页将出现开票入口
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder Receipt(string receipt)
        {
            Builder.Add(WechatpayConst.Receipt, receipt);
            return this;
        }

        /// <summary>
        /// 获取Xml结果，包含签名
        /// </summary>
        public string ToXml(bool isSign = true)
        {
            return ToXmlDocument(GetSignBuilder(isSign)).OuterXml;
        }

        /// <summary>
        /// 获取Xml文档
        /// </summary>
        private XmlDocument ToXmlDocument(ParameterBuilder Builder)
        {
            var xml = new Xml();
            foreach (var param in Builder.GetDictionary())
                AddNode(xml, param.Key, param.Value);
            return xml.Document;
        }

        /// <summary>
        /// 添加Xml节点
        /// </summary>
        private void AddNode(Xml xml, string key, object value)
        {
            if (key.SafeString().ToLower() == WechatpayConst.TotalFee)
            {
                xml.AddNode(key, value);
                return;
            }
            xml.AddCDataNode(value, key);
        }

        /// <summary>
        /// 获取签名的参数生成器
        /// </summary>
        protected virtual ParameterBuilder GetSignBuilder(bool isSign = true)
        {
            var builder = new ParameterBuilder(Builder);
            if (isSign)
            {
                Builder.Add(WechatpayConst.Sign, GetSign());
            }           
            return Builder;
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        public string GetSign()
        {
            return SignManagerFactory.Create(Config, Request, Builder).Sign();
        }

        /// <summary>
        /// 获取Xml结果，不包含签名
        /// </summary>
        public string ToXmlNoContainsSign()
        {
            return ToXmlDocument(Builder).OuterXml;
        }

        /// <summary>
        /// 获取Json结果，包含签名
        /// </summary>
        public string ToJson(bool isSign = true)
        {
            return GetSignBuilder(isSign).ToJson();
        }

        /// <summary>
        /// 转换成Url
        /// </summary>
        /// <returns></returns>
        public string ToUrl(bool isSign = true)
        {
            return GetSignBuilder(isSign).ToUrl();
        }

        /// <summary>
        /// 输出结果
        /// </summary>
        public override string ToString()
        {
            return ToXml();
        }
    }
}