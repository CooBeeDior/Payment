namespace AliPay.Parameters.Requests
{
    /// <summary>
    /// 支付宝预创建支付参数
    /// </summary>
    public class AlipayPrecreateRequest : AlipayRequestBase
    {
        /// <summary>
        /// 订单描述
        /// </summary>
        public string Body { get; set; }
    }
}
