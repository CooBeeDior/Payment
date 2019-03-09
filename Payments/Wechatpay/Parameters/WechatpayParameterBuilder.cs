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
        private readonly ParameterBuilder _builder;

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
            _builder = new ParameterBuilder();
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
        public WechatpayParameterBuilder Add(string name, string value)
        {
            _builder.Add(name, value);
            return this;
        }
        /// <summary>
        /// 移除参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns></returns>
        public WechatpayParameterBuilder Remove(string name)
        {
            _builder.Remove(name);
            return this;
        }

        /// <summary>
        /// 设置应用标识
        /// </summary>
        /// <param name="appId">应用标识</param>
        public WechatpayParameterBuilder AppId(string appId)
        {
            _builder.Add(WechatpayConst.AppId, appId);
            return this;
        }

        /// <summary>
        /// 设置商户号
        /// </summary>
        /// <param name="merchantId">商户号</param>
        public WechatpayParameterBuilder MerchantId(string merchantId)
        {
            _builder.Add(WechatpayConst.MerchantId, merchantId);
            return this;
        }

        /// <summary>
        /// 添加随机数
        /// </summary>
        /// <param name="nonceStr"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder NonceStr(string nonceStr)
        {
            _builder.Add(WechatpayConst.NonceStr, nonceStr);
            return this;
        }

        /// <summary>
        /// 预支付Id
        /// </summary>
        /// <param name="prepayId"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder PrepayId(string prepayId)
        {
            _builder.Add(WechatpayConst.PrepayId, prepayId);
            return this;
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="body">标题</param>
        public WechatpayParameterBuilder Body(string body)
        {
            _builder.Add(WechatpayConst.Body, body);
            return this;
        }

        /// <summary>
        /// 设置商户订单号
        /// </summary>
        /// <param name="outTradeNo">商户订单号</param>
        public WechatpayParameterBuilder OutTradeNo(string outTradeNo)
        {
            _builder.Add(WechatpayConst.OutTradeNo, outTradeNo);
            return this;
        }

        /// <summary>
        /// 微信订单号
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder TransactionId(string transactionId)
        {
            _builder.Add(WechatpayConst.TransactionId, transactionId);
            return this;
        }

        /// <summary>
        /// 订单优惠标记
        /// </summary>
        /// <param name="feeType">货币类型</param>
        public WechatpayParameterBuilder GoodsTag(string goodsTag)
        {
            _builder.Add(WechatpayConst.GoodsTag, goodsTag);
            return this;
        }
        /// <summary>
        /// 指定支付方式
        /// </summary>
        /// <param name="limitPay"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder LimitPay(string limitPay)
        {
            _builder.Add(WechatpayConst.LimitPay, limitPay);
            return this;
        }


        /// <summary>
        /// 商品ID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder ProductId(string productId)
        {
            _builder.Add(WechatpayConst.ProductId, productId);
            return this;
        }

        /// <summary>
        /// 设置总金额
        /// </summary>
        /// <param name="totalFee">总金额，单位：分</param>
        public WechatpayParameterBuilder TotalFee(decimal totalFee)
        {
            _builder.Add(WechatpayConst.TotalFee, (totalFee * 100).ToInt());
            return this;
        }
        /// <summary>
        /// 商品详细描述
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder Detail(GoodsDetail detail)
        {
            _builder.Add(WechatpayConst.Detail, detail?.ToJson());
            return this;
        }
        public WechatpayParameterBuilder SceneInfo(SotreSceneInfo sceneInfo)
        {
            _builder.Add(WechatpayConst.SceneInfo, sceneInfo?.ToJson());
            return this;
        }
        /// <summary>
        /// 货币类型
        /// </summary>
        /// <param name="feeType"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder FeeType(FeeType? feeType)
        {
            _builder.Add(WechatpayConst.FeeType, feeType?.ToString());
            return this;
        }
        /// <summary>
        /// 交易起始时间
        /// </summary>
        /// <param name="timeStart"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder TimeStart(DateTime? timeStart)
        {
            _builder.Add(WechatpayConst.TimeStart, timeStart.HasValue ? timeStart.Value.ToString("yyyyMMddHHmmss") : null);
            return this;
        }
        /// <summary>
        /// 交易结束时间
        /// </summary>
        /// <param name="timeExpire"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder TimeExpire(DateTime? timeExpire)
        {
            _builder.Add(WechatpayConst.TimeExpire, timeExpire.HasValue ? timeExpire.Value.ToString("yyyyMMddHHmmss") : null);
            return this;
        }

        public WechatpayParameterBuilder RefundFee(decimal totalFee)
        {
            _builder.Add(WechatpayConst.RefundFee, (totalFee * 100).ToInt());
            return this;
        }

        /// <summary>
        /// 设置回调通知地址
        /// </summary>
        /// <param name="notifyUrl">回调通知地址</param>
        public WechatpayParameterBuilder NotifyUrl(string notifyUrl)
        {
            _builder.Add(WechatpayConst.NotifyUrl, GetNotifyUrl(notifyUrl));
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
            _builder.Add(WechatpayConst.SpbillCreateIp, ip);
            return this;
        }

        /// <summary>
        /// 设置交易类型
        /// </summary>
        /// <param name="type">交易类型</param>
        public WechatpayParameterBuilder TradeType(string type)
        {
            _builder.Add(WechatpayConst.TradeType, type);
            return this;
        }

        /// <summary>
        /// 设置签名类型
        /// </summary>
        /// <param name="type">签名类型</param>
        public WechatpayParameterBuilder SignType(string type)
        {
            _builder.Add(WechatpayConst.SignType, type);
            return this;
        }

        /// <summary>
        /// 设置伙伴标识
        /// </summary>
        /// <param name="partnerId">伙伴标识</param>
        public WechatpayParameterBuilder PartnerId(string partnerId)
        {
            _builder.Add(WechatpayConst.PartnerId, partnerId);
            return this;
        }

        /// <summary>
        /// 设置时间戳
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        public WechatpayParameterBuilder Timestamp(long timestamp = 0)
        {
            _builder.Add(WechatpayConst.Timestamp, timestamp == 0 ? DateTime.Now.GetUnixTimestamp() : timestamp);
            return this;
        }

        /// <summary>
        /// 设置包
        /// </summary>
        /// <param name="package">包，默认值: "Sign=WXPay"</param>
        public WechatpayParameterBuilder Package(string package = "Sign=WXPay")
        {
            _builder.Add(WechatpayConst.Package, package);
            return this;
        }

        /// <summary>
        /// 设置附加数据
        /// </summary>
        /// <param name="attach">附加数据</param>
        public WechatpayParameterBuilder Attach(string attach)
        {
            _builder.Add(WechatpayConst.Attach, attach);
            return this;
        }

        /// <summary>
        /// 设置用户标识
        /// </summary>
        /// <param name="openId">用户标识</param>
        public WechatpayParameterBuilder OpenId(string openId)
        {
            _builder.Add(WechatpayConst.OpenId, openId);
            return this;
        }
        /// <summary>
        /// 电子发票入口开放标识 Y，传入Y时，支付成功消息和支付详情页将出现开票入口
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        public WechatpayParameterBuilder Receipt(string receipt)
        {
            _builder.Add(WechatpayConst.Receipt, receipt);
            return this;
        }

        /// <summary>
        /// 获取Xml结果，包含签名
        /// </summary>
        public string ToXml()
        {
            return ToXmlDocument(GetSignBuilder()).OuterXml;
        }

        /// <summary>
        /// 获取Xml文档
        /// </summary>
        private XmlDocument ToXmlDocument(ParameterBuilder builder)
        {
            var xml = new Xml();
            foreach (var param in builder.GetDictionary())
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
        private ParameterBuilder GetSignBuilder()
        {
            var builder = new ParameterBuilder(_builder);
            builder.Add(WechatpayConst.Sign, GetSign());
            return builder;
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        public string GetSign()
        {
            return SignManagerFactory.Create(Config, Request, _builder).Sign();
        }

        /// <summary>
        /// 获取Xml结果，不包含签名
        /// </summary>
        public string ToXmlNoContainsSign()
        {
            return ToXmlDocument(_builder).OuterXml;
        }

        /// <summary>
        /// 获取Json结果，包含签名
        /// </summary>
        public string ToJson()
        {
            return GetSignBuilder().ToJson();
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