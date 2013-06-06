using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common.DTO
{
    public class PaymentInformation
    {
        public Address BillingAdress { get; set; }

        public PaymentInformation()
        {
            BillingAdress = new Address();
        }
    }
}
