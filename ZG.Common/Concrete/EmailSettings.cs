﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common.Concrete
{
    public class EmailSettings
    {
        public MailAddresses Addresses { get; set; }
        public bool UseSsl { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string SmtpServerName { get; set; }
        public int SmtpServerPort { get; set; }
        public bool WriteAsFile { get; set; }
        public string FileLocation { get; set; }

        public EmailSettings()
        {
            Addresses = new MailAddresses();
        }
    }
}
