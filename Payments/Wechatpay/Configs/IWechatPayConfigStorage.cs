using System.Threading.Tasks;
using Payments.Util.ParameterBuilders;
namespace Payments.WechatPay.Configs
{
    /// <summary>
    /// 微信支付配置提供器
    /// </summary>
    public interface IWechatPayConfigStorage
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="parameters">参数服务</param>
        Task<WechatPayConfig> GetConfigAsync(string name);

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        WechatPayConfig GetConfig(string name);
    }
}
