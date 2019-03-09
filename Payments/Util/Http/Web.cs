using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Util.Http
{
    public class Web
    {
        /// <summary>
        /// 创建WebClient
        /// </summary>
        /// <returns></returns>
        public static WebClient Client()
        {
            return new WebClient();
        }
    }
}
