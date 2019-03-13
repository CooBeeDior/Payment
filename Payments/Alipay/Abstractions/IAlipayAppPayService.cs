using System.Threading.Tasks;
using Payments.Alipay.Parameters.Requests;
using Payments.Attributes;
using Payments.Core;
using Payments.Core.Response;

namespace Payments.Alipay.Abstractions {
    /// <summary>
    /// 支付宝App支付服务
    /// </summary>
    [PayService("支付宝App支付")]
    public interface IAlipayAppPayService {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        Task<PayResult> PayAsync( AlipayAppPayRequest request );
    }
}