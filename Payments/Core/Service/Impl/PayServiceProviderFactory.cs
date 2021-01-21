using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Service.Impl
{
    public class PayServiceProviderFactory : IPayServiceProviderFactory
    {
        private readonly IPayServiceProviderStorage _payServiceProviderStore;
        public PayServiceProviderFactory(IPayServiceProviderStorage payServiceProviderStore)
        {
            _payServiceProviderStore = payServiceProviderStore;
        }
        public IPayServiceProvider CreateProvider(string name)
        {
            return _payServiceProviderStore.GetPayServiceProvider(name);
        }
    }
}
