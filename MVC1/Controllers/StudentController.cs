using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class StudentController : Controller
    {

        
        // GET: Student
        public ActionResult Index()
        {
            //MvcApplication.studentsList.Clear();

            //MvcApplication.studentsList.Add(new Models.Student { StudentId = 1, StudentName = "Dan", Age = 18 });
            //MvcApplication.studentsList.Add(new Models.Student { StudentId = 2, StudentName = "Calin", Age = 28 });

            return View(MvcApplication.studentsList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Student student = null;
            foreach (Models.Student stu in MvcApplication.studentsList)
            {
                if (stu.StudentId == id)
                {
                    student = MvcApplication.studentsList[id-1];
                }
            }
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(MVC1.Models.Student student)
        {
            try
            {
                // TODO: Add insert logic here
                student.StudentId = ++ MvcApplication.globalStudentId;
                MvcApplication.studentsList.Add(student);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Models.Student updateStudent = MvcApplication.studentsList.Where(s => s.StudentId == id).FirstOrDefault();
            return View(updateStudent);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.Student updateStudent = MvcApplication.studentsList.Where(s => s.StudentId == id).FirstOrDefault();
                updateStudent.StudentName = collection["StudentName"];
                updateStudent.Age = int.Parse(collection["Age"]);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Student deleteStudent = MvcApplication.studentsList.Where(s => s.StudentId == id).FirstOrDefault();
            return View(deleteStudent);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Student deleteStudent = MvcApplication.studentsList.Where(s => s.StudentId == id).FirstOrDefault();
                MvcApplication.studentsList.Remove(deleteStudent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
