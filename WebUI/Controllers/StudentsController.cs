﻿
using Business.Abstract;
using Business.Caching;
using Entities.Concrete.School;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;


namespace WebUI.Controllers
{
    //[Authorize]
    public class StudentsController : Controller
    {
        readonly ICacheService _cacheService;

        private readonly IStudentService _studentService;
        readonly IDepartmentService _departmentService;

        public StudentsController(ICacheService cacheService, IStudentService studentService, IDepartmentService departmentService)
        {
            _cacheService = cacheService;
            _studentService = studentService;
            _departmentService = departmentService;
            // _memoryCache = memoryCache;
        }


        //redis cache
      //  [AllowAnonymous]
        public IActionResult Index()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<Student> list = null;

            var key = "_studentDal.GetList";

            var exist = _cacheService.Exists(key);

            if (exist)
            {
                list = _cacheService.Get<List<Student>>(key);
            }

            else
            {
                 list = _studentService.GetList(null);
                _cacheService.Set<List<Student>>(key, list);
            }


            ViewBag.ElapsedTime = stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Stop();


            return View(list);
        }


        // GET: Students
        //memory cache
        //public IActionResult Index()
        //{
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    List<Student> list = new List<Student>();

        //    var result = _memoryCache.Get<List<Student>>("_studentDal.GetList");

        //    if (result==null)
        //    {
        //        for (int i = 0; i < 30000; i++)
        //        {
        //            list = _studentDal.GetList();
        //        }

        //        _memoryCache.Set("_studentDal.GetList", list);
        //    }
        //    else
        //    {
        //        for (int i = 0; i < 30000; i++)
        //        {
        //            list = _memoryCache.Get<List<Student>>("_studentDal.GetList");
        //        }
        //    }


        //    ViewBag.ElapsedTime = stopwatch.Elapsed.TotalMilliseconds;

        //    stopwatch.Stop();


        //    return View(list);
        //}

        // GET: Students/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = _studentService.Get(p=>p.Id==id);

            return View(record);
        }

        // GET: Students/Create

        //[Authorize(Roles = "CreateStudent")]
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_studentService.GetList(null), "Id", "Name");
            //ViewData["DepartmentId"] = _departmentDal.GetList();
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "CreateStudent")]
        public IActionResult Create(Student student)
        {
            var files = Request.Form.Files;

            if (ModelState.IsValid)
            {
                student = _studentService.Add(student);

                if (files.Count > 0)
                {
                    var fullFilePath = UploadFiles(files, student.Id);

                    student.PhotoPath = fullFilePath;
                }

                //  _redisCacheDatabase.KeyDelete("_studentDal.GetList");
                _cacheService.Remove("_studentDal.GetList");

                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = _studentService.GetList(null);
            return View(student);
        }

        string UploadFiles(IFormFileCollection files, int studentId)
        {
            var file = files[0];
            var root = "wwwroot";
            var folder = "StudentPhotos";
            var folderPath = $"{root}/{folder}";

            var fileName = $"{studentId}{Path.GetExtension(file.FileName)}";

            var fileFullPath = folderPath + "/" + fileName;


            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            using (FileStream fs = new FileStream(fileFullPath, FileMode.OpenOrCreate))
            {
                file.CopyTo(fs);

                fs.Flush();
            }

            return fileFullPath.Replace("wwwroot", "");
        }

        // GET: Students/Edit/5
        //[Authorize(Roles = "UpdateStudent")]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.Get(p=>p.Id==id);

            if (student == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_studentService.GetList(null), "Id", "Name", student.DepartmentId);
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
            var files = Request.Form.Files;

            if (ModelState.IsValid)
            {
                if (files.Count > 0)
                {
                    var fullFilePath = UploadFiles(files, student.Id);

                    student.PhotoPath = fullFilePath;
                }


                _studentService.Update(student);

                _cacheService.Remove("_studentDal.GetList");

                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = new SelectList(_departmentService.GetList(null), "Id", "Name", student.DepartmentId);
            return View(student);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.Get(p=>p.Id==id);

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
            var student = _studentService.Get(p=>p.Id==id);

            _studentService.Delete(student);
            _cacheService.Remove("_studentDal.GetList");
            return RedirectToAction(nameof(Index));
        }


    }
}
