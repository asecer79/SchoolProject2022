using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.School;

namespace Business.Concrete
{
    public class UserService:IUserService
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _userDal.GetUserByEmailAndPassword(email, password);
        }

        public List<OperationClaim> GetOperationClaims(int userId)
        {
            return _userDal.GetOperationClaims(userId);
        }
    }
}
