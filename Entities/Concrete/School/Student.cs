using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Abstract;

namespace Entities.Concrete.School
{
    public class Student:IEntity
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

        public DateTime? ProcessDate { get; set; }
    }
}
