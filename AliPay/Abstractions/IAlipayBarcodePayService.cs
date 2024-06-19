using System.Threading.Tasks;
using AliPay.Parameters.Requests;
using AliPay.Results;
using Payments.Attributes;
using Payments.Core;
using Payments.Core.Response;

namespace AliPay.Abstractions {
    /// <summary>
    /// 支付宝条码支付服务
    /// </summary>
    [PayService("支付宝条码支付")]
    public interface IAlipayBarcodePayService {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">条码支付参数</param>
        Task<AlipayResult> PayAsync( AlipayBarcodePayRequest request );
    }
}