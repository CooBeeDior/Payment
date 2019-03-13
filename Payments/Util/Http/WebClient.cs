using Payments.Extensions;
using Payments.Util.ObjectPools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Util.Http
{
    public class WebClient
    {
        /// <summary>
        /// 请求路径
        /// </summary>
        public Uri Url { get; private set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public HttpMethod Method { get; private set; }


        /// <summary>
        /// 内容编码
        /// </summary>
        public Encoding ContentEncoding { get; private set; } = Encoding.UTF8;

        /// <summary>
        /// Headers
        /// </summary>
        public IDictionary<string, object> Headers { get; private set; }


        /// <summary>
        /// 请求内容
        /// </summary>
        public HttpContent Content { get; private set; }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public WebClient Post(string url)
        {
            this.Method = HttpMethod.Post;
            this.Url = new Uri(url);
            return this;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public WebClient Get(string url)
        {
            this.Method = HttpMethod.Get;
            this.Url = new Uri(url);
            return this;
        }

        /// <summary>
        /// xml数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public WebClient XmlData(IDictionary<string, object> data)
        {
            var xmlData = data.ToXml();
            Content = new StringContent(xmlData, ContentEncoding, "text/xml");
            return this;
        }
        /// <summary>
        /// xml数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public WebClient XmlData(string data)
        {
            Content = new StringContent(data, ContentEncoding, "text/xml");
            return this;
        }

        /// <summary>
        /// Json数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public WebClient JsonData<T>(T data)  
        {
            var jsonData = data.ToJson();
            Content = new StringContent(jsonData, ContentEncoding, "application/json");
            return this;
        }

        /// <summary>
        /// Json数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public WebClient JsonData(IDictionary<string, object> data)
        {
            return this.JsonData<IDictionary<string, object>>(data);
        }

        /// <summary>
        /// Json数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public WebClient JsonData(string data)
        {
            var jsonData = data.ToJson();
            Content = new StringContent(jsonData, ContentEncoding, "application/json");
            return this;
        }

        /// <summary>
        /// FormUrlEncodedContent
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public WebClient FormUrlEncodedContentData(IDictionary<string, object> data)
        {
            Content = new FormUrlEncodedContent(data.ToDictionary(t => t.Key, t => t.Value.SafeString()));
            return this;
        }

        /// <summary>
        /// 设置编码格式
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public WebClient SetContentEncoding(Encoding encoding)
        {
            this.ContentEncoding = encoding;
            return this;
        }

        public WebClient AddHeaders(IDictionary<string, object> headers)
        {
            this.Headers = headers;
            return this;
        }
        /// <summary>
        /// 请求
        /// </summary>
        /// <returns></returns>
        public Task<HttpResponseMessage> ResultAsync()
        {
            return ObjectPoolManager<HttpClient>.HandleAsync<HttpResponseMessage>(async httpclient =>
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(this.Method, Url);
                httpRequestMessage.Content = Content;
                if (Headers != null)
                {
                    foreach (var header in Headers)
                    {
                        httpRequestMessage.Headers.Add(header.Key, header.Value?.ToString());
                    }
                }
                HttpResponseMessage response = await httpclient.SendAsync(httpRequestMessage);
                return response;

            });
        }



    }
}
