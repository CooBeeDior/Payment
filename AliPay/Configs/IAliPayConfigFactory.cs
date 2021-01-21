using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliPay.Configs
{
    public interface IAliPayConfigFactory
    {     

        AliPayConfig GetConfig(string name);

        Task<AliPayConfig> GetConfigAsync(string name);
    }
}
