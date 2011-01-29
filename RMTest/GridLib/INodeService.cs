using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridLib
{
    public interface INodeService
    {
        String Level { get;}

        bool WriteFile(String name, byte[] obj);
        bool RegistTask(String name);
        bool RegistTask(String name, byte[] obj);
    }
}
