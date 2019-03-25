using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payments.Extensions;
using Payments.Util;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Enums;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Parameters.Response.Base;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

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

        [TestMethod]
        public void WechatPayTest()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WechatpayResponse));

            var ss = Xml.ToDocument(@" <xml><return_code><![CDATA[SUCCESS]]></return_code>
<return_msg><![CDATA[OK]]></return_msg>
<appid><![CDATA[wx6e95a65ad4ee0135]]></appid>
<mch_id><![CDATA[1517630381]]></mch_id>
<nonce_str><![CDATA[JA060YgGRC7PXUFG]]></nonce_str>
<sign><![CDATA[BE5D131909A925EAF484D804D08D5612]]></sign>
<result_code><![CDATA[SUCCESS]]></result_code>
<prepay_id><![CDATA[wx251754348985658526e14e053272098244]]></prepay_id>
<trade_type><![CDATA[NATIVE]]></trade_type>
<code_url><![CDATA[weixin://wxpay/bizpayurl?pr=iBYY0x3]]></code_url>
</xml>").CreateReader();
            var adadd = serializer.Deserialize(ss);
            //Native 下单 

            var wechatpayNativePayOneService = serviceProvider.GetService<IWechatpayNativePayOneService>();
            WechatpayNativePayOneRequest wechatpayNativePayOneRequest = new WechatpayNativePayOneRequest()
            {
                ProductId = "1123dwadawwaddaw45"
            };

            //var url = wechatpayNativePayOneService.BuildUrl(wechatpayNativePayOneRequest).GetAwaiter().GetResult();

            string orderId = "dawdao44o66owd2122";

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
                }.ToJson()

                //OpenId="98980989080980"

            };

            var result1 = wechatpayNativePayService.PayAsync(wechatpayNativePayRequest).GetAwaiter().GetResult();

            var wechatOrderQueryService = serviceProvider.GetService<IWechatOrderQueryService>();

            var result2 = wechatOrderQueryService.QueryAsync(new WechatOrderQueryRequest()

            {

                OutTradeNo = orderId

            }).GetAwaiter().GetResult();





            //查询

            var wechatCloseOrderService = serviceProvider.GetService<IWechatCloseOrderService>();

            var result3 = wechatCloseOrderService.CloseAsync(new WechatCloseOrderRequest()

            {

                OutTradeNo = orderId

            }).GetAwaiter().GetResult();



            //查询

            var result4 = wechatOrderQueryService.QueryAsync(new WechatOrderQueryRequest()

            {

                OutTradeNo = orderId

            }).GetAwaiter().GetResult();





            //退款

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



            //退款查询

            var wechatRefundQueryService = serviceProvider.GetService<IWechatRefundQueryService>();

            var wechatRefundQueryRequest = new WechatRefundQueryRequest()

            {

                OutTradeNo = orderId

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
