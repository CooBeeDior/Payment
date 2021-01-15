using Payments.Core;
using Payments.Util.Validations;
using System.ComponentModel.DataAnnotations;

namespace Payments.Alipay.Parameters.Requests
{
    /// <summary>
    /// 支付宝支付参数
    /// </summary>
    public class AlipayRequestBase : Validation, IAlipayRequest, IValidation
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [MaxLength(64)]
        public virtual string OutTradeNo { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        [MaxLength(128)]
        public virtual string Body { get; set; }

        /// <summary>
        /// 商品的标题/交易标题/订单标题/订单关键字等。
        /// </summary>
        [Required]
        [MaxLength(256)]
        public virtual string Subject { get; set; }

        /// <summary>
        /// 销售产品码，商家和支付宝签约的产品码
        /// </summary>
        [Required]
        [MaxLength(64)]
        public virtual string ProductCode { get; set; }

        /// <summary>
        /// 该笔订单允许的最晚付款时间，逾期将关闭交易。取值范围：1m～15d。m-分钟，h-小时，d-天，1c-当天（1c-当天的情况下，无论交易何时创建，都在0点关闭）。 该参数数值不接受小数点， 如 1.5h，可转换为 90m。注：若为空，则默认为15d。
        /// </summary>
        [MaxLength(6)]
        public virtual string TimeoutExpress { get; set; }

        /// <summary>
        /// 绝对超时时间，格式为yyyy-MM-dd HH:mm。 注：1）以支付宝系统时间为准；2）如果和timeout_express参数同时传入，以time_expire为准
        /// </summary>
        [MaxLength(32)]
        public virtual string TimeExpire { get; set; }

        /// <summary>
        /// 订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]
        /// </summary>
        [Required]
        [Range(0.01, 100000000)]
        public virtual decimal TotalAmount { get; set; }

        /// <summary>
        /// 商品主类型：0—虚拟类商品，1—实物类商品注：虚拟类商品不支持使用花呗渠道
        /// </summary>
        [MaxLength(2)]
        public virtual string GoodsType { get; set; }
        /// <summary>
        /// 公用回传参数，如果请求时传递了该参数，则返回给商户时会回传该参数。支付宝会在异步通知时将该参数原样返回。本参数必须进行UrlEncode之后才可以发送给支付宝
        /// </summary>
        [MaxLength(512)]
        public virtual string PassbackParams { get; set; }

        /// <summary>
        /// 优惠参数注：仅与支付宝协商后可用
        /// </summary>
        [MaxLength(512)]
        public virtual string PromoParams { get; set; }

        /// <summary>
        /// 业务扩展参数
        /// </summary>
        public virtual ExtendParam ExtendParams { get; set; }


        /// <summary>
        /// 可用渠道，用户只能在指定渠道范围内支付当有多个渠道时用“,”分隔注：与disable_pay_channels互斥
        /// </summary>
        [MaxLength(128)]
        public virtual string EnablePayChannels { get; set; }

        /// <summary>
        /// 禁用渠道，用户不可用指定渠道支付当有多个渠道时用“,”分隔注：与enable_pay_channels互斥
        /// </summary>
        [MaxLength(128)]
        public virtual string DisablePayChannels { get; set; }

        /// <summary>
        /// 商户门店编号。该参数用于请求参数中以区分各门店，非必传项。
        /// </summary>
        [MaxLength(32)]
        public virtual string StoreId { get; set; }

        /// <summary>
        /// 添加该参数后在h5支付收银台会出现返回按钮，可用于用户付款中途退出并返回到该参数指定的商户网站地址。注：该参数对支付宝钱包标准收银台下的跳转不生效。
        /// </summary>
        [MaxLength(400)]
        public virtual string QuitUrl { get; set; }

        /// <summary>
        /// 外部指定买家
        /// </summary>
        public virtual ExtendUserInfo ExtUserInfo { get; set; }




        /// <summary>
        /// 业务扩展参数
        /// </summary>
        public class ExtendParam
        {
            /// <summary>
            /// 系统商编号，该参数作为系统商返佣数据提取的依据，请填写系统商签约协议的PID。注：若不属于支付宝业务经理提供签约服务的商户，暂不对外提供该功能，该参数使用无效。
            /// </summary>
            [MaxLength(64)]
            public string SysServiceProviderId { get; set; }

            /// <summary>
            /// 是否发起实名校验T：发起F：不发起
            /// </summary>
            [MaxLength(1)]
            public string NeedBuyerRealnamed { get; set; }

            /// <summary>
            /// 账务备注注：该字段显示在离线账单的账务备注中
            /// </summary>
            [MaxLength(128)]
            public string TransMemo { get; set; }

            /// <summary>
            /// 花呗分期数（目前仅支持3、6、12）注：使用该参数需要仔细阅读“花呗分期接入文档”
            /// </summary>
            [MaxLength(5)]
            public string HbFqNum { get; set; }

            /// <summary>
            /// 卖家承担收费比例，商家承担手续费传入100，用户承担手续费传入0，仅支持传入100、0两种，其他比例暂不支持注：使用该参数需要仔细阅读“花呗分期接入文档”
            /// </summary>
            [MaxLength(3)]
            public string HbFqSellerPercent { get; set; }
        }

        /// <summary>
        /// 外部用户ExtUserInfo
        /// </summary>
        public class ExtendUserInfo
        {
            [MaxLength(16)]
            public string Name { get; set; }

            [MaxLength(20)]
            public string Mobile { get; set; }

            /// <summary>
            /// 身份证：IDENTITY_CARD、护照：PASSPORT、军官证：OFFICER_CARD、士兵证：SOLDIER_CARD、户口本：HOKOU等。如有其它类型需要支持，请与蚂蚁金服工作人员联系。
            /// </summary>
            [MaxLength(32)]
            public string CertType { get; set; }

            /// <summary>
            /// 证件号 注：need_check_info=T时该参数才有效
            /// </summary>
            [MaxLength(64)]
            public string CertNo { get; set; }

            /// <summary>
            /// 允许的最小买家年龄，买家年龄必须大于等于所传数值
            /// 注：
            ///1. need_check_info=T时该参数才有效
            ///2. min_age为整数，必须大于等于0
            /// </summary>
            [MaxLength(18)]
            public string MinAge { get; set; }

            /// <summary>
            /// 是否强制校验付款人身份信息
            /// T:强制校验，F：不强制
            /// </summary>
            [MaxLength(8)]
            public string FixBuyer { get; set; }

            /// <summary>
            /// 是否强制校验身份信息
            ///T:强制校验，F：不强制
            /// </summary>
            [MaxLength(8)]
            public string NeedCheckInfo { get; set; }

        }
    }
}