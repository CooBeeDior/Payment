using System.Threading.Tasks;
using Payments.Alipay.Parameters.Requests;
using Payments.Attributes;
using Payments.Core;

namespace Payments.Alipay.Abstractions {
    /// <summary>
    /// 支付宝二维码支付
    /// </summary>
    [PayService("支付宝二维码支付")]
    public interface IAlipayQrCodePayService {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        Task<PayResult> PayAsync( AlipayPrecreateRequest request );
    }
}
