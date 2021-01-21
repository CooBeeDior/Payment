using AliPay.Configs;
using Payments.Core.Service;

namespace AliPay.Configs
{
    public interface IAliPayServiceProvider: IPayServiceProvider
    { 

        TAliPayService GetService<TAliPayService>(AliPayConfig AliPayConfig) where TAliPayService : class;
    }
}
