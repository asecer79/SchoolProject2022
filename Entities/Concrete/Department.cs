using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
 
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
