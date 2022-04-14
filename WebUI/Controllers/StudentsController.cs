#nullable disable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using WebUI.DataAccess.EFRepository;
using WebUI.DataAccess.EFRepository.DalLayer;
using WebUI.Entities;

namespace WebUI.Controllers
{
    public class StudentsController : Controller
    {
        private ConnectionMultiplexer connectionMultiplexer;
        private readonly IDatabase _redisCacheDatabase;

        private readonly IStudentDal _studentDal;
        private readonly IDepartmentDal _departmentDal;
        IMemoryCache _memoryCache;

        public StudentsController(IStudentDal studentDal, IDepartmentDal departmentDal, IMemoryCache memoryCache)
        {
            _studentDal = studentDal;
            _departmentDal = departmentDal;
            _memoryCache = memoryCache;

            connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            _redisCacheDatabase = connectionMultiplexer.GetDatabase(0);
        }


        //redis cache
        public IActionResult Index()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<Student> list = new List<Student>();

            var data = _redisCacheDatabase.StringGet("_studentDal.GetList");

            List<Student> result = null;

            if (data.IsNull != true)
            {
                result = JsonSerializer.Deserialize<List<Student>>(data);
            }



            if (result == null)
            {
                for (int i = 0; i < 30000; i++)
                {
                    list = _studentDal.GetList();
                }

                var stringData = JsonSerializer.Serialize(list);

                _redisCacheDatabase.StringSet("_studentDal.GetList",stringData);
            }
            else
            {
                for (int i = 0; i < 30000; i++)
                {
                    var data2 = _redisCacheDatabase.StringGet("_studentDal.GetList");

                    list = JsonSerializer.Deserialize<List<Student>>(data2);
                   
                }
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
            var files = Request.Form.Files;

            if (ModelState.IsValid)
            {
                student = _studentDal.Add(student);

                if (files.Count > 0)
                {
                    var fullFilePath = UploadFiles(files, student.Id);

                    student.PhotoPath = fullFilePath;
                }

                _studentDal.Add(student);

                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = _departmentDal.GetList();
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
            ViewData["DepartmentId"] = new SelectList(_departmentDal.GetList(), "Id", "Name", student.DepartmentId);
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
