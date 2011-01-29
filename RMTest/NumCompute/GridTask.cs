using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumCompute
{
    public class GridTask : MarshalByRefObject
    {
        public bool Run(long num)
        {
            bool dest = true;
            for (long i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    dest = false;
                    break;
                }
            }

            return dest;
        }
    }
}
