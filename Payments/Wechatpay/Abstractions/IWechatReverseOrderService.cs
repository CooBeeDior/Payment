using Payments.Attributes;
using Payments.Core.Response;
using Payments.WechatPay.Parameters.Requests;
using Payments.WechatPay.Parameters.Response;
using Payments.WechatPay.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.WechatPay.Abstractions
{
    /// <summary>
    /// 撤销订单服务
    /// </summary>
    [PayService("撤销订单服务")]
    public interface IWechatReverseOrderService : IWechatConfigSetter, IWechatPayExtParam
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatReverseOrderResponse>> ReverseAsync(WechatReverseOrderRequest request);
    }
}
