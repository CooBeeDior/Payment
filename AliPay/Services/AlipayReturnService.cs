using AliPay.Abstractions;
using AliPay.Configs;
using AliPay.Services.Base;
using Payments.Util.ParameterBuilders.Impl;

namespace AliPay.Services
{
    /// <summary>
    /// 支付宝返回服务
    /// </summary>
    public class AlipayReturnService : AlipayNotifyServiceBase, IAlipayReturnService {
        /// <summary>
        /// 初始化支付宝返回服务
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        public AlipayReturnService( IAliPayConfigProvider configProvider ) : base(configProvider){
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        /// <param name="builder">参数生成器</param>
        protected override void Load( UrlParameterBuilder builder ) {
            builder.LoadQuery();
        }

        /// <summary>
        /// 获取日志标题
        /// </summary>
        protected override string GetCaption() {
            return "支付宝返回";
        }
    }
}
