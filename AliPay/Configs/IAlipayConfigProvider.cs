using Payments.Core.Service;
using System.Threading.Tasks;

namespace AliPay.Configs {
    /// <summary>
    /// 支付宝配置提供器
    /// </summary>
    public interface IAliPayConfigProvider : IPayServiceProvider
    {

        TAliPayService GetService<TAliPayService>(AliPayConfig AliPayConfig) where TAliPayService : class;
    }
}