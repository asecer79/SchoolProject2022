using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.School;

namespace Business.Concrete
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentService(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public Department Get(Expression<Func<Department, bool>> filter)
        {
            return _departmentDal.Get(filter);
        }

        public List<Department> GetList(Expression<Func<Department, bool>> filter)
        {
            return _departmentDal.GetList(filter).ToList();
        }

        public Department Add(Department entity)
        {
            return _departmentDal.Add(entity);
        }

        public void Update(Department entity)
        {
            _departmentDal.Update(entity);
        }

        public void Delete(Department entity)
        {
           _departmentDal.Delete(entity);
        }
    }
}
