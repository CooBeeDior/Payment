using Payments.Exceptions;
using Payments.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliPay.Configs
{
    public class AliPayConfigFactory : IAliPayConfigFactory
    {
        private IEnumerable<IAliPayConfigStorage> _AliPayConfigProviders = null;


        public AliPayConfigFactory(IEnumerable<IAliPayConfigStorage> AliPayConfigProviders)
        {
            _AliPayConfigProviders = AliPayConfigProviders;
        }

  

        public AliPayConfig GetConfig(string name)
        {
            name.CheckNull(nameof(name));
            foreach (var provider in _AliPayConfigProviders)
            {
                var wechatConfig = provider.GetConfig(name);
                if (wechatConfig != null)
                {
                    return wechatConfig;
                }
            }
            throw new ConfigNotExsitException();
        }

        public Task<AliPayConfig> GetConfigAsync(string name)
        {
            return Task.FromResult(this.GetConfig(name));
        }
    }
}
