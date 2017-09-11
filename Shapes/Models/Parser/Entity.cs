using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shapes.Models.Parser
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EntityId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedTime { get; set;}
        public DateTime ModifiedTime { get; set; }
    }
}