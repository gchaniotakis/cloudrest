using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using cloudrest.Dtos;
using cloudrest.Models;

namespace cloudrest.Controllers.ApiControllers
{
    public class LessonController : ApiController        
    {

        private ApplicationDbContext _context;

        public LessonController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET /api/Lesson
        public IHttpActionResult GetLessons()
        {
            var lessonDtos = _context.Lessons
                .ToList()
                .Select(Mapper.Map<Lesson, LessonDto>);

            return Ok(lessonDtos);
        }

        // GET /api/Lesson/1
        public IHttpActionResult GetLesson(int id)
        {
            var lesson = _context.Lessons.SingleOrDefault(l => l.LessonId == id);

            if (lesson == null)
            
                return NotFound();
            

            return Ok(Mapper.Map<Lesson, LessonDto>(lesson));
        }

        // POST /api/Lesson
        [HttpPost]
        public IHttpActionResult CreateLesson(LessonDto lessonDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model, try again.");

            var lesson = Mapper.Map<LessonDto, Lesson>(lessonDto);
            _context.Lessons.Add(lesson);
            _context.SaveChanges();

            lessonDto.LessonId = lesson.LessonId;
            return Created(new Uri(Request.RequestUri + "/" + lesson.LessonId), lessonDto);
        }

        // PUT /api/Lesson/1
        [HttpPut]
        public IHttpActionResult UpdateLesson (int id, LessonDto lessonDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model, try again.");

            var lessonInDb = _context.Lessons.FirstOrDefault(l => l.LessonId == id);

            if (lessonInDb == null)
                return NotFound();
            Mapper.Map(lessonDto, lessonInDb);

            _context.SaveChanges();

            return Ok($"{lessonInDb.LessonTitle} was successfully updated.");
        }

        // DELETE /api/Lesson/1
        [HttpDelete]
        public IHttpActionResult DelelteLesson (int id)
        {
            var lessonInDb = _context.Lessons.FirstOrDefault(l => l.LessonId == id);

            if (lessonInDb == null)
                return NotFound();

            _context.Lessons.Remove(lessonInDb);
            _context.SaveChanges();

            return Ok($"{lessonInDb.LessonTitle} was successfully deleted.");
        }
    }
}
