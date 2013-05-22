using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common.Abstract;
using ZG.Common.DTO;

namespace ZG.Common.Concrete
{
    public class EmailSender : IEmailSender
    {
        private IEmailSettingsFactory _emailSettingsFactory;
        private EmailSettings _emailSettings;
        public MailAddresses MailAddresses { get; set; }


        public EmailSender(IEmailSettingsFactory emailSettingsFactory)
        {
            _emailSettingsFactory = emailSettingsFactory;
        }

        public EmailSendingResult Send(EmailType emailType, MailAddresses mailAddresses, string subject, string body, bool isBodyHtml)
        {
            var result = new EmailSendingResult();
            try
            {
                _emailSettings = _emailSettingsFactory.GetEmailSettings(emailType);
                if (mailAddresses != null)
                {
                    _emailSettings.Addresses = mailAddresses;
                }

                //TODO: send email

                result.Status = EmailSendingStatus.Success;
            }
            catch (Exception ex)
            {
                //TODO: Log exception

                result.Status = EmailSendingStatus.Failed;
                result.ExceptionMessage = ex.Message;
            }

            return result;
        }
    }
}
