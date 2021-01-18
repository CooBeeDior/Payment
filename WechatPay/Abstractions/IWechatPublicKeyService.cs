using Payments.Attributes;
using Payments.Core.Enum;
using WechatPay.Parameters.Requests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WechatPay.Results;
using WechatPay.Parameters.Response;

namespace WechatPay.Abstractions
{

    /// <summary>
    /// 获取RSA加密公钥
    /// </summary>   
    [PayService("获取RSA加密公钥服务", PayOriginType.WechatPay)]
    public interface IWechatPublicKeyService : IWechatConfigSetter, IWechatPayExtendParam
    {
        /// <summary>
        /// 获取RSA加密公钥
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WechatPayResult<WechatPublicKeyResponse>> GetPublicKey(WechatPublicKeyRequest request);

    }
}
