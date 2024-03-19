using CaseTeamSec.Models;
using CaseTeamSec.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CaseTeamSec.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IWriterRepository _writerRepository; 

        public ArticleService(IArticleRepository articleRepository, IWriterRepository writerRepository) 
        {
            _articleRepository = articleRepository;
            _writerRepository = writerRepository;
        }


        public IEnumerable<Article> GetArticles()
        {
            return _articleRepository.GetAll();
        }

        public Article GetArticle(int id)
        {
            var article = _articleRepository.GetById(id);
            if (article == null)
            {
                throw new KeyNotFoundException($"Article with ID {id} not found.");
            }
            return article;
        }

        public void CreateArticle(Article article)
        {

            var writer = _writerRepository.GetWriterById(article.WriterId);
            if (writer == null)
            {
                throw new ArgumentException("Invalid WriterId");
            }
            _articleRepository.Add(article);
        }

        public void UpdateArticle(Article article)
        {
            var writer = _writerRepository.GetWriterById(article.WriterId);
            if (writer == null)
            {
                throw new ArgumentException("Invalid WriterId");
            }
            _articleRepository.Update(article);
        }


        public void DeleteArticle(int id)
        {
            bool isDeleted = _articleRepository.Delete(id);
            if (!isDeleted)
            {
                throw new KeyNotFoundException($"Article with ID {id} not found.");
            }
        }

        

        public Article GetLatestPublishedArticle()
        {
            var article = _articleRepository.GetAll().OrderByDescending(a => a.PublishedDate).FirstOrDefault();
            if (article == null)
            {
                throw new KeyNotFoundException("No articles found.");
            }
            return article;
        }

        public Article GetOldestPublishedArticle()
        {
            var article = _articleRepository.GetAll().OrderBy(a => a.PublishedDate).FirstOrDefault();
            if (article == null)
            {
                throw new KeyNotFoundException("No articles found.");
            }
            return article;
        }

        public Article GetLatestAddedArticle()
        {
            var article = _articleRepository.GetAll().OrderByDescending(a => a.AddedDate).FirstOrDefault();
            if (article == null)
            {
                throw new KeyNotFoundException("No articles found.");
            }
            return article;
        }

        public Article GetOldestAddedArticle()
        {
            var article = _articleRepository.GetAll().OrderBy(a => a.AddedDate).FirstOrDefault();
            if (article == null)
            {
                throw new KeyNotFoundException("No articles found.");
            }
            return article;
        }

        public IEnumerable<Article> GetArticlesByCategory(int categoryId)
        {
            return _articleRepository.GetAll().Where(a => a.CategoryId == categoryId).ToList();
        }

        public IEnumerable<Article> GetArticlesByTagName(string tagName)
        {
            return _articleRepository.GetAll().Where(a => a.Tags.Contains(tagName)).ToList();
        }


        public IEnumerable<Article> SearchArticles(string query)
        {

            var writers = _writerRepository.GetAllWriters();

            var writerNamesById = writers.ToDictionary(w => w.Id, w => w.Name);

            return _articleRepository.GetAll().Where(a =>
                a.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || 
                a.Content.Contains(query, StringComparison.OrdinalIgnoreCase) || 
               
                (writerNamesById.ContainsKey(a.WriterId) && writerNamesById[a.WriterId].Contains(query, StringComparison.OrdinalIgnoreCase)) || 
                a.Tags.Any(tag => tag.Contains(query, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }



        public void LikeArticle(int id)
        {
            var article = _articleRepository.GetById(id);
            if (article != null)
            {
                article.Likes += 1;
                _articleRepository.Update(article);
            }
        }

        public void RateArticle(int id, double rating)
        {
            var article = _articleRepository.GetById(id);
            if (article != null)
            {
                article.Rating = (article.Rating * article.NumberOfRatings + rating) / (article.NumberOfRatings + 1);
                article.NumberOfRatings += 1;
                _articleRepository.Update(article);
            }
        }
    }
}
