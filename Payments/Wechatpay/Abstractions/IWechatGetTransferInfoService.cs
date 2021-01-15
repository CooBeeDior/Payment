using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using System.Threading.Tasks;


namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 查询企业付款服务
    /// </summary>
    [PayService("查询企业付款服务", PayOriginType.WechatPay)]
    public interface IWechatGetTransferInfoService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatGetTransferInfoResponse>> Query(WechatGetTransferInfoRequest request);
        
    }
}
