using Payments.Attributes;
using Payments.Core.Response;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WechatPay.Configs;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 撤销订单服务
    /// </summary>
    [PayService("撤销订单服务")]
    public interface IWechatReverseOrderService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatReverseOrderResponse>> ReverseAsync(WechatReverseOrderRequest request);
    }
}
