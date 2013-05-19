using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common.Abstract;
using ZG.Common.CustomExceptions;

namespace ZG.Common.Concrete
{
    public class EmailSettingsFactory : IEmailSettingsFactory
    {
        private const string ExceptionMessage = "Appsetting key {0} was not found.";
        public EmailSettings GetEmailSettings(EmailType emailType)
        {
            var emailSettings = new EmailSettings();
            emailSettings.UseSsl = true;
            emailSettings.SmtpUserName = ConfigurationManager.AppSettings[EmailSettingKey.SmtpUserName];
            if (emailSettings.SmtpUserName == null)
            {
                throw new AppSettingKeyNotFoundException(ExceptionMessage, EmailSettingKey.SmtpUserName);
            }
            emailSettings.SmtpPassword = ConfigurationManager.AppSettings[EmailSettingKey.SmtpPassword];
            if (emailSettings.SmtpPassword == null)
            {
                throw new AppSettingKeyNotFoundException(ExceptionMessage, EmailSettingKey.SmtpPassword);
            }
            emailSettings.SmtpServerName = ConfigurationManager.AppSettings[EmailSettingKey.SmtpServerName];
            if (emailSettings.SmtpServerName == null)
            {
                throw new AppSettingKeyNotFoundException(ExceptionMessage, EmailSettingKey.SmtpServerName);
            }
            emailSettings.SmtpServerPort = ConfigurationManager.AppSettings[EmailSettingKey.SmtpServerPort];
            if (emailSettings.SmtpServerPort == null)
            {
                throw new AppSettingKeyNotFoundException(ExceptionMessage, EmailSettingKey.SmtpServerPort);
            }

            string writeAsFile = ConfigurationManager.AppSettings[EmailSettingKey.WriteAsFile];
            emailSettings.WriteAsFile = !string.IsNullOrWhiteSpace(writeAsFile) && bool.Parse(writeAsFile);

            if (emailSettings.WriteAsFile)
            {
                emailSettings.FileLocation = ConfigurationManager.AppSettings[EmailSettingKey.FileLocation];
                if (emailSettings.FileLocation == null)
                {
                    throw new AppSettingKeyNotFoundException(ExceptionMessage, EmailSettingKey.FileLocation);
                }
            }

            switch (emailType)
            {
                case EmailType.NewOrderNotificationToAdmin:
                    emailSettings.MailAddresses.MailFromAddress = ConfigurationManager.AppSettings[EmailSettingKey.OrderNotificationFromAddress];
                    if (emailSettings.MailAddresses.MailFromAddress == null)
                    {
                        throw new AppSettingKeyNotFoundException(ExceptionMessage, EmailSettingKey.OrderNotificationFromAddress);
                    }
                    emailSettings.MailAddresses.MailFromName = ConfigurationManager.AppSettings[EmailSettingKey.OrderNotificationFromName];

                    emailSettings.MailAddresses.MailToAddress = ConfigurationManager.AppSettings[EmailSettingKey.OrderNotificationToAddress];
                    if (emailSettings.MailAddresses.MailToAddress == null)
                    {
                        throw new AppSettingKeyNotFoundException(ExceptionMessage, EmailSettingKey.OrderNotificationToAddress);
                    }
                    emailSettings.MailAddresses.MailToName = ConfigurationManager.AppSettings[EmailSettingKey.OrderNotificationToName];

                    emailSettings.MailAddresses.MailCcAddress = ConfigurationManager.AppSettings[EmailSettingKey.OrderNotificationCcAddress];
                    break;
            }

            return emailSettings;
        }
    }
}
