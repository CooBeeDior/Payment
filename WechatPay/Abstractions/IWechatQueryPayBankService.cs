using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System.Threading.Tasks;
using WechatPay.Configs;

namespace WechatPay.Abstractions
{    /// <summary>
     /// 查询企业付款到银行卡
     /// </summary>
    [PayService("查询企业付款到银行卡", PayOriginType.WechatPay)]
    public interface IWechatQueryPayBankService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatQueryPayBankResponse>> Query(WechatQueryPayBankRequest request);
    }
}
