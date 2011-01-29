using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace GridLib
{
    public class GridTool
    {
        public const int ServerPort = 7600;
        public const int NodePort = 7300;

        private static List<int> ports = new List<int>();

        public static void RegistSingleton(Type tp, string name)
        {

            RemotingConfiguration.RegisterWellKnownServiceType(tp, name, WellKnownObjectMode.Singleton);
        }

        public static void RegistSingleCall(Type tp, string name)
        {
            RemotingConfiguration.RegisterWellKnownServiceType(tp, name, WellKnownObjectMode.SingleCall);
        }

        public static bool RegistPort(int port)
        {
            if (!ports.Contains(port))
            {
                var tc = new TcpChannel(port);
                ChannelServices.RegisterChannel(tc, false);
                ports.Add(port);
                return true;
            }
            return false;
        }

        public static Object GetRemoteObj(Type tp, string url)
        {
            return Activator.GetObject(tp, "tcp://" + url);
        }

        public static Object GetRemoteObj(Type tp, string addr, string name)
        {
            return Activator.GetObject(tp, "tcp://" + addr + "/" + name);
        }

        public static Object GetRemoteObj(Type tp, string ip, int port, string name)
        {
            return Activator.GetObject(tp, "tcp://" + ip + ":" + port + "/" + name);
        }

        public static string GetIp()
        {
            string hn = System.Net.Dns.GetHostName();
            return System.Net.Dns.GetHostAddresses(hn)[0].ToString();
        }
    }
}
