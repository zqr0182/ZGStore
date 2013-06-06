using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common
{
    public static class ExtensionMethods
    {
        public static bool SameAs(this string string1, string sring2)
        {
            return string.Compare(string1, sring2, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
