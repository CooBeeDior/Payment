using Payments.Attributes;
using Payments.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WechatPay.Parameters.Response;
using WechatPay.Results;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 自定义服务
    /// </summary>
    [PayService("自定义服务", PayOriginType.WechatPay)]
    public interface ICustomeWehcatPayService : IWechatPayExtendParam, IWechatConfigSetter
    {
        IWechatPayExtendParam SetUrl(string url);
        Task<WechatPayResult<WechatPayResponse>> Request();

    }
}
