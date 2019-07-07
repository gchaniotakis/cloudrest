using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace cloudrest.Models
{
    public class Repository<T> : IRepo<T> where T : class
    {
        private ApplicationDbContext _db;
        public Repository()
        {
            this._db = new ApplicationDbContext();
        }

        public Repository(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return _db.Set<T>().Find(id);
        }
        
        public void Insert(T model)
        {
            _db.Set<T>().Add(model);
        }

        public void Update (T model)
        {
            _db.Entry(model).State = EntityState.Modified;
        }

        public void Delete (object id)
        {
            T existing = GetById(id);
            _db.Set<T>().Remove(existing);
        }

        public bool LessonExists (string title)
        {
            return _db.Lessons.Any(u => u.LessonTitle == title);
        }

        public void Save()
        {
            using(_db)
            {
                _db.SaveChanges();
            }
        }




    }



}