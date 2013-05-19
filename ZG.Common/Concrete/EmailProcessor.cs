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
        private IEmailSettingsFactory _emailSettingsFactory;
        private EmailSettings _emailSettings;
        public MailAddresses MailAddresses { get; set; }


        public EmailProcessor(IEmailSettingsFactory emailSettingsFactory)
        {
            _emailSettingsFactory = emailSettingsFactory;
        }

        public void ProcessEmail(EmailType emailType, MailAddresses mailAddresses, string subject, string body, bool isBodyHtml)
        {
            _emailSettings = _emailSettingsFactory.GetEmailSettings(emailType);
            if (mailAddresses != null)
            {
                _emailSettings.Addresses = mailAddresses;
            }

            Debug.WriteLine("Email processed");
        }
    }
}
