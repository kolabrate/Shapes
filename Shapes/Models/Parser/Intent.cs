using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shapes.Models.Parser
{
    public class Intent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IntentId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedTime => DateTime.UtcNow;
        public DateTime ModifiedTime { get; set; }
    }
}