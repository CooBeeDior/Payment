 using Newtonsoft.Json;
using Payments.WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Payments.WechatPay.Parameters.Response
{
    /// <summary>
    /// ΢��MWeb֧��
    /// </summary>
    [XmlRoot("xml")]
    public class WechatPayMWebPayResponse : WechatPayPayResponseBase
    {
        /// <summary>
        /// ֧����ת����
        /// mweb_urlΪ����΢��֧������̨���м�ҳ�棬��ͨ�����ʸ�url������΢�ſͻ��ˣ����֧��,mweb_url����Ч��Ϊ5����
        /// </summary>
        [XmlElement("mweb_url")]
        public virtual string MwebUrl { get; set; }
    }
}

