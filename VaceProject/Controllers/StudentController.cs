using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaceProject.DAL;
using VaceProject.Helpers;
using VaceProject.Models;
using VaceProject.ViewModels.ManageStudent;

namespace VaceProject.Controllers
{
    public class StudentController : Controller
    {
        private VaceContext db = new VaceContext();

        // GET: Student
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        //public PartialViewResult AddStudentPartialView()
        //{
        //    return PartialView("~/Views/Student/Create.cshtml");
        //    //return PartialView("Create", new AddStudentViewModel());
        //}

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string CreateStudent(AddStudentViewModel student)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    Student newStudent = new Student
                    {
                        ForeName = student.ForeName,
                        LastName = student.LastName,
                        DOB = student.DOB,
                        Email = student.Email,
                        EnrollmentDate = DateTime.Now
                    };


                    db.Students.Add(newStudent);
                    db.SaveChanges();
                    return "Success";
                }
                catch(Exception ex)
                {
                    return "Failure";
                }
            }

            return "Success";
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,ForeName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
