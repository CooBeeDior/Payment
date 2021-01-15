using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Service
{
    public interface IConfigSetter<TConfig>
    {
        void SetConfig(TConfig config);
    }
}
