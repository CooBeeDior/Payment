# Payments
#### 基于netcore2.x实现的微信和支付宝支付的服务。

# 微信支付服务
#### 1.Native支付【IWechatpayNativePayService】
#### 2.App支付【IWechatpayAppPayService】
#### 3.JsApi支付【IWechatpayJsApiPayService】
#### 4.小程序支付【IWechatpayMiniProgramPayService】
#### 5.查询支付订单【IWechatOrderQueryService】
#### 6.关闭支付订单【IWechatCloseOrderService】
#### 7.退款支付订单【IWechatRefundOrderService】
#### 8.退款支付订单查询【IWechatRefundQueryService】
#### 9.支付异步回调【IWechatpayNotifyService】
#### 10.退款异步支付回调【IWechatRefundNotifyService】

# 支付宝支付
#### 1.Page支付【IAlipayPagePayService】
#### 2.二维码支付【IAlipayQrCodePayService】
#### 3.App支付【IAlipayAppPayService】
#### 4.条码支付【IAlipayBarcodePayService】
#### 5.手机wap支付【IAlipayWapPayService】
#### 6.异步回调【IAlipayNotifyService】
#### 7.同步回调【IAlipayReturnService】


# 使用方法，注册支付服务到容器里面.
```c#
       serviceDescriptors.AddPay(a =>
       {

           a.GatewayUrl = "https://openapi.alipay.com/gateway.do";
           a.AppId = "xxxxxxx";
           a.PrivateKey = " xxx";
           a.PublicKey = " xxx";
           a.Charset = "utf-8";
           //a.NotifyUrl = "https://www.xxxxxx.com";
       }, w =>
       {

           w.AppId = "xxxxxxx";
           w.MerchantId = "xxxxx";
           w.PrivateKey = "xxxxxx";
           w.NotifyUrl = "https://www.xxxx.com";

       });
```
 
