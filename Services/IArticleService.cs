using CaseTeamSec.Models;
namespace CaseTeamSec.Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetArticles();
        Article GetArticle(int id);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(int id);
        Article GetLatestPublishedArticle();
        Article GetOldestPublishedArticle();
        Article GetLatestAddedArticle();
        Article GetOldestAddedArticle();
        IEnumerable<Article> GetArticlesByCategory(int categoryId);

        IEnumerable<Article> GetArticlesByTagName(string tagName);

        IEnumerable<Article> SearchArticles(string query);
        void LikeArticle(int id);
        void RateArticle(int id, double rating);
    }
}
