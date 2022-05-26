namespace Entities.Concrete
{
    public class Exam
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ExamTypeId { get; set; }
        public int SemesterId { get; set; }
        public DateTime ExamDate { get; set; }
        public int Duration { get; set; }
	}
}
