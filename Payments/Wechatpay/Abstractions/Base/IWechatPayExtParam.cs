using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 扩展参数
    /// </summary>
    public interface IWechatPayExtParam
    {
        void ExtensionParameter(IDictionary<string, object> extParam);
    }
}
