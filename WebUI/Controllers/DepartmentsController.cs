using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using WebUI.DataAccess.EFRepository.DalLayer;
using WebUI.Entities;

namespace WebUI.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentsController(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //List<Department>;
            var list = _departmentDal.GetList();
            return View(list);
        }

        [Authorize(Roles= "CreateDepartment")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize("CreateDepartment")]
        [HttpPost]
        public IActionResult Create(Department department)
        {


            if (ModelState.IsValid)
            {
                _departmentDal.Add(department);

                return RedirectToAction("Index");
            }

            return View();
        }

        [Authorize(Roles = "EditDepartment")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var department = _departmentDal.Get(id);
            return View(department);
        }

        [Authorize(Roles = "EditDepartment")]
        [HttpPost]
        public IActionResult Update(Department department)
        {


            if (ModelState.IsValid)
            {

                _departmentDal.Update(department);

                return RedirectToAction("Index");
            }

            return View();
        }

        [Authorize(Roles = "DeleteDepartment")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentDal.Get(id);
            return View(department);
        }

        [Authorize(Roles = "DeleteDepartment")]
        [HttpPost]
        public IActionResult Delete(Department department)
        {


            if (ModelState.IsValid)
            {
                _departmentDal.Delete(department);


                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
