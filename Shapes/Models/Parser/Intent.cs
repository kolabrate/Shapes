using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Shapes.Models.Parser
{
    public class Intent
    {
       //Note : In a real world, I shall pick a key value pair db for intents & synonyms 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IntentId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Synonyms { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}