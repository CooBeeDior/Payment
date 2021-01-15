using System.Threading.Tasks;
using Payments.Alipay.Configs;
using Payments.Alipay.Parameters;
using Payments.Alipay.Results;
using Payments.Core;
using Util;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Payments.Alipay.Services.Base
{
    /// <summary>
    /// 支付宝支付服务
    /// </summary>
    public abstract class AlipayServiceBase : AlipayServiceBase<PayParam>, IPayService
    {
        protected AlipayServiceBase(IAlipayConfigProvider provider) : base(provider)
        {
        }



       
    }
}
