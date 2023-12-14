using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CrudOperations.models
{
    public class Brand
    {
        [Key]
        
        public String? Email { get; set; }
        [Required]
        public String? Complaints { get; set; }
    }
}       