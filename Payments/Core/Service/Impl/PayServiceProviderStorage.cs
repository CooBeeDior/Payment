using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Service.Impl
{

    public class PayServiceProviderStorage : IPayServiceProviderStorage
    {
        private static IDictionary<string, IPayServiceProvider> providers = new ConcurrentDictionary<string, IPayServiceProvider>();
        public void AddPayServiceProvider(string name, IPayServiceProvider payServiceProvider)
        {
            if (providers.ContainsKey(name))
            {
                providers[name] = payServiceProvider;
            }
            else
            {
                providers.Add(name, payServiceProvider);
            }
        }

        public IPayServiceProvider GetPayServiceProvider(string name)
        {
            IPayServiceProvider provider;
            providers.TryGetValue(name, out provider);
            return provider;
        }
    }
}
