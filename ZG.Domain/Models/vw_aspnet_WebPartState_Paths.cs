

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class VwAspnetWebpartstatePaths 
    {
        public System.Guid ApplicationId { get; set; }
        public System.Guid PathId { get; set; }
        public string Path { get; set; }
        public string LoweredPath { get; set; }
    }
}
