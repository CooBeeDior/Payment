using Payments.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Configs
{
    public interface IPayConfig
    {
        /// <summary>
        /// 应用私钥
        /// </summary>
        string PrivateKey { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        PaySignType SignType { get; set; } 
    }
}
