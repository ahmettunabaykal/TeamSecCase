using CaseTeamSec.Models;
using System.Collections.Generic;

namespace CaseTeamSec.Repositories
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article? GetById(int id);
        void Add(Article article);
        void Update(Article article);
        bool Delete(int id);
        Writer? GetWriterById(int id); 

        void DeleteByWriter(int writerId); 
    }
}
