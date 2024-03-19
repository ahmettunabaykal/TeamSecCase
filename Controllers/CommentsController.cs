using Microsoft.AspNetCore.Mvc;
using CaseTeamSec.Models;
using CaseTeamSec.Services;


namespace CaseTeamSec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: /comments
        [HttpGet]
        public IActionResult GetComments()
        {
            var comments = _commentService.GetComments();
            return Ok(comments);
        }

        // POST: /comments
        [HttpPost]
        public IActionResult CreateComment([FromBody] Comment comment)
        {
            _commentService.CreateComment(comment);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        // GET: /comments/{id}
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _commentService.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // PUT: /comments/{id} 
        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _commentService.UpdateComment(comment);
            return NoContent();
        }


        // DELETE: /comments/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            if (!Request.Headers.TryGetValue("WriterId", out var writerIdValue))
            {
                return BadRequest("WriterId header is missing.");
            }

            if (!int.TryParse(writerIdValue, out int writerId))
            {
                return BadRequest("Invalid WriterId header value.");
            }

            _commentService.DeleteComment(id, writerId);
            return NoContent();
        }

    }
}

