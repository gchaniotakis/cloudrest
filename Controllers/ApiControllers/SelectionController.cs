using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using cloudrest.Dtos;
using cloudrest.Models;

namespace cloudrest.Controllers
{
    public class SelectionController : ApiController
    {
        private ApplicationDbContext _context;
        
        public SelectionController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/Selection
        public IHttpActionResult GetSelections()
        {
            var selectionDtos = _context.Selections
                .ToList()
                .Select(Mapper.Map<Selection, SelectionDto>);

            return Ok(selectionDtos);
        }

        // GET /api/Selection/1
        public IHttpActionResult GetSelection(int id)
        {
            var selection = _context.Selections.SingleOrDefault(s => s.SelectionId == id);

            if (selection == null)
                return NotFound();

            return Ok(Mapper.Map<Selection, SelectionDto>(selection));


        }

        // POST /api/Selection
        [HttpPost]
        public IHttpActionResult CreateSelection (int id , SelectionDto selectionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model, try again.");

            var selection = Mapper.Map<SelectionDto, Selection>(selectionDto);
            _context.Selections.Add(selection);
            _context.SaveChanges();

            selectionDto.SelectionId = selection.SelectionId;
            return Created(new Uri(Request.RequestUri + "/" + selection.SelectionId), selectionDto);
        }

        // PUT /api/Selection/1
        [HttpPut]
        public IHttpActionResult UpdateSelection(int id , SelectionDto selectionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model, try again.");

            var selectionInDb = _context.Selections.SingleOrDefault(s => s.SelectionId == id);

            if (selectionInDb == null)
                return NotFound();

            Mapper.Map(selectionDto, selectionInDb);

            _context.SaveChanges();

            return Ok("Selection was successfully updated.");
        }

        // DELETE /api/Selection/1
        [HttpDelete]
        public IHttpActionResult DeleteSelection (int id)
        {
            var selectionInDb = _context.Selections.SingleOrDefault(s => s.SelectionId == id);

            if (selectionInDb == null)
                return NotFound();

            _context.Selections.Remove(selectionInDb);
            _context.SaveChanges();

            return Ok("Selection was successfully deleted.");
        }
    }
}
