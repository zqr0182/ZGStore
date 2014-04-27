using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common
{
    public static class Utility
    {
        public static bool StatusToBool(string filterByStatus)
        {
            return string.Compare(filterByStatus, "Active", true) == 0 ? true : false;
        }
    }
}
