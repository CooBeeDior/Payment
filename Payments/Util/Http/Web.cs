using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Payments.Util.Http
{
    public class Web
    {
        /// <summary>
        /// 创建WebClient
        /// </summary>
        /// <returns></returns>
        public static WebClient Client(HttpClient client)
        {
            return new WebClient(client);
        }
    }
}
