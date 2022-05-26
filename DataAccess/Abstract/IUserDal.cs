using Core.DataAccess.Abstract;
using Entities.Concrete.School;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        public User GetUserByEmailAndPassword(string email, string password);

        public List<OperationClaim> GetOperationClaims(int userId);

    }
}
