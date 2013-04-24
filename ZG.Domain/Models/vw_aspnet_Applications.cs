

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class VwAspnetApplications 
    {
        public string ApplicationName { get; set; }
        public string LoweredApplicationName { get; set; }
        public System.Guid ApplicationId { get; set; }
        public string Description { get; set; }
    }
}
