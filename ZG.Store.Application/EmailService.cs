using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface IEmailService
    {
        //TODO: write to db, send email using EmailSender, update status in db
    }

    public class EmailService : BaseService, IEmailService
    {
        public EmailService(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
