using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Service
{
    public interface IPayServiceProviderFactory
    {
        IPayServiceProvider CreateProvider(string name);
    }
      

}
