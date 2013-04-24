

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class CustomField : IEntity  
    {
        public CustomField()
        {
            this.OrderProductCustomFields = new List<OrderProductCustomField>();
        }

        public int Id { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string CustomFieldName { get; set; }
        public int CustomFieldTypeID { get; set; }
        public bool IsRequired { get; set; }
        public bool Active { get; set; }
        public virtual CustomFieldType CustomFieldType { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<OrderProductCustomField> OrderProductCustomFields { get; set; }
    }
}
