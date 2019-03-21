using Payments.Attributes;
using Payments.Core.Enum;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
using System.Threading.Tasks;


namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 查询企业付款服务
    /// </summary>
    [PayService("查询企业付款服务", PayOriginType.WechatPay)]
    public interface IWechatGetTransferInfoService
    {
        Task<PayResult> Query(WechatGetTransferInfoRequest param);
        
    }
}
