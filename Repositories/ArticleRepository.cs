using CaseTeamSec.Models;
using System.Collections.Generic;
using System.Linq;

namespace CaseTeamSec.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly List<Article> _articles = new List<Article>();

        private readonly ICommentRepository _commentRepository; 


        public ArticleRepository(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        
        private static int _nextId = 1;

        public void Add(Article article)
        {
            article.Id = _nextId++;
            _articles.Add(article);
        }
        public IEnumerable<Article> GetAll()
        {
            return _articles;
        }

        public Article? GetById(int id)
        {
            return _articles.FirstOrDefault(a => a.Id == id);
        }


        public void Update(Article article)
        {
            var existingArticle = GetById(article.Id);
            if (existingArticle != null)
            {
                
                existingArticle.Title = article.Title;
                existingArticle.Content = article.Content;
                existingArticle.PublishedDate = article.PublishedDate;
                existingArticle.AddedDate = article.AddedDate; 
                existingArticle.CategoryId = article.CategoryId;
                existingArticle.Tags = article.Tags;

              
            }
        }


        public bool Delete(int id)
        {
            var article = GetById(id);
            if (article != null)
            {
               
                _commentRepository.DeleteByArticle(id);

  
                _articles.Remove(article);
                return true;
            }
            return false;
        }

        public void DeleteByWriter(int writerId)
        {
            var articlesToBeDeleted = _articles.Where(article => article.WriterId == writerId).ToList();

            foreach (var article in articlesToBeDeleted)
            {
                _commentRepository.DeleteByArticle(article.Id); 
                _articles.Remove(article);
            }
        }

        
        public Writer? GetWriterById(int id)
        {
           
            return new Writer { Id = id }; 
        }
    }
}
