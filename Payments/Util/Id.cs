using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Util
{
    public class Id
    {
        /// <summary>
        /// 获取guid
        /// </summary>
        /// <returns></returns>
        public static string GetId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
