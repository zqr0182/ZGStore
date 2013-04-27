

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class DBVersion 
    {
        public int Sprint { get; set; }
        public int Patch { get; set; }
        public string Story { get; set; }
        public string Description { get; set; }
        public System.DateTime DeployedOn { get; set; }
    }
}
