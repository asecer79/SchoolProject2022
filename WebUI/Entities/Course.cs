using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        [ForeignKey("LecturerId")]
        public int LecturerId { get; set; }

        [ForeignKey("SemesterId")]
        public int SemesterId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
