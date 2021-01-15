using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.WechatPay
{
    public interface IWechatBuilder
    {
        IServiceCollection Services { get; }
    }


}
