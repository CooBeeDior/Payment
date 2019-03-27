using Payments.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payments.Core.Response
{
    /// <summary>
    /// 支付结果
    /// </summary>
    public interface IResponse
    {

        /// <summary>
        /// SUCCESS/FAIL
        /// 此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断   
        string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息，如非空，为错误原因     
        /// 签名失败       
        /// 参数格式校验错误
        /// </summary>     
        string ReturnMsg { get; set; }

        /// <summary>
        /// 业务结果 SUCCESS/FAIL
        /// </summary>     
        string ResultCode { get; set; }


        /// <summary>
        /// 调用接口提交的公众账号ID
        /// </summary>
        string AppId { get; set; }

        /// <summary>
        /// 调用接口提交的商户号
        /// </summary>
        string MchId { get; set; }

        /// <summary>
        /// 微信返回的随机字符串
        /// </summary>
        string NonceStr { get; set; }

        /// <summary>
        /// 微信返回的签名值，详见签名算法
        /// </summary>
        string Sign { get; set; }


        /// <summary>
        /// 附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用。
        /// </summary>
        string Attach { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        string ErrCode { get; set; }

        /// <summary>
        /// 当result_code为FAIL时返回错误描述，详细参见下文错误列表
        /// </summary>
        string ErrCodeDes { get; set; }
    }
}
