using Core.Entities.Abstract;

namespace Entities.Concrete.School
{
	public class ExamType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? ProcessDate { get; set; }
    }
}
