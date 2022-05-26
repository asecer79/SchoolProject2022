using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DepartmentId")]
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz...")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz...")]
        public string? LastName { get; set; }


        public string? PhotoPath { get; set; }
        
    }
}
