using Microsoft.AspNetCore.Mvc;
using CaseTeamSec.Models;
using CaseTeamSec.Services;

namespace CaseTeamSec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: /articles
        [HttpGet] // Working
        public IActionResult GetArticles()
        {
            var articles = _articleService.GetArticles();
            return Ok(articles);
        }

        // POST: /articles
        [HttpPost] // Working
        public IActionResult CreateArticle([FromBody] Article article)
        {
            _articleService.CreateArticle(article);
            return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
        }

        // GET: /articles/{id}
        [HttpGet("{id}")] // Working
        public IActionResult GetArticle(int id)
        {
            var article = _articleService.GetArticle(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        // PUT: /articles/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateArticle(int id, [FromBody] Article article)
        {
            if (id != article.Id)
            {
                return BadRequest("The ID in the path does not match the ID in the article data.");
            }

            var existingArticle = _articleService.GetArticle(article.Id);
            if (existingArticle == null)
            {
                return NotFound($"No article found with ID {article.Id}.");
            }

            if (existingArticle.WriterId != article.WriterId)
            {
                return Unauthorized("Writers can only update their own articles.");
            }

            _articleService.UpdateArticle(article);
            return NoContent();
        }



        // DELETE: /articles/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var article = _articleService.GetArticle(id); 

            _articleService.DeleteArticle(id);
            return NoContent();
        }


        // GET: /articles/latest-published
        [HttpGet("latest-published")]
        public IActionResult GetLatestPublishedArticle()
        {
            var article = _articleService.GetLatestPublishedArticle();
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        // GET: /articles/oldest-published
        [HttpGet("oldest-published")]
        public IActionResult GetOldestPublishedArticle()
        {
            var article = _articleService.GetOldestPublishedArticle();
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        // GET: /articles/latest-added
        [HttpGet("latest-added")]
        public IActionResult GetLatestAddedArticle()
        {
            var article = _articleService.GetLatestAddedArticle();
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        // GET: /articles/oldest-added
        [HttpGet("oldest-added")]
        public IActionResult GetOldestAddedArticle()
        {
            var article = _articleService.GetOldestAddedArticle();
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        // GET: /articles/by-category/{categoryId}
        [HttpGet("by-category/{categoryId}")]
        public IActionResult GetArticlesByCategory(int categoryId)
        {
            var articles = _articleService.GetArticlesByCategory(categoryId);
            return Ok(articles);
        }

        // GET: /articles/by-tag/{tagName}
        [HttpGet("by-tag/{tagName}")]
        public IActionResult GetArticlesByTagName(string tagName)
        {
            var articles = _articleService.GetArticlesByTagName(tagName);
            return Ok(articles);
        }


       

        // POST: /articles/{id}/like
        [HttpPost("{id}/like")]
        public IActionResult LikeArticle(int id)
        {
            _articleService.LikeArticle(id);
            return Ok();
        }

        // POST: /articles/{id}/rate
        [HttpPost("{id}/rate")]
        public IActionResult RateArticle(int id, [FromBody] double rating)
        {
            if (rating < 0 || rating > 5)
            {
                return BadRequest("Rating must be between 0 and 5.");
            }

            _articleService.RateArticle(id, rating);
            return Ok();
        }

        [HttpGet("test")]
        public IActionResult TestEndpoint()
        {
            return Ok("This is a test endpoint");
        }
    }
}
