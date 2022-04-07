#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUI.DataAccess.EFRepository;
using WebUI.DataAccess.EFRepository.DalLayer;
using WebUI.Entities;

namespace WebUI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentDal _studentDal;
        private readonly IDepartmentDal _departmentDal;

        public StudentsController(IStudentDal studentDal, IDepartmentDal departmentDal)
        {
            _studentDal = studentDal;
            _departmentDal = departmentDal;
        }

        // GET: Students
        public IActionResult Index()
        {
            var list = _studentDal.GetList();

            return View(list);
        }

        // GET: Students/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = _studentDal.Get(id);

            return View(record);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name");
            //ViewData["DepartmentId"] = _departmentDal.GetList();
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {

            if (ModelState.IsValid)
            {
                student= _studentDal.Add(student);



                var file = Request.Form.Files[0];
                var root = "wwwroot";
                var folder = "StudentPhotos";
                var folderPath = $"{root}/{folder}";

                var fileName = $"{student.Id}{Path.GetExtension(file.FileName)}";

                var fileFullPath = folderPath + "/" + fileName;


                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);



                using (FileStream fs = new FileStream(fileFullPath, FileMode.OpenOrCreate))
                {
                    file.CopyTo(fs);

                    fs.Flush();
                }






                return RedirectToAction(nameof(Index));
            }



          


        
            ViewData["DepartmentId"] = _departmentDal.GetList();
            return View(student);
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentDal.Get(id);

            if (student == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_studentDal.GetList(), "Id", "Name", student.DepartmentId);
            //ViewData["DepartmentId"] = _departmentDal.GetList();
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _studentDal.Update(student);

                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name", student.DepartmentId);
            return View(student);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentDal.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _studentDal.Get(id);

            _studentDal.Delete(student);
            return RedirectToAction(nameof(Index));
        }


    }
}
