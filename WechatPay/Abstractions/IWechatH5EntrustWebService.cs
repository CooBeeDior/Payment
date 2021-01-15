using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using WechatPay.Parameters.Requests;
using System.Threading.Tasks;
namespace WechatPay.Abstractions
{

    /// <summary>
    /// H5纯签约
    /// </summary>
    [PayService("H5纯签约", PayOriginType.WechatPay)]
    public interface IWechatH5EntrustWebService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 获取跳转url
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> GetUrl(WechatH5EntrustWebRequest request);
    }
}
