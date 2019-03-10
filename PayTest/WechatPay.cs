using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payments.Extensions;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Enums;
using Payments.Wechatpay.Parameters.Requests;
using System;
using System.IO;
using System.Text;

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

            serviceDescriptors.AddWechatPay( w =>
            {
                w.AppId = "wx6e95a65ad4ee0135";
                w.MerchantId = "1517630381";
                w.PrivateKey = "XIAKEweixinpay2019shjGGYGHD54hlk";
                w.NotifyUrl = "https://www.baidu.com";
            });
            serviceDescriptors.AddPayService();
            serviceProvider = serviceDescriptors.BuildServiceProvider();
        }

        [TestMethod]
        public void WechatPayTest()
        {
            //Native 下单 

            string orderId = "77785522288585877856";

            var wechatpayNativePayService = serviceProvider.GetService<IWechatpayMWebPayService>();
            var wechatpayNativePayRequest = new WechatpayMWebPayRequest()
            {
                Body = "sssss",
                OutTradeNo = orderId,
                TotalFee = 0.01m,
                Attach = "dadadaaaa",
                FeeType= FeeType.CNY,
                Detail = new WechatpayPayRequestBase.GoodsDetail()
                {
                    GoodsId= "GoodsId",
                    WxpayGoodsId= "WxpayGoodsId",
                    GoodsName= "GoodsName",
                    Quantity=2,
                    Price=1

                },
                Receipt="Y",
                LimitPay= "no_credit",

                ProductId= "ProductId",
                GoodsTag= "GoodsTag",
                TimeExpire= DateTime.Now.AddHours(2),
                TimeStart=DateTime.Now,
                SceneInfo=new WechatpayPayRequestBase.SotreSceneInfo() {
                    Id= "Id",
                    Address= "Address",
                    AreaCode= "AreaCode",
                    Name= "Name"
                },
            OpenId="98980989080980"
               
            };

            var result1 = wechatpayNativePayService.PayAsync(wechatpayNativePayRequest).GetAwaiter().GetResult();

            var wechatOrderQueryService = serviceProvider.GetService<IWechatOrderQueryService>();

            var result2 = wechatOrderQueryService.QueryAsync(new WechatOrderQueryRequest()

            {

                OutTradeNo = orderId

            }).GetAwaiter().GetResult();





            //밑균땐데

            var wechatCloseOrderService = serviceProvider.GetService<IWechatCloseOrderService>();

            var result3 = wechatCloseOrderService.CloseAsync(new WechatCloseOrderRequest()

            {

                OutTradeNo = orderId

            }).GetAwaiter().GetResult();



            //꿴璂땐데

            var result4 = wechatOrderQueryService.QueryAsync(new WechatOrderQueryRequest()

            {

                OutTradeNo = orderId

            }).GetAwaiter().GetResult();





            //藁운땐데륩蛟

            var wechatRefundOrderService = serviceProvider.GetService<IWechatRefundOrderService>();

            var wechatRefundOrderRequest = new WechatRefundOrderRequest()

            {

                OutRefundNo = "123456789",

                OutTradeNo = orderId,

                TotalFee = 0.01m,

                RefundFee = 0.01m,



                //NotifyUrl= "https://weixin.qq.com/notify/"



            };

            var result22 = wechatRefundOrderService.RefundAsync(wechatRefundOrderRequest).GetAwaiter().GetResult();



            //꿴璂藁운땐데

            var wechatRefundQueryService = serviceProvider.GetService<IWechatRefundQueryService>();

            var wechatRefundQueryRequest = new WechatRefundQueryRequest()

            {

                OrderId = orderId

            };

            var result2231 = wechatRefundQueryService.RefundQuery(wechatRefundQueryRequest).GetAwaiter().GetResult();



        }





        //[TestMethod]

        //public void AliPayTest()

        //{

        //    string orderId = "2015032001010100";



        //    var alipayPagePayService = serviceProvider.GetService<IAlipayPagePayService>();



        //    AlipayPagePayRequest alipayPagePayRequest = new AlipayPagePayRequest()

        //    {

        //        Subject = "iphone",

        //        OrderId = orderId,

        //        Money = 22,

        //        ////Attach = "123",

        //        //ReturnUrl="http://www.alibaba.com",

        //        //NotifyUrl= "http://www.alibaba.com",

        //        Body = "cccc",



        //    };

        //    var result = alipayPagePayService.PayAsync(alipayPagePayRequest).GetAwaiter().GetResult();

        //    File.WriteAllText(@"D:\hhh\\a.html", result.Result, Encoding.UTF8);

        //    alipayPagePayService.RedirectAsync(alipayPagePayRequest).GetAwaiter().GetResult();



        //}



    }
}
