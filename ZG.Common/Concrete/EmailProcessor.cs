using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common.Abstract;

namespace ZG.Common.Concrete
{
    public class EmailProcessor : IEmailProcessor
    {
        private EmailSettings _emailSettings;

        public EmailProcessor(IEmailSettingsFactory emailSettingsFactory, EmailType emailType, MailAddresses addresses = null)
        {
            _emailSettings = emailSettingsFactory.GetEmailSettings(emailType);

            if (addresses != null)
            {
                _emailSettings.MailAddresses = addresses;
            }
        }

        public void ProcessEmail(string subject, string body, bool isBodyHtml)
        {
            Debug.WriteLine("Email processed");
        }
    }
}
