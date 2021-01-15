 using Newtonsoft.Json;
using WechatPay.Parameters.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace WechatPay.Parameters.Response
{
    /// <summary>
    /// H5��ǩԼ
    /// </summary>
    [XmlRoot("xml")]
    public class WechatH5EntrustWebResponse : WechatPayResponse
    {
        /// <summary>
        /// ��תǩԼҳ��url���û�ͨ����ת���ʴ�URL���ɽ���΢��ǩԼҳ�棬����ǩԼ��
        /// ע������������תurl��ҳ���ַ������΢�ź�̨���ã�����H5ǩԼȨ��ʱ���ã���
        /// </summary>
        [XmlElement("redirect_url")]
        public virtual string RedirectUrl { get; set; }
        
    }
}

