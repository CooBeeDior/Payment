using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 授权access_token服务
    /// </summary>
    [PayService("授权access_token服务", PayOriginType.WechatPay)]
    public interface IWechatAccessTokenService
    {
        /// <summary>
        /// 授权access_token服务
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<string> Query(WechatAccessTokenRequest param);
    }
}
