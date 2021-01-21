using Payments.Attributes;
using Payments.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WechatPay.Configs;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;

namespace WechatPay.Abstractions
{
    /// <summary>
    /// 下载交易账单
    /// </summary>
    [PayService("下载交易账单", PayOriginType.WechatPay)]
    public interface IWechatDownloadbillService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 下载账单
        /// </summary>
        Task<WechatPayResult<WechatPayResponse>> Dowbload(WechatDownloadbillRequest request);
    }

 
}
