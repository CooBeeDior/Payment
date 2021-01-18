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
    /// 下载资金账单
    /// </summary>
    [PayService("下载资金账单", PayOriginType.WechatPay)]
    public interface IWechatDownloadfundflowService : IWechatConfigSetter, IWechatPayExtendParam 
    {
        /// <summary>
        /// 下载账单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatPayResponse>> Dowbload(WechatDownloadfundflowRequest request);
    }
}
