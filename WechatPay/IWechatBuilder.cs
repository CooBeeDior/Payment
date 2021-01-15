using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WechatPay
{
    public interface IWechatBuilder
    {
        IServiceCollection Services { get; }
    }


}
