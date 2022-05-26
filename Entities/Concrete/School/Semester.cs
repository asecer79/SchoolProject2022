using Core.Entities.Abstract;

namespace Entities.Concrete.School
{
    public class Semester : IEntity
    {
        public int Id { get; set; }
        public int SemesterNumber { get; set; }
        public string Name { get; set; }
        public DateTime? ProcessDate { get; set; }
    }
}
