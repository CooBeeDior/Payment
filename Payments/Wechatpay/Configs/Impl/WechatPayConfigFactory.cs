using Payments.Exceptions;
using Payments.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.WechatPay.Configs
{
    public class WechatPayConfigFactory : IWechatPayConfigFactory
    {
        private IEnumerable<IWechatPayConfigStorage> _WechatPayConfigProviders = null;


        public WechatPayConfigFactory(IEnumerable<IWechatPayConfigStorage> WechatPayConfigProviders)
        {
            _WechatPayConfigProviders = WechatPayConfigProviders;
        }

  

        public WechatPayConfig GetConfig(string name)
        {
            name.CheckNull(nameof(name));
            foreach (var provider in _WechatPayConfigProviders)
            {
                var wechatConfig = provider.GetConfig(name);
                if (wechatConfig != null)
                {
                    return wechatConfig;
                }
            }
            throw new ConfigNotExsitException();
        }

        public Task<WechatPayConfig> GetConfigAsync(string name)
        {
            return Task.FromResult(this.GetConfig(name));
        }
    }
}
