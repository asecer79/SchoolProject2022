using WebUI.Entities;

namespace WebUI.DataAccess.EFRepository.DalLayer.SQLServer
{
    public class StudentDal:IStudentDal
    {
        public Student Get(int id)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Find(id);
                return dbContext.Students.Find(id)!;
            }
        }

        public Student Add(Student entity)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                var result = dbContext.Students.Add(entity);

                dbContext.SaveChanges();
            }

            return entity;
        }

        public void Update(Student entity)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                var result = dbContext.Students.Update(entity);

                dbContext.SaveChanges();
            }
        }

        public void Delete(Student entity)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                var result = dbContext.Students.Remove(entity);

                dbContext.SaveChanges();
            }
        }

        public List<Student> GetList()
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                var result = dbContext.Students.ToList();

                return result;
            }

           
        }

        public void BulkInsert(List<Student> list)
        {
            throw new NotImplementedException();
        }
    }
}
