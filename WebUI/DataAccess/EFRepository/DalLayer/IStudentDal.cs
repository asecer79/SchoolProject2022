using WebUI.DataAccess.EFRepository.Services;
using WebUI.Entities;

namespace WebUI.DataAccess.EFRepository.DalLayer
{
    public interface IStudentDal:IDbService<Student>
    {

        void BulkInsert(List<Student> list);
    }
}
