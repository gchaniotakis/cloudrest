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
    public class UserController : ApiController
    {
        private ApplicationDbContext _context;
        
        public UserController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/User
        public IHttpActionResult GetUsers()
        {
            var userDtos = _context.Users
                .ToList()
                .Select(Mapper.Map<User, UserDto>);

            return Ok(userDtos);
        }

        // GET /api/User/1
        public IHttpActionResult GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == id);

            if (user == null)
                return NotFound();

            return Ok(Mapper.Map<User, UserDto>(user));
        }

        // POST /api/User/1
        [HttpPost]
        public IHttpActionResult CreateUser (UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model, try again.");

            var user = Mapper.Map<UserDto, User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();

            userDto.UserId = user.UserId;
            return Created(new Uri(Request.RequestUri + "/" + user.UserId), userDto);
        }

        // PUT /api/User/1
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model, try again");

            var userInDb = _context.Users.FirstOrDefault(u => u.UserId == id);

            if (userInDb == null)
                return NotFound();

            Mapper.Map(userDto, userInDb);

            _context.SaveChanges();

            return Ok($"{userInDb.UserName} was successfully updated.");
        }

        // DELETE /api/User/1
        [HttpDelete]
        public IHttpActionResult DeleteUser (int id)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.UserId == id);

            var selection = _context.Selections.Where(e => e.StudentId == id).ToList();

            foreach(Selection select in selection)
            {
                _context.Selections.Remove(select);
            }

            _context.SaveChanges();

            if (userInDb == null)
                return NotFound();

            _context.Users.Remove(userInDb);
            _context.SaveChanges();

            return Ok($"{userInDb.UserName} was successfully deleted.");
        }
    }
}
