using System;
using System.Net;
using System.Net.Sockets;

namespace Unicorn.Common
{
    public class IpUtil
    {
        /// <summary>
        /// Get the local ip
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIp()
        {
            try
            {

                string hostName = Dns.GetHostName(); //Get the host name
                IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
                foreach (var t in ipEntry.AddressList)
                {
                    //Filter out the IPv4 type IP address from the IP address list.
                    //AddressFamily.InterNetwork Indicates that this IP is IPv4.
                    //AddressFamily.InterNetworkV6 Indicates that this address is of type IPv6.
                    if (t.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return t.ToString();
                    }
                }
                return "";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
