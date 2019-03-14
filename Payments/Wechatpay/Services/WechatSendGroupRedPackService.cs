using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Extensions;
using Payments.Util;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 发放裂变红包服务
    /// </summary>
    public class WechatSendGroupRedPackService : WechatpayServiceBase<WechatSendRedPackRequest>, IWechatSendGroupRedPackService
    {

        public WechatSendGroupRedPackService(IWechatpayConfigProvider provider, ILoggerFactory loggerFactory) : base(provider, loggerFactory)
        {

        }
        public Task<PayResult> SendGroupReadPack(WechatSendRedPackRequest param)
        {
            return Request(param);

        }

        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetSendGroupredPackUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatSendRedPackRequest param)
        {
            builder.Remove(WechatpayConst.AppId).Remove(WechatpayConst.SignType)
               .Remove(WechatpayConst.SpbillCreateIp)
               .Add(WechatpayConst.WxAppid, Config.AppId).Add(WechatpayConst.ClientIp, Server.GetLanIp())
               .Add(WechatpayConst.MchBillNo, param.MchBillNo).Add(WechatpayConst.SendName, param.SendName).Add(WechatpayConst.ReOpenid, param.ReOpenid)
               .Add(WechatpayConst.TotalAmount, (param.TotalAmount * 100).ToInt().ToString()).Add(WechatpayConst.TotalNum, param.TotalNum.ToString())
               .Add(WechatpayConst.AmtType, param.AmtType).Add(WechatpayConst.Wishing, param.Wishing)
               .Add(WechatpayConst.ActName, param.ActName).Add(WechatpayConst.Remark, param.Remark).Add(WechatpayConst.SceneId, param.SceneId?.ToString())
               .Add(WechatpayConst.RiskInfo, param.RiskInfo);
        }
        protected override WechatpayParameterBuilder CreateParameterBuilder()
        {
            var builder = new WechatpayCertParameterBuilder(Config);
            return builder;
        }
    }
}
