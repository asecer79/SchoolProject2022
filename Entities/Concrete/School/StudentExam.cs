using Core.Entities.Abstract;

namespace Entities.Concrete.School
{
    public class StudentExam : IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public double Grade { get; set; }
        public DateTime? ProcessDate { get; set; }
    }
}
