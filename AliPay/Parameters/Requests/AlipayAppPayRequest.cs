namespace AliPay.Parameters.Requests {
    /// <summary>
    /// 支付宝App支付参数
    /// </summary>
    public class AlipayAppPayRequest : AlipayRequestBase {

        /// <summary>
        /// 订单描述
        /// </summary>
        public string Body { get; set; }
      

        /// <summary>
        /// 附加参数 passback_params
        /// </summary>
        public string Attach { get; set; }
    }
}