using System.Threading.Tasks;
using Payments.Alipay.Parameters.Requests;
using Payments.Attributes;
using Payments.Core;

namespace Payments.Alipay.Abstractions {
    /// <summary>
    /// 支付宝手机网站支付服务
    /// </summary>
    [PayService("支付宝手机网站支付")]
    public interface IAlipayWapPayService {
        /// <summary>
        /// 支付,返回表单html
        /// </summary>
        /// <param name="request">手机网站支付参数</param>
        Task<PayResult> PayAsync( AlipayWapPayRequest request );
        /// <summary>
        /// 跳转到支付宝收银台
        /// </summary>
        /// <param name="request">手机网站支付参数</param>
        Task RedirectAsync( AlipayWapPayRequest request );
    }
}