using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cloudrest.Models;

namespace cloudrest.Controllers
{
    public class SelectionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Selection
        public ActionResult Index(string search)
        {
            var selections = db.Selections.Include(s => s.Lesson).Include(s => s.Student).Include(s => s.Teacher);
            return View(search == null ? selections : selections.Where(n => n.Lesson.LessonTitle.Contains(search)));
        }

        // GET: Selection/Create
        public ActionResult Create()
        {
            ViewBag.LessonId = new SelectList(db.Lessons, "LessonId", "LessonTitle");
            ViewBag.StudentId = new SelectList(db.Users.Where(u => u.UserRole == Role.Student), "UserId", "UserName");
            ViewBag.TeacherId = new SelectList(db.Users.Where(u => u.UserRole == Role.Teacher), "UserId", "UserName");
            return View();
        }

        // POST: Selection/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SelectionId,StudentId,TeacherId,LessonId")] Selection selection)
        {
            var verify = db.Selections.Any(v => v.TeacherId == selection.TeacherId && v.StudentId == selection.StudentId && v.LessonId == selection.LessonId);
            if(ModelState.IsValid)
            {
                if(!verify)
                {
                    db.Selections.Add(selection);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                TempData["Warning"] = "This has already been selected.";
                return RedirectToAction("Create");

            }


            ViewBag.LessonId = new SelectList(db.Lessons, "LessonId", "LessonTitle", selection.LessonId);
            ViewBag.StudentId = new SelectList(db.Users.Where(u => u.UserRole == Role.Student), "UserId", "UserName", selection.StudentId);
            ViewBag.TeacherId = new SelectList(db.Users.Where(u => u.UserRole == Role.Teacher), "UserId", "UserName", selection.TeacherId);
            return View(selection);
        }

        // GET: Selection/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Selection selection = db.Selections.Find(id);
            if (selection == null)
            {
                return HttpNotFound();
            }
            ViewBag.LessonId = new SelectList(db.Lessons, "LessonId", "LessonTitle", selection.LessonId);
            ViewBag.StudentId = new SelectList(db.Users.Where(u => u.UserRole == Role.Student), "UserId", "UserName", selection.StudentId);
            ViewBag.TeacherId = new SelectList(db.Users.Where(u => u.UserRole == Role.Teacher), "UserId", "UserName", selection.TeacherId);
            return View(selection);
        }

        // POST: Selection/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SelectionId,TeacherId,StudentId,LessonId")] Selection selection)
        {
            var verify = db.Selections.Any(v => v.TeacherId == selection.TeacherId && v.StudentId == selection.StudentId && v.LessonId == selection.LessonId);
            if (ModelState.IsValid)
            {
                if(!verify)
                {
                    db.Entry(selection).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                TempData["Warning"] = "This has already been selected.";
                return RedirectToAction("Edit");
            }
            ViewBag.LessonId = new SelectList(db.Lessons, "LessonId", "LessonTitle", selection.LessonId);
            ViewBag.StudentId = new SelectList(db.Users.Where(u => u.UserRole == Role.Student), "UserId", "UserName", selection.StudentId);
            ViewBag.TeacherId = new SelectList(db.Users.Where(u => u.UserRole == Role.Teacher), "UserId", "UserName", selection.TeacherId);
            return View(selection);
        }

        
        public ActionResult Delete(int id)
        {
            Selection selection = db.Selections.Find(id);
            db.Selections.Remove(selection);
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
