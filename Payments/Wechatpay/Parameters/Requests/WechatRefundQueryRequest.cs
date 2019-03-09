using Payments.Exceptions;
using Payments.Util.Validations;
using System.Linq;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 退款订单查询
    /// </summary>
    public class WechatRefundQueryRequest : Validation, IWechatpayRequest, IValidation
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        public string RefundId { get; set; }

    
    }
}
