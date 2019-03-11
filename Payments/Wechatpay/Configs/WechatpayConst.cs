namespace Payments.Wechatpay.Configs
{
    /// <summary>
    /// 微信支付常量
    /// </summary>
    public static class WechatpayConst
    {
        /// <summary>
        /// 微信支付跟踪日志名
        /// </summary>
        public const string TraceLogName = "WechatpayTraceLog";
        /// <summary>
        /// 应用标识
        /// </summary>
        public const string AppId = "appid";
        /// <summary>
        /// 商户号
        /// </summary>
        public const string MerchantId = "mch_id";
        /// <summary>
        /// 标题
        /// </summary>
        public const string Body = "body";
        /// <summary>
        /// 商户订单号
        /// </summary>
        public const string OutTradeNo = "out_trade_no";
        /// <summary>
        /// 微信支付订单号
        /// </summary>
        public const string TransactionId = "transaction_id";
        /// <summary>
        /// 预支付Id
        /// </summary>
        public const string PrepayId = "prepay_id";
        /// <summary>
        /// nonce_str
        /// </summary>
        public const string NonceStr = "nonce_str";
        /// <summary>
        /// 货币类型
        /// </summary>
        public const string FeeType = "fee_type";
        /// <summary>
        /// 总金额
        /// </summary>
        public const string TotalFee = "total_fee";

        /// <summary>
        /// 微信退款单号
        /// </summary>
        public const string RefundId = "refund_id";
        /// <summary>
        /// 退款金额
        /// </summary>
        public const string RefundFee = "refund_fee";

        /// <summary>
        /// 退款金额
        /// </summary>
        public const string SettlementRefundFee = "settlement_refund_fee";

        /// <summary>
        /// 退款金额
        /// </summary>
        public const string SettlementTotalFee = "settlement_refund_fee";

        /// <summary>
        /// 回调通知Url
        /// </summary>
        public const string NotifyUrl = "notify_url";
        /// <summary>
        /// 终端IP
        /// </summary>
        public const string SpbillCreateIp = "spbill_create_ip";
        /// <summary>
        /// 交易类型
        /// </summary>
        public const string TradeType = "trade_type";
        /// <summary>
        /// 商品详情
        /// </summary>
        public const string Detail = "detail";
        /// <summary>
        /// 签名类型
        /// </summary>
        public const string SignType = "sign_type";
        /// <summary>
        /// 签名
        /// </summary>
        public const string Sign = "sign";
        /// <summary>
        /// 成功
        /// </summary>
        public const string Success = "SUCCESS";
        /// <summary>
        /// 失败
        /// </summary>
        public const string Fail = "FAIL";
        /// <summary>
        /// 成功
        /// </summary>
        public const string Ok = "OK";
        /// <summary>
        /// 返回状态码
        /// </summary>
        public const string ReturnCode = "return_code";
        /// <summary>
        /// 业务结果代码
        /// </summary>
        public const string ResultCode = "result_code";
        /// <summary>
        /// 返回消息
        /// </summary>
        public const string ReturnMessage = "return_msg";
        /// <summary>
        /// 伙伴标识
        /// </summary>
        public const string PartnerId = "partnerid";
        /// <summary>
        /// 时间戳
        /// </summary>
        public const string Timestamp = "timestamp";
        /// <summary>
        /// 包
        /// </summary>
        public const string Package = "package";
        /// <summary>
        /// 错误码
        /// </summary>
        public const string ErrorCode = "err_code";
        /// <summary>
        /// 错误码和描述
        /// </summary>
        public const string ErrorCodeDescription = "err_code_des";
        /// <summary>
        /// 附加数据
        /// </summary>
        public const string Attach = "attach";
        /// <summary>
        /// 用户标识
        /// </summary>
        public const string OpenId = "openid";

        /// <summary>
        /// 二维码地址
        /// </summary>
        public const string CodeUrl = "code_url";

        /// <summary>
        /// 设备号 自定义参数，可以为请求支付的终端设备号等
        /// </summary>
        public const string DeviceInfo = "device_info";

        /// <summary>
        /// 商户退款单号
        /// </summary>
        public const string OutRefundNo = "out_refund_no";

        /// <summary>
        /// 退款原因
        /// </summary>
        public const string RefundDesc = "refund_desc";

        /// <summary>
        /// 成功时间
        /// </summary>
        public const string SuccessTime = "success_time";

        /// <summary>
        /// 请求信息
        /// </summary>
        public const string ReqInfo = "req_info";

        /// <summary>
        /// 交易起始时间
        /// </summary>
        public const string TimeStart = "time_start";

        /// <summary>
        /// 交易结束时间
        /// </summary>
        public const string TimeExpire = "time_expire";

        /// <summary>
        /// 订单优惠标记
        /// </summary>
        public const string GoodsTag = "goods_tag";

        /// <summary>
        /// 商品ID
        /// </summary>
        public const string ProductId = "product_id";

        /// <summary>
        /// 指定支付方式
        /// </summary>
        public const string LimitPay = "limit_pay";

        /// <summary>
        /// 电子发票入口开放标识
        /// </summary>
        public const string Receipt = "receipt";

        /// <summary>
        /// 场景信息
        /// </summary>   
        public const string SceneInfo = "scene_info";

        /// <summary>
        /// 扫码支付授权码，设备读取用户微信中的条码或者二维码信息
        /// </summary>
        public const string AuthCode = "auth_code";

        /// <summary>
        /// 偏移量，当部分退款次数超过10次时可使用，表示返回的查询结果从这个偏移量开始取记录
        /// </summary>
        public const string Offset = "offset";

        /// <summary>
        /// 退款货币种类
        /// </summary>
        public const string RefundFeeType = "refund_fee_type";

        /// <summary>
        /// 退款资金来源
        /// </summary>
        public const string RefundAccount = "refund_account";

        /// <summary>
        /// 商户订单号
        /// </summary>
        public const string MchBillno = "mch_billno";

        /// <summary>
        /// 公众账号appid
        /// </summary>
        public const string WxAppid = "wxappid";

        /// <summary>
        /// 商户名称
        /// </summary>
        public const string SendName = "send_name";

        /// <summary>
        /// 用户openid https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1445241432
        /// </summary>
        public const string ReOpenid = "re_openid";

        /// <summary>
        /// 付款金额
        /// </summary>
        public const string TotalAmount = "total_amount";

        /// <summary>
        /// 红包发放总人数
        /// </summary>
        public const string TotalNum = "total_num";

        /// <summary>
        /// 红包祝福语
        /// </summary>
        public const string Wishing = "wishing";

        /// <summary>
        /// Ip地址
        /// </summary>
        public const string ClientIp = "client_ip";

        /// <summary>
        /// 活动名称
        /// </summary>
        public const string ActName = "act_name";

        /// <summary>
        /// 备注
        /// </summary>
        public const string Remark = "remark";

        /// <summary>
        /// 场景id
        /// </summary>
        public const string SceneId = "scene_id";

        /// <summary>
        /// 活动信息
        /// </summary>
        public const string RiskInfo = "risk_info";

        /// <summary>
        /// 红包金额设置方式 
        /// </summary>
        public const string AmtType = "amt_type";

        /// <summary>
        /// MCHT:通过商户订单号获取红包信息。  
        /// </summary>
        public const string BillType = "bill_type ";
    }
}
