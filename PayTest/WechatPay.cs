using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payments.Extensions;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Enums;
using Payments.Wechatpay.Parameters.Requests;
using System;

namespace PayTest
{

    [TestClass]
    public class Tests
    {
        ServiceProvider serviceProvider = null;
        public Tests()
        {

            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddLogging();
            serviceDescriptors.AddHttpContextAccessor();
            serviceDescriptors.AddWechatPay(w =>
           {
               w.AppId = "wx6e95a65ad4ee0135";
               w.MerchantId = "1517630381";
               w.PrivateKey = "XIAKEweixinpay2019shjGGYGHD54hlk";
               w.NotifyUrl = "https://www.baidu.com";

           });

            serviceProvider = serviceDescriptors.BuildServiceProvider();
        }



        /// <summary>
        /// Native下单
        /// </summary>
        [TestMethod]
        public void WechatNativePayTest()
        {
            //1.生成订单
            string orderId = "123123123123";
            var wechatpayNativePayService = serviceProvider.GetService<IWechatpayNativePayService>();
            var wechatpayNativePayRequest = new WechatpayNativePayRequest()
            {
                Body = "sssss",
                OutTradeNo = orderId,
                TotalFee = 0.01m,
                Attach = "dadadaaaa",
                FeeType = FeeType.CNY,
                Detail = new WechatpayPayRequestBase.GoodsDetail()
                {
                    GoodsId = "GoodsId",
                    WxpayGoodsId = "WxpayGoodsId",
                    GoodsName = "GoodsName",
                    Quantity = 2,
                    Price = 1

                },
                Receipt = "Y",
                LimitPay = "no_credit",

                ProductId = "ProductId",
                GoodsTag = "GoodsTag",
                TimeExpire = DateTime.Now.AddHours(2),
                TimeStart = DateTime.Now,
                SceneInfo = new WechatpayPayRequestBase.StoreSceneInfo
                {

                    store_info = new WechatpayPayRequestBase.StoreSceneInfoObj()
                    {
                        id = "Id",
                        address = "Address",
                        area_code = "AreaCode",
                        name = "Name"
                    },
                }.ToJson(),

                //OpenId = "98980989080980"

            };
            var result = wechatpayNativePayService.PayAsync(wechatpayNativePayRequest).GetAwaiter().GetResult();

            //2。查询订单
            var wechatOrderQueryService = serviceProvider.GetService<IWechatOrderQueryService>();
            var result2 = wechatOrderQueryService.QueryAsync(new WechatOrderQueryRequest()
            {
                OutTradeNo = orderId

            }).GetAwaiter().GetResult();

            //3.关闭订单
            var wechatCloseOrderService = serviceProvider.GetService<IWechatCloseOrderService>();
            var result3 = wechatCloseOrderService.CloseAsync(new WechatCloseOrderRequest()
            {
                OutTradeNo = orderId

            }).GetAwaiter().GetResult();

            //4.查询订单
            var result4 = wechatOrderQueryService.QueryAsync(new WechatOrderQueryRequest()
            {
                OutTradeNo = orderId

            }).GetAwaiter().GetResult();


        }


        /// <summary>
        /// Native退款
        /// </summary>
        [TestMethod]
        public void WechatNativePayRefundTest()
        {
            //1.生成订单
            string orderId = "xxsss1111111";
            //var wechatpayNativePayService = serviceProvider.GetService<IWechatpayNativePayService>();
            //var wechatpayNativePayRequest = new WechatpayNativePayRequest()
            //{
            //    Body = "sssss",
            //    OutTradeNo = orderId,
            //    TotalFee = 0.01m,
            //    Attach = "dadadaaaa",
            //    FeeType = FeeType.CNY,
            //    Detail = new WechatpayPayRequestBase.GoodsDetail()
            //    {
            //        GoodsId = "GoodsId",
            //        WxpayGoodsId = "WxpayGoodsId",
            //        GoodsName = "GoodsName",
            //        Quantity = 2,
            //        Price = 1

            //    },
            //    Receipt = "Y",
            //    LimitPay = "no_credit",

            //    ProductId = "ProductId",
            //    GoodsTag = "GoodsTag",
            //    TimeExpire = DateTime.Now.AddHours(2),
            //    TimeStart = DateTime.Now,
            //    SceneInfo = new WechatpayPayRequestBase.StoreSceneInfo
            //    {

            //        store_info = new WechatpayPayRequestBase.StoreSceneInfoObj()
            //        {
            //            id = "Id",
            //            address = "Address",
            //            area_code = "AreaCode",
            //            name = "Name"
            //        },
            //    }.ToJson(),

            //    //OpenId = "98980989080980"

            //};
            //var result = wechatpayNativePayService.PayAsync(wechatpayNativePayRequest).GetAwaiter().GetResult();
            //string url = result?.Data?.CodeUrl;
            //去支付

            //2。查询订单
            var wechatOrderQueryService = serviceProvider.GetService<IWechatOrderQueryService>();
            var result2 = wechatOrderQueryService.QueryAsync(new WechatOrderQueryRequest()
            {
                OutTradeNo = orderId

            }).GetAwaiter().GetResult();

            //3.1退款订单
            var wechatRefundOrderService = serviceProvider.GetService<IWechatRefundOrderService>();
            var wechatRefundOrderRequest = new WechatRefundOrderRequest()
            {
                OutRefundNo = orderId,
                OutTradeNo = orderId,
                TotalFee = 0.01m,
                RefundFee = 0.01m,
                //NotifyUrl= "https://weixin.qq.com/notify/"
            };
            var result31 = wechatRefundOrderService.RefundAsync(wechatRefundOrderRequest).GetAwaiter().GetResult();



            //3.2退款查询
            var wechatRefundQueryService = serviceProvider.GetService<IWechatRefundQueryService>();
            var wechatRefundQueryRequest = new WechatRefundQueryRequest()
            {
                OutTradeNo = orderId
            };
            var result32 = wechatRefundQueryService.RefundQuery(wechatRefundQueryRequest).GetAwaiter().GetResult();

            //4.查询订单
            var result4 = wechatOrderQueryService.QueryAsync(new WechatOrderQueryRequest()
            {
                OutTradeNo = orderId

            }).GetAwaiter().GetResult();


        }










    }
}
