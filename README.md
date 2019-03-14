# Payments
#### 基于netcore2.x实现的微信和支付宝支付的服务。

# 微信支付服务
#### [Native支付](https://pay.weixin.qq.com/wiki/doc/api/native.php?chapter=6_1)【IWechatpayNativePayService】
#### [App支付](https://pay.weixin.qq.com/wiki/doc/api/app/app.php?chapter=8_1)【IWechatpayAppPayService】
#### [JsApi支付](https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=7_1)【IWechatpayJsApiPayService】
#### [小程序支付](https://pay.weixin.qq.com/wiki/doc/api/wxa/wxa_api.php?chapter=7_3&index=1)【IWechatpayMiniProgramPayService】
#### [H5支付](https://pay.weixin.qq.com/wiki/doc/api/H5.php?chapter=15_1)【IWechatpayMWebPayService】
#### [付款码支付](https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=5_1)【IWechatpayMicroPayService】

#### [授权码查询openid](https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140842)【】

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

#### [发放普通红包](https://pay.weixin.qq.com/wiki/doc/api/tools/cash_coupon.php?chapter=13_1)【】
#### [发放裂变红包](https://pay.weixin.qq.com/wiki/doc/api/tools/cash_coupon.php?chapter=13_1)【】
#### [查询红包记录](https://pay.weixin.qq.com/wiki/doc/api/tools/cash_coupon.php?chapter=13_1)【】

#### [企业付款](https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=14_1)【】
#### [查询企业付款](https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=14_1)【】

#### [申请签约](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_1&index=1)【】
#### [小程序纯签约](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_14&index=2)【】
#### [H5纯签约](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_16&index=3)【】
#### [支付中签约api](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_13&index=4)【】
#### [签约、解约结果通知](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_17&index=5)【】
#### [查询签约关系](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_2&index=6)【】
#### [申请扣款](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_3&index=7)【】
#### [申请解约](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_4&index=8)【】
#### [扣款结果通知](https://pay.weixin.qq.com/wiki/doc/api/pap.php?chapter=18_7&index=10)【】

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
       service.AddPay(a =>
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
 
