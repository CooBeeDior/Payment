using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Service
{
    public interface IPayServiceProvider
    {
        TPayService GetService<TPayService>(string configName = "default") where TPayService : class;
    }
}
