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
    public class StudentService:IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentService(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public Student Get(Expression<Func<Student, bool>> filter)
        {
            return _studentDal.Get(filter);
        }

        public List<Student> GetList(Expression<Func<Student, bool>> filter)
        {
            return _studentDal.GetList(filter).ToList();
        }

        public Student Add(Student entity)
        {
           return _studentDal.Add(entity);
        }

        public void Update(Student entity)
        {
            _studentDal.Update(entity);
        }

        public void Delete(Student entity)
        {
            _studentDal.Delete(entity);
        }


    }
}
