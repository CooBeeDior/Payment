using Payments.Exceptions;
using Payments.Properties;
using Payments.Util.Validations;
using Payments.Util.Validations.Attribbutes;
using Payments.WechatPay.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Payments.WechatPay.Parameters.Requests
{
    /// <summary>
    /// 订单支付参数
    /// </summary>
    public class WechatPayPayRequestBase : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 订单标题
        /// </summary>
        [Required]
        [MaxLength(128)]
        public virtual string Body { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string OutTradeNo { get; set; }

        /// <summary>
        /// 设备号
        /// 自定义参数，可以为终端设备号(门店号或收银设备ID)，PC网页或公众号内支付可以传"WEB"
        /// </summary> 
        [MaxLength(32)]
        public virtual string DeviceInfo { get; set; }


        /// <summary>
        /// 支付金额
        /// </summary>
        [Required]
        [MinValue(0)]
        public virtual decimal TotalFee { get; set; }

        /// <summary>
        /// 商品详细描述
        /// </summary>
        [MaxLengthObjectToJson(6000)]
        public virtual GoodsDetail Detail { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        [MaxLength(127)]
        public virtual string Attach { get; set; }

        /// <summary>
        /// 货币类型
        /// </summary>
        public virtual FeeType? FeeType { get; set; }

        /// <summary>
        /// 交易起始时间 格式为yyyyMMddHHmmss
        /// </summary>  
        public virtual DateTime? TimeStart { get; set; }

        /// <summary>
        /// 交易结束时间 格式为yyyyMMddHHmmss
        /// </summary>   
        public virtual DateTime? TimeExpire { get; set; }

        /// <summary>
        /// 订单优惠标记
        /// </summary>
        [MaxLength(32)]
        public virtual string GoodsTag { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [MaxLength(32)]
        public virtual string ProductId { get; set; }

        /// <summary>
        /// 指定支付方式
        /// </summary>
        [MaxLength(32)]
        public virtual string LimitPay { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        [MaxLength(128)]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// 电子发票入口开放标识 Y，传入Y时，支付成功消息和支付详情页将出现开票入口
        /// </summary>
        [MaxLength(8)]
        public virtual string Receipt { get; set; }

        /// <summary>
        /// 场景信息
        /// {"store_info" : {
        ///    "id": "SZTX001",
        ///    "name": "腾大餐厅",
        ///    "area_code": "440305",
        ///    "address": "科技园中一路腾讯大厦" }
        ///    }
        /// </summary>
        [MaxLength(256)]
        public virtual string SceneInfo { get; set; }


        /// <summary>
        /// 回调通知地址
        /// </summary>
        public virtual string NotifyUrl { get; set; }





        /// <summary>
        /// 商品详情
        /// </summary>
        public class GoodsDetail
        {
            /// <summary>
            /// 商品编码
            /// </summary>
            [MaxLength(32)]
            public string GoodsId { get; set; }

            /// <summary>
            /// 微信支付定义的统一商品编号
            /// </summary>
            [MaxLength(32)]
            public string WxpayGoodsId { get; set; }

            /// <summary>
            /// 商品的实际名称
            /// </summary>
            [Required]
            [MaxLength(256)]
            public string GoodsName { get; set; }

            /// <summary>
            /// 用户购买的数量
            /// </summary>
            [Required]
            [MinValue(0)]
            public int Quantity { get; set; }

            /// <summary>
            /// 价格 单位为：分。如果商户有优惠，需传输商户优惠后的单价(例如：用户对一笔100分的订单使用了商场发的纸质优惠券100-50，则活动商品的单价应为原单价-50) 
            /// </summary>
            [Required]
            [MinValue(0)]
            public int Price { get; set; }

        }

        /// <summary>
        /// 场景信息对象
        /// </summary>
        public class StoreSceneInfo 
        {
            public StoreSceneInfoObj store_info { get; set; }
        }
        /// <summary>
        /// 场景信息
        /// </summary>
        public class StoreSceneInfoObj
        {
            /// <summary>
            /// 门店编号
            /// </summary>
            [MaxLength(32)]
            public string id { get; set; }

            /// <summary>
            /// 门店名称 
            /// </summary>
            [MaxLength(64)]
            public string name { get; set; }

            /// <summary>
            /// 门店行政区划码
            /// </summary>
            [MaxLength(6)]
            public string area_code { get; set; }

            /// <summary>
            /// 门店详细地址 
            /// </summary>
            [MaxLength(128)]
            public string address { get; set; }
        }



    



    }
}
