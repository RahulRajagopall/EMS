using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Operations
    {
        [Key]        
        public String? Email { get; set; }
        [Required]
        public String? Complaints { get; set; }
        [Required]
        public String? Password {get;set;}
    }
}