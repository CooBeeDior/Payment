using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Util;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using WechatPay;

namespace WechatPay.Services
{
    /// <summary>
    /// 提交付款码支付
    /// </summary>
    public class WechatPayMicropayService : WechatPayServiceBase<WechatPayMicroPayRequest>, IWechatPayMicroPayService
    {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPayMicropayService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<WechatPayResult<WechatPayMicroPayResponse>> PayAsync(WechatPayMicroPayRequest request)
        {
            return Request<WechatPayMicroPayResponse>(request);
        }


        /// <summary>
        /// 获取URL
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetMicroPayUrl();
        }


 
        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatPayMicroPayRequest param)
        {
            builder.Body(param.Body).OutTradeNo(param.OutTradeNo)
             .TotalFee(param.TotalFee).NotifyUrl(param.NotifyUrl).Attach(param.Attach)
             .Detail(param.Detail).FeeType(param.FeeType).TimeStart(param.TimeStart)
             .TimeExpire(param.TimeExpire).GoodsTag(param.GoodsTag).LimitPay(param.LimitPay)
             .Receipt(param.Receipt).ProfitSharing(param.ProfitSharing).SceneInfo(param.SceneInfo)
             .AuthCode(param.AuthCode).Remove(WechatPayConst.NotifyUrl);
        }
    }
}
