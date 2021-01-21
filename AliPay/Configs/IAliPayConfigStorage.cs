using System.Threading.Tasks;
using AliPay.Configs;
using Payments.Util.ParameterBuilders;
namespace AliPay.Configs
{
    /// <summary>
    /// 微信支付配置提供器
    /// </summary>
    public interface IAliPayConfigStorage
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="parameters">参数服务</param>
        Task<AliPayConfig> GetConfigAsync(string name);

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        AliPayConfig GetConfig(string name);
    }
}
