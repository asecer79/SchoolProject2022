using Entities.Concrete;

namespace WebUI.DataAccess.EFRepository.DalLayer.SQLServer
{
    public class UserDal : IUserDal
    {
        public User Get(int id)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Find(id);
                return dbContext.Users.Find(id)!;
            }
        }

        public User Add(User entity)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Find(id);
                dbContext.Users.Add(entity);
                dbContext.SaveChanges();

                return entity;

            }
        }

        public void Update(User entity)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Find(id);
                dbContext.Users.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Find(id);
                dbContext.Users.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public List<User> GetList()
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Find(id);
                return dbContext.Users.ToList();

            }
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Find(id);
                return dbContext.Users.FirstOrDefault(p => p.EMail == email && p.Password == password);

            }
        }

        public List<OperationClaim> GetOperationClaims(int userId)
        {
            using (var dbContext = new SchoolProjectDbContext())
            {
                //return dbContext.Set<Department>().Find(id);

                var claims = from p in dbContext.UserOperationClaims
                             where p.UserId == userId
                             select new OperationClaim()
                             {
                                 Name = p.OperationClaim.Name,
                                 Id = p.OperationClaimId
                             };

                return claims.ToList();
            }
        }
    }
}