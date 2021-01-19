using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payments.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WechatPay;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Enums;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services;

namespace PayTest
{

    public class CustomePayController
    {
        private readonly ICustomeWehcatPayService _customeWehcatPayService;
        public CustomePayController(IWehcatPayServiceProvider wehcatPayServiceProvider)
        {
            _customeWehcatPayService = wehcatPayServiceProvider.GetService<ICustomeWehcatPayService>("shanghu1");

        }
        public async Task<WechatPayResult<WechatPayResponse>> Pay()
        {
            //设置请求url
            _customeWehcatPayService.SetUrl("https://api.mch.weixin.qq.com/new/aaa");            
            IDictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("params1", "11");
            dic.Add("params2", "22");
            dic.Add("params3", "33");
            //构造参数
            _customeWehcatPayService.SetExtensionParameter(dic);
            var resp = await _customeWehcatPayService.Request();          
            return resp;
        }
    }
    public class MysqlWechatPayConfigStorage : IWechatPayConfigStorage
    {
        public WechatPayConfig GetConfig(string name)
        {
            return null;
        }

        public Task<WechatPayConfig> GetConfigAsync(string name)
        {
            return null;
        }
    }
    [TestClass]
    public class Tests
    {
        ServiceProvider serviceProvideraaa = null;
        IWehcatPayServiceProvider serviceProvider = null;
        public Tests()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddLogging();
            serviceDescriptors.AddHttpContextAccessor();
            serviceDescriptors.AddHttpClient();

            serviceDescriptors.AddWechatPay(w =>
           {
               w.AppId = "wx6e95a65ad4ee0135";
               w.MerchantId = "1517630381";
               w.PrivateKey = "XIAKEweixinpay2019shjGGYGHD54hlk";
               w.NotifyUrl = "https://www.baidu.com";

           }).AddWehcatpayStorage<MysqlWechatPayConfigStorage>();

            serviceProvideraaa = serviceDescriptors.BuildServiceProvider();

            serviceProvider = serviceProvideraaa.GetService<IWehcatPayServiceProvider>();


        }

        public string GetAAA<T>(string aa, IWehcatPayServiceProvider serviceProvider, string bb = "3333", params object[] args)
        {
            return "124";
        }

        /// <summary>
        /// Native下单
        /// </summary>
        [TestMethod]
        public void WechatNativePayTest()
        {
            var aaa=typeof(Tests).GetMethod("GetAAA").GetParameters();
            var dic = new Dictionary<string, object>();
            dic.Add(WechatPayConst.OutTradeNo, "1212");
            var sss = serviceProvider.GetService<ICustomeWehcatPayService>();
            sss.SetUrl("pay/orderquery").SetExtensionParameter(dic);

            var resu31lt = sss.Request().GetAwaiter().GetResult();




            //1.生成订单
            string orderId = "789793535345";
            var WechatPayNativePayService = serviceProvider.GetService<IWechatPayNativePayService>();
            var WechatPayNativePayRequest = new WechatPayNativePayRequest()
            {
                Body = "sssss",
                OutTradeNo = orderId,
                TotalFee = 0.01m,
                Attach = "dadadaaaa",
                FeeType = FeeType.CNY,
                Detail = new WechatPayPayRequestBase.GoodsDetail()
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
                SceneInfo = new WechatPayPayRequestBase.StoreSceneInfo
                {

                    store_info = new WechatPayPayRequestBase.StoreSceneInfoObj()
                    {
                        id = "Id",
                        address = "Address",
                        area_code = "AreaCode",
                        name = "Name"
                    },
                }.ToJson(),

                //OpenId = "98980989080980"

            };

            var result = WechatPayNativePayService.PayAsync(WechatPayNativePayRequest).GetAwaiter().GetResult();

            //2。查询订单

            var wechatOrderQueryService = serviceProvider.GetService<IWechatOrderQueryService>();

            var result2 = wechatOrderQueryService.QueryAsync(new WechatOrderQueryRequest()
            {
                OutTradeNo = orderId

            }).GetAwaiter().GetResult();

            //3.关闭订单
            var wechatCloseOrderService = serviceProvider.GetService<IWechatCloseOrderService>();
            //var adad = new Dictionary<string, object>() { };
            //adad.Add("1", "2");
            //wechatCloseOrderService.ExtensionParameter(adad);
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
            //var WechatPayNativePayService = serviceProvider.GetService<IWechatPayNativePayService>();
            //var WechatPayNativePayRequest = new WechatPayNativePayRequest()
            //{
            //    Body = "sssss",
            //    OutTradeNo = orderId,
            //    TotalFee = 0.01m,
            //    Attach = "dadadaaaa",
            //    FeeType = FeeType.CNY,
            //    Detail = new WechatPayPayRequestBase.GoodsDetail()
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
            //    SceneInfo = new WechatPayPayRequestBase.StoreSceneInfo
            //    {

            //        store_info = new WechatPayPayRequestBase.StoreSceneInfoObj()
            //        {
            //            id = "Id",
            //            address = "Address",
            //            area_code = "AreaCode",
            //            name = "Name"
            //        },
            //    }.ToJson(),

            //    //OpenId = "98980989080980"

            //};
            //var result = WechatPayNativePayService.PayAsync(WechatPayNativePayRequest).GetAwaiter().GetResult();
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
