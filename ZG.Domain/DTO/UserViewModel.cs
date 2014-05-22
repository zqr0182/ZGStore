using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ZG.Domain.DTO
{
    public class UserViewModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }
        [ScriptIgnore]
        public DateTime DateCreated { get; set; }
        public string DateCreatedString { get { return DateCreated.ToShortDateString(); } }
        [ScriptIgnore]
        public DateTime? DateUpdated { get; set; }
        public string DateUpdatedString { get { return DateUpdated.HasValue ? DateUpdated.Value.ToShortDateString() : ""; } }
        public bool Active { get; set; }
        public bool IsCreate { get; set; }
    }
}
