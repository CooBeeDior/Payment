using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
using System.Threading.Tasks;

namespace Payments.Core {
    /// <summary>
    /// 支付服务
    /// </summary>
    public interface IPayService {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        Task<PayResult> PayAsync(WechatpayPayRequestBase param );
    }
}