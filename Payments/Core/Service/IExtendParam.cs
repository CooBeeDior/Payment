using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Service
{
    public interface IExtendParam
    {
        void ExtensionParameter(IDictionary<string, object> extParam);
    }
}
