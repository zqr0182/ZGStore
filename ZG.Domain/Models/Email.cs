

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Email : IEntity  
    {
        [Key]
        public int Id { get; set; }
        public int? OrderId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ToAddress { get; set; }
        [MaxLength(50)]
        public string ToName{ get; set; }
        [Required]
        [MaxLength(50)]
        public string FromAddress { get; set; }
        [MaxLength(50)]
        public string FromName { get; set; }
        [MaxLength(250)]
        public string Cc{ get; set; }
        [Required]
        [MaxLength(200)]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public bool IsBodyHtml { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        [MaxLength(300)]
        public string ExceptionMessage { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
