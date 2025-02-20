using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using CRUD_API.Entities;
using CRUD_API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudDevController : ControllerBase
    {
        private readonly CrudEventsDbContext _context;

        public CrudDevController(CrudEventsDbContext context)
        {
            _context = context;
        }

        // GET: api/CrudDev
        [HttpGet]
        public IActionResult GetAll()
        {
            var crudEvents = _context.CrudEvents.Where(e => !e.IsDeleted).ToList();
            return Ok(crudEvents);
        }

        // GET: api/CrudDev/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var crudEvent = _context.CrudEvents.FirstOrDefault(e => e.Id == id && !e.IsDeleted);
            if (crudEvent == null)
            {
                return NotFound("Event not found.");
            }
            return Ok(crudEvent);
        }

        // POST: api/CrudDev
        [HttpPost]
        public IActionResult Post(CrudEvents crudEvents)
        {
            crudEvents.Id = Guid.NewGuid();  // Ensure the event has a unique ID
            _context.CrudEvents.Add(crudEvents);
            return CreatedAtAction(nameof(GetById), new { id = crudEvents.Id }, crudEvents);
        }

        // PUT: api/CrudDev/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CrudEvents crudEvents)
        {
            var existingEvent = _context.CrudEvents.FirstOrDefault(e => e.Id == id && !e.IsDeleted);
            if (existingEvent == null)
            {
                return NotFound("Event not found.");
            }

            existingEvent.Update(crudEvents.Title, crudEvents.Description, crudEvents.StartDate, crudEvents.EndDate);
            return NoContent();
        }

        // DELETE: api/CrudDev/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var eventToDelete = _context.CrudEvents.FirstOrDefault(e => e.Id == id && !e.IsDeleted);
            if (eventToDelete == null)
            {
                return NotFound("Event not found.");
            }

            eventToDelete.Delete();
            return NoContent();
        }
    }

}
