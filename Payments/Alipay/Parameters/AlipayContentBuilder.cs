using Payments.Alipay.Configs;
using Payments.Core;
using Util;
using Util.Parameters;
using Util.Parameters.Formats;

namespace Payments.Alipay.Parameters
{
    /// <summary>
    /// 支付宝内容参数生成器
    /// </summary>
    public class AlipayContentBuilder : ParameterBuilder
    {
        /// <summary>
        /// 初始化支付参数
        /// </summary>
        /// <param name="param">支付参数</param>
        //public AlipayContentBuilder Init( PayParam param ) {
        //    if( param == null )
        //        return this;
        //    return OutTradeNo( param.OrderId )
        //        .Subject( param.Subject )
        //        .TotalAmount( param.Money )
        //        .TimeoutExpress( param.Timeout );
        //}

        /// <summary>
        /// 设置商户订单号
        /// </summary>
        /// <param name="orderId">商户订单号</param>
        public AlipayContentBuilder OutTradeNo(string orderId)
        {
            Add(AlipayConst.OutTradeNo, orderId);
            return this;
        }

        /// <summary>
        /// 设置场景
        /// </summary>
        /// <param name="scene">场景</param>
        public AlipayContentBuilder Scene(string scene)
        {
            Add(AlipayConst.Scene, scene);
            return this;
        }

        /// <summary>
        /// 设置用户付款授权码
        /// </summary>
        /// <param name="code">用户付款授权码</param>
        public AlipayContentBuilder AuthCode(string code)
        {
            Add(AlipayConst.AuthCode, code);
            return this;
        }

        /// <summary>
        /// 设置订单标题
        /// </summary>
        /// <param name="subject">订单标题</param>
        public AlipayContentBuilder Subject(string subject)
        {
            Add(AlipayConst.Subject, subject);
            return this;
        }

        /// <summary>
        /// 设置支付超时
        /// </summary>
        /// <param name="timeout">支付超时间隔，单位：分钟</param>
        public AlipayContentBuilder TimeoutExpress(int timeout)
        {
            Add(AlipayConst.TimeoutExpress, $"{timeout}m");
            return this;
        }

        /// <summary>
        /// 设置金额
        /// </summary>
        /// <param name="amount">支付金额</param>
        public AlipayContentBuilder TotalAmount(decimal amount)
        {
            Add(AlipayConst.TotalAmount, amount.ToString("#0.00"));
            return this;
        }

        /// <summary>
        /// 销售产品码，与支付宝签约的产品码名称。 注：目前仅支持FAST_INSTANT_TRADE_PAY
        /// </summary>
        /// <param name="product_code"></param>
        /// <returns></returns>
        public AlipayContentBuilder ProductCode(string product_code)
        {
            Add(AlipayConst.ProductCode, product_code);
            return this;
        }
        /// <summary>
        /// 订单描述
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public AlipayContentBuilder Body(string body)
        {
            Add(AlipayConst.Body, body);
            return this;
        }
        /// <summary>
        /// 同步回调Url
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public AlipayContentBuilder ReturnUrl(string returnUrl)
        {
            Add(AlipayConst.ReturnUrl, returnUrl);
            return this;
        }

        /// <summary>
        /// 异步回调Url
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public AlipayContentBuilder NotifyUrl(string notifyUrl)
        {
            Add(AlipayConst.NotifyUrl, notifyUrl);
            return this;
        }

        /// <summary>
        /// 公用回传参数，如果请求时传递了该参数，则返回给商户时会回传该参数。支付宝只会在异步通知时将该参数原样返回。本参数必须进行UrlEncode之后才可以发送给支付宝
        /// </summary>
        /// <param name="passback_params"></param>
        /// <returns></returns>
        public AlipayContentBuilder PassbackParams(string passback_params)
        {
            Add(AlipayConst.PassbackParams, passback_params);
            return this;
        }

        /// <summary>
        /// 输出结果
        /// </summary>
        public override string ToString()
        {
            return Result(UrlParameterFormat.Instance);
        }
    }
}
