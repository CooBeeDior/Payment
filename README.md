# Payments
#### 基于netcore2.x实现的微信和支付宝支付的服务。

# 微信支付服务
#### Native支付【IWechatpayNativePayService】
#### App支付【IWechatpayAppPayService】
#### JsApi支付【IWechatpayJsApiPayService】
#### 小程序支付【IWechatpayMiniProgramPayService】
#### H5支付【IWechatpayMWebPayService】
#### 付款码支付【IWechatpayMicroPayService】

#### 查询支付订单【IWechatOrderQueryService】
#### 撤销支付订单【IWechatReverseOrderService】测试接口报错
#### 关闭支付订单【IWechatCloseOrderService】
#### 申请退款订单【IWechatRefundOrderService】
#### 退款订单查询【IWechatRefundQueryService】
#### 支付异步回调【IWechatpayNotifyService】
#### 退款异步支付回调【IWechatRefundNotifyService】

#### 下载对账单【】
#### 下载资金账单【】
#### 交易保障【】
#### 拉取订单评价数据【】

#### 授权码查询openid【】
#### 发放代金券【】
#### 查询代金券批次【】
#### 查询代金券信息【】

#### 发放普通红包【】
#### 发放裂变红包【】
#### 查询红包记录【】

#### 企业付款【】
#### 查询企业付款【】





# 支付宝支付
#### Page支付【IAlipayPagePayService】
#### 二维码支付【IAlipayQrCodePayService】
#### App支付【IAlipayAppPayService】
#### 条码支付【IAlipayBarcodePayService】
#### 手机wap支付【IAlipayWapPayService】
#### 异步回调【IAlipayNotifyService】
#### 同步回调【IAlipayReturnService】


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
 
