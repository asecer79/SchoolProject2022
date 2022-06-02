using Core.Entities.Abstract;

namespace Entities.Concrete.School
{
    public class Lecturer : IEntity
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
