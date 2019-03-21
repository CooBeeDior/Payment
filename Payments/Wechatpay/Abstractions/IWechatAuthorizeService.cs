using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Abstractions
{ 
    /// <summary>
  /// 授权服务
  /// </summary>
    [PayService("授权服务", PayOriginType.WechatPay)]
    public interface IWechatAuthorizeService
    {
        /// <summary>
        /// 授权服务
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<string> Query(WechatAuthorizeRequest param);
    }
}
