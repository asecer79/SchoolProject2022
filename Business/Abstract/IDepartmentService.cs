using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.School;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        Department Get(Expression<Func<Department, bool>> filter);
        List<Department> GetList(Expression<Func<Department, bool>> filter);
        Department Add(Department entity);
        void Update(Department entity);
        void Delete(Department entity);
    }
}
