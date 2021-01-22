﻿using Payments.Core.Enum;
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
    /// 拉取订单评价数据
    /// </summary>
    public class WechatBatchquerycommentRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 签名类型，目前仅支持HMAC-SHA256
        /// </summary>
        public string SignType { get; } = PaySignType.HmacSha256.Description();
        /// <summary>
        /// 开始时间 按用户评论时间批量拉取的起始时间，格式为yyyyMMddHHmmss
        /// </summary>
        [Required]
        [MaxLength(19)]
        public string BeginTime { get; set; }

        /// <summary>
        /// 结束时间 按用户评论时间批量拉取的结束时间，格式为yyyyMMddHHmmss
        /// </summary>
        [Required]
        [MaxLength(19)]
        public string EndTime { get; set; }
        /// <summary>
        /// 位移
        /// 指定从某条记录的下一条开始返回记录。
        /// 接口调用成功时，会返回本次查询最后一条数据的offset。
        /// 商户需要翻页时，应该把本次调用返回的offset 作为下次调用的入参。
        /// 注意offset是评论数据在微信支付后台保存的索引，未必是连续的
        /// </summary>
        [Required]
        public int Offset { get; set; }
        /// <summary>
        /// 条数 一次拉取的条数, 最大值是200，默认是200
        /// </summary>
        public int Limit { get; set; }
    }
}
