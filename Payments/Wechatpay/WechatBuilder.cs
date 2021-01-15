using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.WechatPay
{

    public class WechatBuilder : IWechatBuilder
    {
        public IServiceCollection Services { get; }

        public WechatBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
