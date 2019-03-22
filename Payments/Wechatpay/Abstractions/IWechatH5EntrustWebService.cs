using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
using System.Threading.Tasks;
namespace Payments.Wechatpay.Abstractions
{

    /// <summary>
    /// H5纯签约
    /// </summary>
    [PayService("H5纯签约", PayOriginType.WechatPay)]
    public interface IWechatH5EntrustWebService
    {
        Task<string> GetUrl(WechatH5EntrustWebRequest param);
    }
}
