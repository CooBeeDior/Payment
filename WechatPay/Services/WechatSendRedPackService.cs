using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util;
using WechatPay;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WechatPay.Services
{
    /// <summary>
    /// 发放普通红包服务
    /// </summary>
    public class WechatSendRedPackService : WechatPayServiceBase<WechatSendRedPackRequest>, IWechatSendRedPackService
    {
        public WechatSendRedPackService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
        }

        public Task<WechatPayResult<WechatSendRedPackResponse>> SendReadPack(WechatSendRedPackRequest request)
        {
            return Request<WechatSendRedPackResponse>(request);
        }

        protected override string GetRequestUrl(WechatPayConfig config)
        {
            return config.GetSendRedPackUrl();
        }

        protected override void InitBuilder(WechatPayParameterBuilder builder, WechatSendRedPackRequest param)
        {

            builder.Remove(WechatPayConst.AppId).Remove(WechatPayConst.SignType)
                .Remove(WechatPayConst.SpbillCreateIp)
                .Add(WechatPayConst.WxAppid, Config.AppId).Add(WechatPayConst.ClientIp, Server.GetLanIp())
                .Add(WechatPayConst.MchBillNo, param.MchBillNo).Add(WechatPayConst.SendName, param.SendName).Add(WechatPayConst.ReOpenid, param.ReOpenId)
                .Add(WechatPayConst.TotalAmount, (param.TotalAmount * 100).ToInt().ToString()).Add(WechatPayConst.TotalNum, param.TotalNum.ToString())
                .Add(WechatPayConst.Wishing, param.Wishing).Add(WechatPayConst.ActName, param.ActName).Add(WechatPayConst.Remark, param.Remark)
                .Add(WechatPayConst.SceneId, param.SceneId?.ToString()).Add(WechatPayConst.RiskInfo, param.RiskInfo);
        }

      
    }
}
