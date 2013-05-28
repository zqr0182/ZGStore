using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;

namespace ZG.Common.DTO
{
    public class EmailSendingResult
    {
        public EmailSendingStatus Status { get; set; }
        public string ExceptionMessage { get; set; }

        public EmailSendingResult()
        {
            Status = EmailSendingStatus.Sending;
            ExceptionMessage = "";
        }
    }
}
