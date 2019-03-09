using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Util.ParameterBuilders
{
    /// <summary>
    /// 参数服务
    /// </summary>
    public interface IParameterBuilder
    {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="name">参数名</param>
        object GetValue(string name);
    }
}
