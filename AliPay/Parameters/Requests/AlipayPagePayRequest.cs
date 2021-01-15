namespace Payments.Alipay.Parameters.Requests
{
    /// <summary>
    /// 电脑网站支付参数
    /// </summary>
    public class AlipayPagePayRequest : AlipayRequestBase
    {
        /// <summary>
        /// 订单描述
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 附加参数 passback_params
        /// </summary>
        public string Attach { get; set; }
    }
}
