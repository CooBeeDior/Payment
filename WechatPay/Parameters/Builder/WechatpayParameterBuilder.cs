using Microsoft.AspNetCore.Http;
using Payments.Core.Enum;
using Payments.Extensions;
using Payments.Util;
using Payments.Util.ParameterBuilders.Impl;
using Payments.Util.Signatures;
using System;
using System.Xml;
using WechatPay.Configs;
using WechatPay.Enums;
using static WechatPay.Parameters.Requests.WechatPayPayRequestBase;

namespace WechatPay.Parameters
{
    /// <summary>
    /// 微信支付参数生成器
    /// </summary>
    public class WechatPayParameterBuilder
    {
        /// <summary>
        /// 参数生成器
        /// </summary>
        protected readonly ParameterBuilder Builder;

        /// <summary>
        /// 配置
        /// </summary>
        public WechatPayConfig Config { get; }
        public HttpRequest Request { get; }
        /// <summary>
        /// 初始化微信支付参数生成器
        /// </summary>
        /// <param name="config">配置</param>
        public WechatPayParameterBuilder(WechatPayConfig config, HttpRequest httpRequest = null)
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
                .NonceStr(Id.GetId());
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        public WechatPayParameterBuilder Add(string name, object value)
        {
            Builder.Add(name, value);
            return this;
        }
        /// <summary>
        /// 移除参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns></returns>
        public WechatPayParameterBuilder Remove(string name)
        {
            Builder.Remove(name);
            return this;
        }

        /// <summary>
        /// 设置应用标识
        /// </summary>
        /// <param name="appId">应用标识</param>
        public WechatPayParameterBuilder AppId(string appId)
        {
            Builder.Add(WechatPayConst.AppId, appId);
            return this;
        }

        /// <summary>
        /// 设置商户号
        /// </summary>
        /// <param name="merchantId">商户号</param>
        public WechatPayParameterBuilder MerchantId(string merchantId)
        {
            Builder.Add(WechatPayConst.MerchantId, merchantId);
            return this;
        }

        /// <summary>
        /// 添加随机数
        /// </summary>
        /// <param name="nonceStr"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder NonceStr(string nonceStr)
        {
            Builder.Add(WechatPayConst.NonceStr, nonceStr);
            return this;
        }

