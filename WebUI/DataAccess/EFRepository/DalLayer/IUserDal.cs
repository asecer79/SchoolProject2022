using WebUI.DataAccess.EFRepository.Services;
using WebUI.Entities;

namespace WebUI.DataAccess.EFRepository.DalLayer
{
    public interface IUserDal : IDbService<User>
    {
        public User GetUserByEmailAndPassword(string email, string password);

        public List<OperationClaim> GetOperationClaims(int userId);

    }
}
