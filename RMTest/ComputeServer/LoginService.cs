using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using GridLib;

namespace ComputeServer
{
    public class LoginService : MarshalByRefObject, ILoginService
    {
        public static List<string> Clients = new List<string>();
        public static LoginCallBack CallBack;

        public void Login(string s)
        {
            bool a = false;
            if (!Clients.Contains(s))
            {
                Clients.Add(s);
                a = true;
            }
            Clients.Sort();
            if (a && CallBack != null)
            {
                CallBack(s);
            }
        }

        public void Logout(string s)
        {
            if (Clients.Contains(s))
            {
                Clients.Remove(s);
            }
            if (CallBack != null)
            {
                CallBack(s);
            }
        }

        public static void Validate()
        {
            for (int i = Clients.Count - 1; i >= 0; i--)
            {
                try
                {
                    //var t = GridTool.GetRemoteObj(typeof(RMClientService), Clients[i], 7300, "ClientService");
                }
                catch
                {
                    Clients.RemoveAt(i);
                }
            }
            CallBack("");
        }
    }
}
