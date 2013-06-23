using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common.Concrete
{
    public class Util
    {
        public static string ReplaceUnderscoreWithSpace(Enum myEnum)
        {
            return myEnum.ToString().Replace('_', ' ');
        }
    }
}
