using System.ComponentModel.DataAnnotations;
using Core.Entities.Abstract;

namespace Entities.Concrete.School
{
 
    public class Department : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
    }
}
