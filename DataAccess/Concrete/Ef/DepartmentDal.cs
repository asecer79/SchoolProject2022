using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Ef.Contexts;
using Entities.Concrete.School;

namespace DataAccess.Concrete.Ef
{
    public class DepartmentDal:EfEntityRepositoryBase<Department,SchoolProjectDbContext>, IDepartmentDal
    {
   

        //public List<Department> GetList()
        //{
        //    using (var dbContext = new SchoolProjectDbContext())
        //    {
        //        //return dbContext.Set<Department>().Remove(entity);
        //        var result = dbContext.Departments.ToList();

        //        return result;
        //    }
        //}
    }
}
