using Core.Entities.Abstract;

namespace Entities.Concrete.School
{
    public class StudentCourse : IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int SemesterId { get; set; }
        public DateTime? ProcessDate { get; set; }
    }
}
