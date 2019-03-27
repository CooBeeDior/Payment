using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 公众号APP申请签约
    /// </summary>
    [PayService("公众号APP申请签约", PayOriginType.WechatPay)]
    public interface IWechatEntrustWebService
    {
        /// <summary>
        /// 获取跳转url
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> GetUrl(WechatEntrustWebRequest request);
    }
}
