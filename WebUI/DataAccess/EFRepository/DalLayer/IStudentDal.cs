using Entities.Concrete;
using WebUI.DataAccess.EFRepository.Services;

namespace WebUI.DataAccess.EFRepository.DalLayer
{
    public interface IStudentDal:IDbService<Student>
    {

        void BulkInsert(List<Student> list);
    }
}
