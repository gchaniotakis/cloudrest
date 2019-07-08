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
    public class UserController : Controller
    {
        private IRepo<User> repo;

        public UserController()
        {
            this.repo = new Repository<User>();
        }

        public UserController(IRepo<User> repo)
        {
            this.repo = repo;
        }

        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: User
        public ActionResult Index(string search)
        {
            return View(search == null ? repo.GetAll() : repo.GetAll().Where(s => s.UserName.Contains(search)).ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = repo.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }



        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,UserRole")] User user)
        {
            repo.Insert(user);
            repo.Save();            
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = repo.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,UserRole")] User user)
        {
            if (ModelState.IsValid)
            {
                repo.Update(user);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View("User");
        }

        
        public ActionResult Delete(int id)
        {
            var selections = db.Selections.Where(s => s.StudentId == id).ToList();
            foreach (Selection sel in selections)
            {
                db.Selections.Remove(sel);
            }
            db.SaveChanges();

            repo.Delete(id);
            repo.Save();
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
