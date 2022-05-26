using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Ef.Contexts;
using Entities.Concrete.School;

namespace DataAccess.Concrete.Ef
{
    public class StudentDal:EfEntityRepositoryBase<Student, SchoolProjectDbContext>, IStudentDal
    {
      
    }
}
