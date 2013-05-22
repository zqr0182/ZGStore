using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Common.Abstract;
using ZG.Common.Concrete;
using ZG.Common.DTO;
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
        void ProcessEmail(EmailType emailType, MailAddresses mailAddresses, string subject, string body, bool isBodyHtml);
    }

    public class EmailService : BaseService, IEmailService
    {
        private IEmailSender _emailSender;

        public EmailService(IUnitOfWork uow, IEmailSender emailSender)
            : base(uow)
        {
            _emailSender = emailSender;
        }

        public void ProcessEmail(EmailType emailType, MailAddresses mailAddresses, string subject, string body, bool isBodyHtml)
        {
            //TODO: write to db
            EmailSendingResult result = _emailSender.Send(emailType, mailAddresses, subject, body, isBodyHtml);
            //TODO: update status in db
        }
    }
}
