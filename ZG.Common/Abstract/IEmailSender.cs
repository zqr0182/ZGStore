using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common.Concrete;
using ZG.Common.DTO;

namespace ZG.Common.Abstract
{
    public interface IEmailSender
    {
        EmailSendingResult Send(EmailType emailType, MailAddresses mailAddresses, string subject, string body, bool isBodyHtml);
    }
}
