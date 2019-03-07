using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CET322_HW1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CET322_HW1.Controllers
{
    public class StudentsController : Controller
    {

        StudentContext StudentContext;

        public StudentsController(StudentContext context)
        {
            StudentContext = context;

        }
        public IActionResult Index()
        {
            var students = StudentContext.Students.ToList();
            return View(students);
        }

        public IActionResult Detail(int id)
        {
            Student student = StudentContext.Students.Where(s => s.Id == id).FirstOrDefault();
            if (student != null)
            {
                return View(student);
            }
            else
            {
                return NotFound();
            }
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(include: "Name,Surname,Email,Department")] Student student)
        {
            if (ModelState.IsValid)
            {
                StudentContext.Students.Add(student);
                await StudentContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(student);
        }


        

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var stu = StudentContext.Students.Find(id);
            return View("Edit", stu);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            StudentContext.Entry(student).State = EntityState.Modified;
            StudentContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}


