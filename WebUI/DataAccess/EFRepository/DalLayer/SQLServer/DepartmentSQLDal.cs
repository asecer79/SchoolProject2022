using Entities.Concrete;

namespace WebUI.DataAccess.EFRepository.DalLayer.SQLServer
{
    public class DepartmentSQLDal: IDepartmentDal
    {
        public Department Get(int id)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Find(id);
                return dbContext.Departments.Find(id);
            }
        }

        public Department Add(Department entity)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Find(id);
                var result = dbContext.Departments.Add(entity);
                
                dbContext.SaveChanges();

                return entity;
            }
        }

        public void Update(Department entity)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Update(entity);
                var result = dbContext.Departments.Update(entity);

                dbContext.SaveChanges();
            }
        }

        public void Delete(Department entity)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Remove(entity);
                var result = dbContext.Departments.Remove(entity);

                dbContext.SaveChanges();
            }
        }

        public List<Department> GetList()
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Remove(entity);
                var result = dbContext.Departments.ToList();

                return result;
            }
        }
    }
}
