# Payments
#### 基于netcore实现的微信和支付宝支付等第三方的服务。


# 微信支付服务
#### 使用方法如下：
`MysqlWechatPayConfigStorage`继承`IWechatPayConfigStorage` 主要是多商户支付配置，根据不同名称获取不同的支付配置。
```c#
     serviceDescriptors.AddWechatPay(w =>
     {
         w.AppId = "wx1111111111111";
         w.MerchantId = "11111111111";
         w.PrivateKey = "xxxxxxxxxxxxxxxxxxx";
         w.NotifyUrl = "https://www.xxxx.com?NotifyUrl";

     }).AddWehcatpayStorage<MysqlWechatPayConfigStorage>();                        
           
```

根据`IWehcatPayServiceProvider`去拿微信支付的服务【IWechatPayNativePayService】,参数是商户支付配置的名称。
```c#
    public class PayController
    {
        private readonly IWechatPayNativePayService _wechatPayNativePayService;
        public PayController(IWehcatPayServiceProvider wehcatPayServiceProvider)
        {
            _wechatPayNativePayService = wehcatPayServiceProvider.GetService<IWechatPayNativePayService>("shanghu1");

        }
        public async Task<WechatPayResult<WechatPayNativePayResponse>> Pay(WechatPayNativePayRequest request)
        {
            var resp = await _wechatPayNativePayService.PayAsync(request);
            return resp; 
        }
    }
```

#### [Native支付](https://pay.weixin.qq.com/wiki/doc/api/native.php?chapter=6_1)【IWechatpayNativePayService】
#### [App支付](https://pay.weixin.qq.com/wiki/doc/api/app/app.php?chapter=8_1)【IWechatpayAppPayService】
#### [JsApi支付](https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=7_1)【IWechatpayJsApiPayService】
#### [小程序支付](https://pay.weixin.qq.com/wiki/doc/api/wxa/wxa_api.php?chapter=7_3&index=1)【IWechatpayMiniProgramPayService】
#### [H5支付](https://pay.weixin.qq.com/wiki/doc/api/H5.php?chapter=15_1)【IWechatpayMWebPayService】
#### [付款码支付](https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=5_1)【IWechatpayMicroPayService】

#### [授权码查询openid](https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140842)【IWechatAuthorizeService,IWechatAccessTokenService】

#### 查询支付订单【IWechatOrderQueryService】
#### 撤销支付订单【IWechatReverseOrderService】 
#### 关闭支付订单【IWechatCloseOrderService】
#### 申请退款订单【IWechatRefundOrderService】
#### 退款订单查询【IWechatRefundQueryService】
#### 支付异步回调【IWechatpayNotifyService】
#### 退款异步支付回调【IWechatRefundNotifyService】

#### 下载对账单【】
#### 下载资金账单【】
#### 交易保障【】
#### 拉取订单评价数据【】

#### [发放代金券](https://pay.weixin.qq.com/wiki/doc/api/tools/sp_coupon.php?chapter=12_1)【】
#### [查询代金券批次](https://pay.weixin.qq.com/wiki/doc/api/tools/sp_coupon.php?chapter=12_1)【】
#### [查询代金券信息](https://pay.weixin.qq.com/wiki/doc/api/tools/sp_coupon.php?chapter=12_1)【】

#### [发放普通红包](https://pay.weixin.qq.com/wiki/doc/api/tools/cash_coupon.php?chapter=13_1)【IWechatSendRedPackService】
#### [发放裂变红包](https://pay.weixin.qq.com/wiki/doc/api/tools/cash_coupon.php?chapter=13_1)【IWechatSendGroupRedPackService】
#### [查询红包记录](https://pay.weixin.qq.com/wiki/doc/api/tools/cash_coupon.php?chapter=13_1)【IWechatpayHbInfoService】

#### [企业付款](https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=14_1)【IWechatTransfersService】
#### [查询企业付款](https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=14_1)【IWechatGetTransferInfoService】

#### [申请签约](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_1&index=1)【IWechatEntrustWebService】
#### [小程序纯签约](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_14&index=2) 
#### [H5纯签约](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_16&index=3)【IWechatH5EntrustWebService】
#### [支付中签约api](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_13&index=4)【IWechatContractOrderService】
#### [签约、解约结果通知](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_17&index=5)【IWechatSignNotifyService】
#### [查询签约关系](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_2&index=6)【IWechatQueryContractService】
#### [申请扣款](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_3&index=7)【IWechatPapPayApplyService】
#### [申请解约](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_4&index=8)【IWechatDeleteContractService】
#### [扣款结果通知](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_7&index=10)【IWechatContractNotifyService】
#### [查询扣款通知](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_10&index=13)IWechatPapOrderQueryService


# 支付宝支付
#### Page支付【IAlipayPagePayService】
#### 二维码支付【IAlipayQrCodePayService】
#### App支付【IAlipayAppPayService】
#### 条码支付【IAlipayBarcodePayService】
#### 手机wap支付【IAlipayWapPayService】
#### 异步回调【IAlipayNotifyService】
#### 同步回调【IAlipayReturnService】



 
