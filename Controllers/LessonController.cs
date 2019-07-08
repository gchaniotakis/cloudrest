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
    public class LessonController : Controller
    {

        private IRepo<Lesson> repo;

        public LessonController()
        {
            this.repo = new Repository<Lesson>();
        }

        public LessonController(IRepo<Lesson> repo)
        {
            this.repo = repo;
        }
        
        // GET: Lesson
        public ActionResult Index(string search)
        {
            return View(search == null ? repo.GetAll() : repo.GetAll().Where(r => r.LessonTitle.Contains(search)).ToList());
        }


        // GET: Lesson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lesson/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="LessonId,LessonTitle")] Lesson lesson)
        {
            if(ModelState.IsValid)
            {
                bool check = repo.LessonExists(lesson.LessonTitle);

                if (check)
                {
                    ModelState.AddModelError(string.Empty, "Lesson already exists.");
                    return View(lesson);
                }
                repo.Insert(lesson);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(lesson);
        }

        // GET: Lesson/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = repo.GetById(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Lesson/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="LessonId,LessonTitle")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                bool check = repo.LessonExists(lesson.LessonTitle);

                if (check)
                {
                    ModelState.AddModelError(string.Empty, "Lesson already exists.");
                    return View(lesson);
                }
                repo.Update(lesson);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(lesson);
        }

        // GET: Lesson/Delete/5
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }


        
    }
}
