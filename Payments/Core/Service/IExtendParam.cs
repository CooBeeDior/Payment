using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Service
{
    public interface IExtendParam
    {
        void SetExtensionParameter(IDictionary<string, object> extParam);
    }
}
