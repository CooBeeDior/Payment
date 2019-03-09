using Payments.Core;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Payments.Core.Response;
namespace Payments.Wechatpay.Abstractions
{
    public interface IWechatpayPayService<T> where T: WechatpayPayRequestBase
    {
        Task<PayResult> PayAsync(T t);
    }
}
