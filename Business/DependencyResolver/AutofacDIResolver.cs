using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Business.Abstract;
using Business.Caching;
using Business.Concrete;
using Business.Security;
using DataAccess.Abstract;
using DataAccess.Concrete.Ef;

namespace Business.DependencyResolver
{
    public class AutofacDIResolver:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DepartmentDal>().As<IDepartmentDal>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<StudentDal>().As<IStudentDal>();
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<MemoryCacheService>().As<ICacheService>();
            builder.RegisterType<AuthHelper>();

        }
    }
}
