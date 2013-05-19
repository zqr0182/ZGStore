using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common.Concrete;

namespace ZG.Common.Abstract
{
    public interface IEmailProcessor
    {
        void ProcessEmail(string subject, string body, bool isBodyHtml);
    }
}
