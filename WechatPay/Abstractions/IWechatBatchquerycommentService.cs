using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 拉取订单评价数据
    /// </summary>
    [PayService("拉取订单评价数据", PayOriginType.WechatPay)]
    public interface IWechatBatchquerycommentService : IWechatConfigSetter
    {
        /// <summary>
        /// 下载评论
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatPayResponse>> Dowbload(WechatBatchquerycommentRequest request);
    }
   
}
