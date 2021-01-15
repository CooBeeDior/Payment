using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System.Threading.Tasks;


namespace WechatPay.Abstractions
{
    /// <summary>
    /// 查询企业付款服务
    /// </summary>
    [PayService("查询企业付款服务", PayOriginType.WechatPay)]
    public interface IWechatGetTransferInfoService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatGetTransferInfoResponse>> Query(WechatGetTransferInfoRequest request);
        
    }
}
