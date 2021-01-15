using Payments.Exceptions;
using Payments.Util.Validations;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 退款订单查询
    /// </summary>
    public class WechatRefundQueryRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [MaxLength(32)]
        public virtual string OutTradeNo { get; set; }


        /// <summary>
        /// 微信订单号
        /// </summary>
        [MaxLength(32)]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [MaxLength(64)]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [MaxLength(32)]
        public string RefundId { get; set; }

        /// <summary>
        /// 偏移量，当部分退款次数超过10次时可使用，表示返回的查询结果从这个偏移量开始取记录 
        /// </summary> 
        public int? Offset { get; set; }


    }
}
