using Payments.Core.Enum;
using Payments.Extensions;
using Payments.Util.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WechatPay.Enums;

namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 下载资金账单
    /// </summary>
    public class WechatDownloadfundflowRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 签名类型，目前仅支持HMAC-SHA256
        /// </summary>
        public string SignType { get; } = PaySignType.HmacSha256.Description();


        /// <summary>
        /// 对账单日期
        /// 下载对账单的日期，格式：20140603
        /// </summary>
        [Required]
        [MaxLength(8)]
        public string BillDate { get; set; }
        /// <summary>
        /// 资金账户类型
        /// 账单的资金来源账户：
        /// Basic 基本账户
        /// Operation 运营账户
        /// Fees 手续费账户
        /// </summary>
        [MaxLength(8)]
        public string AccountType { get; set; }
        /// <summary>
        /// 压缩账单
        /// 非必传参数，固定值：GZIP，返回格式为.gzip的压缩包账单。不传则默认为数据流形式。
        /// </summary>
        public string TarType { get; set; }



    }
}
