using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Payments.Util
{
    public static class Server
    {
        #region Ip(客户端Ip地址)

        /// <summary>
        /// Ip地址
        /// </summary>
        private static string _ip;

        /// <summary>
        /// 设置Ip地址
        /// </summary>
        /// <param name="ip">Ip地址</param>
        public static void SetIp(string ip)
        {
            _ip = ip;
        }

        /// <summary>
        /// 重置Ip地址
        /// </summary>
        public static void ResetIp()
        {
            _ip = null;
        }

        /// <summary>
        /// 客户端Ip地址
        /// </summary>
        //public static string Ip
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(_ip) == false)
        //            return _ip;
        //        var list = new[] { "127.0.0.1", "::1" };
        //        var result = HttpContext?.Connection?.RemoteIpAddress.SafeString();
        //        if (string.IsNullOrWhiteSpace(result) || list.Contains(result))
        //            result = GetLanIp();
        //        return result;
        //    }
        ////}

        /// <summary>
        /// 获取局域网IP
        /// </summary>
        public static string GetLanIp()
        {
            foreach (var hostAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }
            return string.Empty;
        }

        #endregion
    }
}