        /// <summary>
        /// 预支付Id
        /// </summary>
        /// <param name="prepayId"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder PrepayId(string prepayId)
        {
            Builder.Add(WechatPayConst.PrepayId, prepayId);
            return this;
        }
        /// <summary>
        /// 返回码
        /// </summary>
        /// <param name="returnCode"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder ReturnCode(string returnCode)
        {
            Builder.Add(WechatPayConst.ReturnCode, returnCode);
            return this;
        }
        /// <summary>
        /// 结果码
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder ResultCode(string resultCode)
        {
            Builder.Add(WechatPayConst.ResultCode, resultCode);
            return this;
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="body">标题</param>
        public WechatPayParameterBuilder Body(string body)
        {
            Builder.Add(WechatPayConst.Body, body);
            return this;
        }

        /// <summary>
        /// 设置商户订单号
        /// </summary>
        /// <param name="outTradeNo">商户订单号</param>
        public WechatPayParameterBuilder OutTradeNo(string outTradeNo)
        {
            Builder.Add(WechatPayConst.OutTradeNo, outTradeNo);
            return this;
        }
        /// <summary>
        /// 微信退款单号
        /// </summary>
        /// <param name="refundId"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder RefundId(string refundId)
        {
            Builder.Add(WechatPayConst.RefundId, refundId);
            return this;
        }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        /// <param name="outRefundNo"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder OutRefundNo(string outRefundNo)
        {
            Builder.Add(WechatPayConst.OutRefundNo, outRefundNo);
            return this;
        }
        /// <summary>
        /// 微信订单号
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder TransactionId(string transactionId)
        {
            Builder.Add(WechatPayConst.TransactionId, transactionId);
            return this;
        }

        /// <summary>
        /// 订单优惠标记
        /// </summary>
        /// <param name="goodsTag"> </param>
        public WechatPayParameterBuilder GoodsTag(string goodsTag)
        {
            Builder.Add(WechatPayConst.GoodsTag, goodsTag);
            return this;
        }
        /// <summary>
        /// 指定支付方式
        /// </summary>
        /// <param name="limitPay"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder LimitPay(string limitPay)
        {
            Builder.Add(WechatPayConst.LimitPay, limitPay);
            return this;
        }


        /// <summary>
        /// 商品ID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder ProductId(string productId)
        {
            Builder.Add(WechatPayConst.ProductId, productId);
            return this;
        }

        /// <summary>
        /// 退款货币种类     
        /// </summary>
        /// <param name="refundFeeType"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder RefundFeeType(FeeType? refundFeeType)
        {
            Builder.Add(WechatPayConst.RefundFeeType, refundFeeType?.ToString());
            return this;
        }
        /// <summary>
        /// 设置总金额
        /// </summary>
        /// <param name="totalFee">总金额，单位：分</param>
        public WechatPayParameterBuilder TotalFee(decimal totalFee)
        {
            Builder.Add(WechatPayConst.TotalFee, (totalFee * 100).ToInt());
            return this;
        }
        /// <summary>
        /// 商品详细描述
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder Detail(GoodsDetail detail)
        {
            Builder.Add(WechatPayConst.Detail, detail?.ToJson());
            return this;
        }
        /// <summary>
        /// 商品详细描述
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder Detail(string detail)
        {
            Builder.Add(WechatPayConst.Detail, detail);
            return this;
        }
        public WechatPayParameterBuilder SceneInfo(string sceneInfo)
        {
            Builder.Add(WechatPayConst.SceneInfo, sceneInfo);
            return this;
        }
        public WechatPayParameterBuilder ProfitSharing(string profitSharing)
        {
            Builder.Add(WechatPayConst.ProfitSharing, profitSharing);
            return this;
        }


        /// <summary>
        /// 货币类型
        /// </summary>
        /// <param name="feeType"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder FeeType(FeeType? feeType)
        {
            Builder.Add(WechatPayConst.FeeType, feeType?.ToString());
            return this;
        }
        /// <summary>
        /// 交易起始时间
        /// </summary>
        /// <param name="timeStart"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder TimeStart(DateTime? timeStart)
        {
            Builder.Add(WechatPayConst.TimeStart, timeStart.HasValue ? timeStart.Value.ToString("yyyyMMddHHmmss") : null);
            return this;
        }
        /// <summary>
        /// 交易结束时间
        /// </summary>
        /// <param name="timeExpire"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder TimeExpire(DateTime? timeExpire)
        {
            Builder.Add(WechatPayConst.TimeExpire, timeExpire.HasValue ? timeExpire.Value.ToString("yyyyMMddHHmmss") : null);
            return this;
        }

        public WechatPayParameterBuilder RefundFee(decimal totalFee)
        {
            Builder.Add(WechatPayConst.RefundFee, (totalFee * 100).ToInt());
            return this;
        }

        /// <summary>
        /// 设置回调通知地址
        /// </summary>
        /// <param name="notifyUrl">回调通知地址</param>
        public WechatPayParameterBuilder NotifyUrl(string notifyUrl)
        {
            Builder.Add(WechatPayConst.NotifyUrl, GetNotifyUrl(notifyUrl));
            return this;
        }

        /// <summary>
        /// 退款资金来源
        /// </summary>
        /// <param name="refundAccount"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder RefundAccount(string refundAccount)
        {
            Builder.Add(WechatPayConst.RefundAccount, refundAccount);
            return this;
        }

        /// <summary>
        /// 对账单日期 下载对账单的日期，格式：20140603
        /// </summary>
        /// <param name="billDate"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder BillDate(string billDate)
        {
            Builder.Add(WechatPayConst.BillDate, billDate);
            return this;
        }
        /// <summary>
        /// 账单类型     	
        /// ALL（默认值），返回当日所有订单信息（不含充值退款订单）
        /// SUCCESS，返回当日成功支付的订单（不含充值退款订单）
        /// REFUND，返回当日退款订单（不含充值退款订单）
        /// RECHARGE_REFUND，返回当日充值退款订单
        /// </summary>
        /// <param name="billType"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder BillType(string billType)
        {
            Builder.Add(WechatPayConst.BillType, billType);
            return this;
        }
        /// <summary>
        /// 压缩账单
        /// 非必传参数，固定值：GZIP，返回格式为.gzip的压缩包账单。不传则默认为数据流形式。
        /// </summary>
        /// <param name="tarType"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder TarType(string tarType)
        {
            Builder.Add(WechatPayConst.TarType, tarType);
            return this;
        }
        /// <summary>
        /// 资金账户类型
        /// 账单的资金来源账户：
        /// Basic 基本账户
        /// Operation 运营账户
        /// Fees 手续费账户
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder AccountType(string accountType)
        {
            Builder.Add(WechatPayConst.AccountType, accountType);
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
        public WechatPayParameterBuilder SpbillCreateIp(string ip)
        {
            Builder.Add(WechatPayConst.SpbillCreateIp, ip);
            return this;
        }

        /// <summary>
        /// 设置交易类型
        /// </summary>
        /// <param name="type">交易类型</param>
        public WechatPayParameterBuilder TradeType(string type)
        {
            Builder.Add(WechatPayConst.TradeType, type);
            return this;
        }
        /// <summary>
        /// 设备号
        /// 自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"
        /// </summary>
        /// <param name="deviceInfo"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder DeviceInfo(string deviceInfo)
        {
            Builder.Add(WechatPayConst.DeviceInfo, deviceInfo);
            return this;
        }
        /// <summary>
        /// 设置签名类型
        /// </summary>
        /// <param name="type">签名类型</param>
        public WechatPayParameterBuilder SignType(string type)
        {
            Builder.Add(WechatPayConst.SignType, type);
            return this;
        }
        public WechatPayParameterBuilder PartnerId(string partnerId)
        {
            Builder.Add(WechatPayConst.PartnerId, partnerId);
            return this;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder BeginTime(string beginTime)
        {
            Builder.Add(WechatPayConst.BeginTime, beginTime);
            return this;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <param name="partnerId">伙伴标识</param>
        public WechatPayParameterBuilder EndTime(string endTime)
        {
            Builder.Add(WechatPayConst.EndTime, endTime);
            return this;
        }
        /// <summary>
        /// 位移
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder Offset(string offset)
        {
            Builder.Add(WechatPayConst.Offset, offset);
            return this;
        }
        /// <summary>
        /// 条数
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder Limit(string limit)
        {
            Builder.Add(WechatPayConst.Limit, limit);
            return this;
        }

        /// <summary>
        /// 设置时间戳
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        public WechatPayParameterBuilder Timestamp(long timestamp = 0)
        {
            Builder.Add(WechatPayConst.Timestamp, timestamp == 0 ? DateTime.Now.GetUnixTimestamp() : timestamp);
            return this;
        }

        /// <summary>
        /// 设置包
        /// </summary>
        /// <param name="package">包，默认值: "Sign=WXPay"</param>
        public WechatPayParameterBuilder Package(string package = "Sign=WXPay")
        {
            Builder.Add(WechatPayConst.Package, package);
            return this;
        }

        /// <summary>
        /// 设置附加数据
        /// </summary>
        /// <param name="attach">附加数据</param>
        public WechatPayParameterBuilder Attach(string attach)
        {
            Builder.Add(WechatPayConst.Attach, attach);
            return this;
        }

        /// <summary>
        /// 设置用户标识
        /// </summary>
        /// <param name="openId">用户标识</param>
        public WechatPayParameterBuilder OpenId(string openId)
        {
            Builder.Add(WechatPayConst.OpenId, openId);
            return this;
        }

        /// <summary>
        /// 扫码支付授权码，设备读取用户微信中的条码或者二维码信息
        /// </summary>
        /// <param name="authCode"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder AuthCode(string authCode)
        {
            Builder.Add(WechatPayConst.AuthCode, authCode);
            return this;
        }
        /// <summary>
        /// 偏移量，当部分退款次数超过10次时可使用，表示返回的查询结果从这个偏移量开始取记录
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder Offset(int? offset)
        {
            Builder.Add(WechatPayConst.Offset, offset);
            return this;
        }
        /// <summary>
        /// 电子发票入口开放标识 Y，传入Y时，支付成功消息和支付详情页将出现开票入口
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        public WechatPayParameterBuilder Receipt(string receipt)
        {
            Builder.Add(WechatPayConst.Receipt, receipt);
            return this;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object Get(string name)
        {
            return Builder.GetValue(name);
        }
        /// <summary>
        /// 获取Xml结果，包含签名
        /// </summary>
        public string ToXml(bool isSign = true, PaySignType? signType = null)
        {
            return ToXmlDocument(GetSignBuilder(isSign, signType)).OuterXml;
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
            if (key.SafeString().ToLower() == WechatPayConst.TotalFee)
            {
                xml.AddNode(key, value);
                return;
            }
            xml.AddCDataNode(value, key);
        }

        /// <summary>
        /// 获取签名的参数生成器
        /// </summary>
        protected virtual ParameterBuilder GetSignBuilder(bool isSign = true, PaySignType? signType = null)
        {
            var builder = new ParameterBuilder(Builder);
            if (isSign)
            {
                Builder.Add(WechatPayConst.Sign, GetSign(signType));
            }
            return Builder;
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        public string GetSign(PaySignType? signType = null)
        {
            return SignManagerFactory.Create(Config, Request, Builder, signType).Sign();
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
        public string ToJson(bool isSign = true, PaySignType? signType = null)
        {
            return GetSignBuilder(isSign, signType).ToJson();
        }

        /// <summary>
        /// 转换成Url
        /// </summary>
        /// <returns></returns>
        public string ToUrl(bool isSign = true, PaySignType? signType = null)
        {
            return GetSignBuilder(isSign, signType).ToUrl();
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