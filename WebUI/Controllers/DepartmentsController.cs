using Business.Abstract;
using Entities.Concrete.School;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //List<Department>;
            var list = _departmentService.GetList(null);
            return View(list);
        }

        [Authorize(Roles = "CreateDepartment")]
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
                _departmentService.Add(department);

                return RedirectToAction("Index");
            }

            return View();
        }

        [Authorize(Roles = "EditDepartment")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var department = _departmentService.Get(p=>p.Id==id);
            return View(department);
        }

        [Authorize(Roles = "EditDepartment")]
        [HttpPost]
        public IActionResult Update(Department department)
        {


            if (ModelState.IsValid)
            {

                _departmentService.Update(department);

                return RedirectToAction("Index");
            }

            return View();
        }

        [Authorize(Roles = "DeleteDepartment")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentService.Get(p=>p.Id==id);
            return View(department);
        }

        [Authorize(Roles = "DeleteDepartment")]
        [HttpPost]
        public IActionResult Delete(Department department)
        {


            if (ModelState.IsValid)
            {
                _departmentService.Delete(department);


                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
