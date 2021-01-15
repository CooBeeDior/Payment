using System.Threading.Tasks;
using Payments.Alipay.Parameters.Requests;
using Payments.Attributes;
using Payments.Core;

namespace Payments.Alipay.Abstractions {
    /// <summary>
    /// 支付宝电脑网站支付服务
    /// </summary>
    [PayService("支付宝电脑网站支付服务")]
    public interface IAlipayPagePayService {
        /// <summary>
        /// 支付,返回表单html
        /// </summary>
        /// <param name="request">电脑网站支付参数</param>
        Task<PayResult> PayAsync( AlipayPagePayRequest request );
        /// <summary>
        /// 跳转到支付宝收银台
        /// </summary>
        /// <param name="request">电脑网站支付参数</param>
        Task RedirectAsync( AlipayPagePayRequest request );
    }
}