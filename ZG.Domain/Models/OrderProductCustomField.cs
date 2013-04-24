

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class OrderProductCustomField : IEntity  
    {
        public int Id { get; set; }
        public int OrderProductID { get; set; }
        public int CustomFieldID { get; set; }
        public string OrderProductCustomFieldValue { get; set; }
        public bool Active { get; set; }
        public virtual CustomField CustomField { get; set; }
        public virtual OrderProduct OrderProduct { get; set; }
    }
}
