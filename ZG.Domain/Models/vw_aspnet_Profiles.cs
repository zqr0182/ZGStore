

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class VwAspnetProfiles 
    {
        public System.Guid UserId { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public Nullable<int> DataSize { get; set; }
    }
}
