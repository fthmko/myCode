using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridLib
{
    public delegate void LoginCallBack(string addr);
    public interface ILoginService
    {
        void Login(string ip);
        void Logout(string ip);
    }
}
