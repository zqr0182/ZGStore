

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class VwAspnetRoles 
    {
        public System.Guid ApplicationId { get; set; }
        public System.Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string LoweredRoleName { get; set; }
        public string Description { get; set; }
    }
}
