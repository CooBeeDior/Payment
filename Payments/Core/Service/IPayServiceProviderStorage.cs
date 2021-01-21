using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Service
{
    public interface IPayServiceProviderStorage
    {
        void AddPayServiceProvider(string name, IPayServiceProvider payServiceProvider);

        IPayServiceProvider GetPayServiceProvider(string name);

    }
}
