using Microsoft.AspNetCore.Mvc;
using WebUI.DataAccess.EFRepository.DalLayer;
using WebUI.Entities;

namespace WebUI.Controllers
{
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

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

        [HttpGet]
        public IActionResult Update(int id)
        {
            var department = _departmentDal.Get(id);
            return View(department);
        }

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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentDal.Get(id);
            return View(department);
        }

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
