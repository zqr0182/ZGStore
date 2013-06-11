using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Common.Abstract;
using ZG.Common.Concrete;
using ZG.Common.DTO;
using ZG.Domain.Models;
using ZG.Repository;

namespace ZG.Application
{
    public interface IEmailService
    {
        /// <summary>
        /// Write to db, send email, update status in db
        /// </summary>
        /// <param name="emailType"></param>
        /// <param name="mailAddresses"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isBodyHtml"></param>
        void ProcessEmail(EmailType emailType, MailAddresses mailAddresses, string subject, string body, bool isBodyHtml, int? orderId);
    }

    public class EmailService : BaseService, IEmailService
    {
        private IEmailSender _emailSender;
        private IEmailSettingsFactory _emailSettingsFactory;
        private EmailSettings _emailSettings;

        public EmailService(IUnitOfWork uow, IEmailSettingsFactory emailSettingsFactory, IEmailSender emailSender)
            : base(uow)
        {
            _emailSettingsFactory = emailSettingsFactory;
            _emailSender = emailSender;
        }

        public void ProcessEmail(EmailType emailType, MailAddresses mailAddresses, string subject, string body, bool isBodyHtml, int? orderId)
        {
            _emailSettings = _emailSettingsFactory.GetEmailSettings(emailType);
            if (mailAddresses != null)
            {
                _emailSettings.Addresses = mailAddresses;
            }

            var email = new Email
                {
                    OrderId = orderId,
                    FromAddress = _emailSettings.Addresses.MailFromAddress,
                    ToAddress = _emailSettings.Addresses.MailToAddress,
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isBodyHtml,
                    Type = emailType.ToString(),
                    Status = EmailSendingStatus.Sending.ToString(),
                    CreationDate = DateTime.Now
                };

            UnitOfWork.Emails.Add(email);
            UnitOfWork.Commit();

            EmailSendingResult result = _emailSender.Send(_emailSettings, subject, body, isBodyHtml);

            email.Status = result.Status.ToString();
            email.ExceptionMessage = result.ExceptionMessage;

            UnitOfWork.Commit();
        }
    }
}
