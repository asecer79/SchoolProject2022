using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.School;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetUserByEmailAndPassword(string email, string password);
        public List<OperationClaim> GetOperationClaims(int userId);
    }
}
