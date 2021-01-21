using AliPay.Configs;
using Payments.Core;

namespace AliPay.Services.Base
{
    /// <summary>
    /// 支付宝支付服务
    /// </summary>
    public abstract class AlipayServiceBase : AlipayServiceBase<PayParam>, IPayService
    {
        protected AlipayServiceBase(IAliPayConfigProvider provider) : base(provider)
        {
        }



       
    }
}
