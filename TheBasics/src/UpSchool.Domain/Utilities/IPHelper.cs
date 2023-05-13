using System.Net;
using System.Net.Sockets;

namespace UpSchool.Domain.Utilities
{
    public class IPHelper:IIPHelper
    {
        public string GetCurrentIPAddress()
        {
            return GetIpAddress();
        }

        public List<string> GetAllIPAddresses()
        {
            throw new NotImplementedException();
        }

        public static string GetIpAddress()
        {
            //var host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (var ip in host.AddressList)
            //{
            //    if (ip.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        return ip.ToString();
            //    }
            //}
            return string.Empty;
        }
    }
}
