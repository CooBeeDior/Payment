namespace WechatPay.Configs
{
    /// <summary>
    /// 微信支付常量
    /// </summary>
    public static class WechatPayConst
    {
        /// <summary>
        /// 微信支付跟踪日志名【WechatPayTraceLog】
        /// </summary>
        public const string TraceLogName = "WechatPayTraceLog";
        /// <summary>
        /// 应用标识【appid】
        /// </summary>
        public const string AppId = "appid";
        /// <summary>
        /// 商户号【mch_id】
        /// </summary>
        public const string MerchantId = "mch_id";
        /// <summary>
        /// 标题【body】
        /// </summary>
        public const string Body = "body";
        /// <summary>
        /// 商户订单号 【out_trade_no】
        /// </summary>
        public const string OutTradeNo = "out_trade_no";
        /// <summary>
        /// 微信支付订单号【transaction_id】
        /// </summary>
        public const string TransactionId = "transaction_id";


        /// <summary>
        /// 预支付Id【prepay_id】
        /// </summary>
        public const string PrepayId = "prepay_id";
        /// <summary>
        /// nonce_str【nonce_str】
        /// </summary>
        public const string NonceStr = "nonce_str";
        /// <summary>
        /// 货币类型【fee_type】
        /// </summary>
        public const string FeeType = "fee_type";
        /// <summary>
        /// 总金额【total_fee】
        /// </summary>
        public const string TotalFee = "total_fee";

        /// <summary>
        /// 微信退款单号【refund_id】
        /// </summary>
        public const string RefundId = "refund_id";
        /// <summary>
        /// 退款金额【refund_fee】
        /// </summary>
        public const string RefundFee = "refund_fee";

        /// <summary>
        /// 退款金额【settlement_refund_fee】
        /// </summary>
        public const string SettlementRefundFee = "settlement_refund_fee";

        /// <summary>
        /// 退款金额【settlement_refund_fee】
        /// </summary>
        public const string SettlementTotalFee = "settlement_refund_fee";

        /// <summary>
        /// 回调通知Url【notify_url】
        /// </summary>
        public const string NotifyUrl = "notify_url";
        /// <summary>
        /// 终端IP【spbill_create_ip】
        /// </summary>
        public const string SpbillCreateIp = "spbill_create_ip";
        /// <summary>
        /// 交易类型【trade_type】
        /// </summary>
        public const string TradeType = "trade_type";
        /// <summary>
        /// 商品详情【detail】
        /// </summary>
        public const string Detail = "detail";
        /// <summary>
        /// 签名类型【sign_type】
        /// </summary>
        public const string SignType = "sign_type";
        /// <summary>
        /// 签名【sign】
        /// </summary>
        public const string Sign = "sign";
        /// <summary>
        /// 成功【SUCCESS】
        /// </summary>
        public const string Success = "SUCCESS";
        /// <summary>
        /// 失败【FAIL】
        /// </summary>
        public const string Fail = "FAIL";
        /// <summary>
        /// 成功【OK】
        /// </summary>
        public const string Ok = "OK";
        /// <summary>
        /// 返回状态码【return_code】
        /// </summary>
        public const string ReturnCode = "return_code";
        /// <summary>
        /// 业务结果代码【result_code】
        /// </summary>
        public const string ResultCode = "result_code";
        /// <summary>
        /// 返回消息【return_msg】
        /// </summary>
        public const string ReturnMessage = "return_msg";
        /// <summary>
        /// 伙伴标识【partnerid】
        /// </summary>
        public const string PartnerId = "partnerid";
        /// <summary>
        /// 时间戳【timestamp】
        /// </summary>
        public const string Timestamp = "timestamp";
        /// <summary>
        /// 包【package】
        /// </summary>
        public const string Package = "package";
        /// <summary>【err_code】
        /// 错误码
        /// </summary>
        public const string ErrorCode = "err_code";
        /// <summary>
        /// 错误码和描述【err_code_des】
        /// </summary>
        public const string ErrorCodeDescription = "err_code_des";
        /// <summary>
        /// 附加数据【attach】
        /// </summary>
        public const string Attach = "attach";
        /// <summary>
        /// 用户标识【openid】
        /// </summary>
        public const string OpenId = "openid";

        /// <summary>
        /// 二维码地址【code_url】
        /// </summary>
        public const string CodeUrl = "code_url";

        /// <summary>
        /// 设备号 自定义参数，可以为请求支付的终端设备号等【device_info】
        /// </summary>
        public const string DeviceInfo = "device_info";

        /// <summary>
        /// 商户退款单号【out_refund_no】
        /// </summary>
        public const string OutRefundNo = "out_refund_no";

        /// <summary>
        /// 退款原因【refund_desc】
        /// </summary>
        public const string RefundDesc = "refund_desc";

        /// <summary>
        /// 成功时间【success_time】
        /// </summary>
        public const string SuccessTime = "success_time";

        /// <summary>
        /// 请求信息【req_info】
        /// </summary>
        public const string ReqInfo = "req_info";

        /// <summary>
        /// 交易起始时间【time_start】
        /// </summary>
        public const string TimeStart = "time_start";

        /// <summary>
        /// 交易结束时间【time_expire】
        /// </summary>
        public const string TimeExpire = "time_expire";

        /// <summary>
        /// 订单优惠标记【goods_tag】
        /// </summary>
        public const string GoodsTag = "goods_tag";

        /// <summary>
        /// 商品ID【product_id】
        /// </summary>
        public const string ProductId = "product_id";

        /// <summary>
        /// 指定支付方式【limit_pay】
        /// </summary>
        public const string LimitPay = "limit_pay";

        /// <summary>
        /// 电子发票入口开放标识【receipt】
        /// </summary>
        public const string Receipt = "receipt";

        /// <summary>
        /// 场景信息【scene_info】
        /// </summary>   
        public const string SceneInfo = "scene_info";

        /// <summary>
        /// 扫码支付授权码，设备读取用户微信中的条码或者二维码信息【auth_code】
        /// </summary>
        public const string AuthCode = "auth_code";

        /// <summary>
        /// 偏移量【offset】
        /// 当部分退款次数超过10次时可使用，表示返回的查询结果从这个偏移量开始取记录
        /// </summary>
        public const string Offset = "offset";

        /// <summary>
        /// 退款货币种类【refund_fee_type】
        /// </summary>
        public const string RefundFeeType = "refund_fee_type";

        /// <summary>
        /// 退款资金来源【refund_account】
        /// </summary>
        public const string RefundAccount = "refund_account";

        /// <summary>
        /// 商户订单号【mch_billno】
        /// </summary>
        public const string MchBillNo = "mch_billno";

        /// <summary>
        /// 公众账号appid【wxappid】
        /// </summary>
        public const string WxAppid = "wxappid";

        /// <summary>
        /// 商户名称【send_name】
        /// </summary>
        public const string SendName = "send_name";

        /// <summary>
        /// 用户openid 【re_openid】
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1445241432
        /// </summary>
        public const string ReOpenid = "re_openid";

        /// <summary>
        /// 付款金额【total_amount】
        /// </summary>
        public const string TotalAmount = "total_amount";

        /// <summary>
        /// 红包发放总人数【total_num】
        /// </summary>
        public const string TotalNum = "total_num";

        /// <summary>
        /// 红包祝福语【wishing】
        /// </summary>
        public const string Wishing = "wishing";

        /// <summary>
        /// Ip地址【client_ip】
        /// </summary>
        public const string ClientIp = "client_ip";

        /// <summary>
        /// 活动名称【act_name】
        /// </summary>
        public const string ActName = "act_name";

        /// <summary>
        /// 备注【remark】
        /// </summary>
        public const string Remark = "remark";

        /// <summary>
        /// 场景id【scene_id】
        /// </summary>
        public const string SceneId = "scene_id";

        /// <summary>
        /// 活动信息【risk_info】
        /// </summary>
        public const string RiskInfo = "risk_info";

        /// <summary>
        /// 红包金额设置方式 【amt_type】
        /// </summary>
        public const string AmtType = "amt_type";

        /// <summary>
        /// MCHT:通过商户订单号获取红包信息。  【bill_type】
        /// </summary>
        public const string BillType = "bill_type ";

        /// <summary>
        /// 商户账号appid【mch_appid】
        /// </summary>
        public const string MchAppId = "mch_appid";

        /// <summary>
        /// 商户号【mchid】
        /// </summary>
        public const string MchId = "mchid";
 

        /// <summary>
        /// 商户订单号【partner_trade_no】
        /// </summary>
        public const string PartnerTradeNo = "partner_trade_no";

        /// <summary>
        /// 校验用户姓名选项【check_name】
        /// </summary>
        public const string CheckName = "check_name";

        /// <summary>
        /// 款用户姓名【re_user_name】
        /// </summary>
        public const string ReUserName = "re_user_name";

        /// <summary>
        /// 金额【amount】
        /// </summary>
        public const string Amount = "amount";

        /// <summary>
        /// 企业付款备注【desc】
        /// </summary>
        public const string Desc = "desc";

        /// <summary>
        /// 是否需要分账【profit_sharing】
        /// Y-是，需要分账
        /// N-否，不分账
        /// 字母要求大写，不传默认不分账
        /// </summary>
        public const string ProfitSharing = "profit_sharing";

        /// <summary>
        /// 资金账单日期【bill_date】
        /// </summary>
        public const string BillDate = "bill_date";
        /// <summary>
        /// 资金账户类型【account_type】
        /// 账单的资金来源账户：
        /// Basic 基本账户
        /// Operation 运营账户
        /// Fees 手续费账户
        /// </summary>
        public const string AccountType = "account_type";
        /// <summary>
        /// 压缩账单【tar_type】
        /// </summary>
        public const string TarType = "tar_type";

        /// <summary>
        /// 开始时间【begin_time】
        /// </summary>
        public const string BeginTime = "begin_time";
        /// <summary>
        /// 结束时间【end_time】
        /// </summary>
        public const string EndTime = "end_time";


        /// <summary>
        /// 条数【limit】
        /// </summary>
        public const string Limit = "limit";

        /// <summary>
        /// 收款方银行卡号【enc_bank_no】
        /// </summary>
        public const string EncBankNo = "enc_bank_no";
        /// <summary>
        /// 收款方用户名
        /// </summary>
        public const string EncTrueName = "enc_true_name";

        /// <summary>
        /// 收款方开户行
        /// </summary>
        public const string BankCode = "bank_code";


    


    }
}
