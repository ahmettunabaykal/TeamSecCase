using Microsoft.AspNetCore.Mvc;
using CaseTeamSec.Models;
using CaseTeamSec.Services;

namespace CaseTeamSec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WritersController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WritersController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        // GET: /writers
        [HttpGet]
        public IActionResult GetWriters()
        {
            var writers = _writerService.GetWriters();
            return Ok(writers);
        }

        // POST: /writers
        [HttpPost]
        public IActionResult CreateWriter([FromBody] Writer writer)
        {
            _writerService.CreateWriter(writer);
            return CreatedAtAction(nameof(GetWriter), new { id = writer.Id }, writer);
        }

        // GET: /writers/{id}
        [HttpGet("{id}")]
        public IActionResult GetWriter(int id)
        {
            var writer = _writerService.GetWriter(id);
            if (writer == null)
            {
                return NotFound();
            }
            return Ok(writer);
        }

        // PUT: /writers/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateWriter(int id, [FromBody] Writer writer)
        {
            if (id != writer.Id)
            {
                return BadRequest();
            }

            _writerService.UpdateWriter(writer);
            return NoContent();
        }

        // DELETE: /writers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteWriter(int id)
        {
            _writerService.DeleteWriter(id);
            return NoContent();
        }
    }
}
