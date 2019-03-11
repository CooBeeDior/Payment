using Payments.Attributes;
using Payments.Core.Response;
using Payments.Wechatpay.Parameters.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 撤销订单服务
    /// </summary>
    [PayService("撤销订单服务")]
    public interface IWechatReverseOrderService
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<PayResult> ReverseAsync(WechatReverseOrderRequest param);
    }
}
