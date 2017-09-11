using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shapes.Models.Parser
{
    [Table("Requests")]
    public class Request
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RequestId { get; set; }
        [Required]
        public string Message { get; set; }

        public DateTime CreatedTime => DateTime.UtcNow;
        public DateTime ModifiedTime { get; set; }

    }
}